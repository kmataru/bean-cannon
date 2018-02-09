using BeanCannon.BusinessLogic.Core.Models;
using BeanCannon.BusinessLogic.Core.Net;
using BeanCannon.BusinessLogic.Core.Wrappers;
using Org.Mentalis.Network.ProxySocket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeanCannon.BusinessLogic.Core.Services
{
	public enum ProxyTesterStatus
	{
		[Description("Idle")]
		Idle,

		[Description("Heating up")]
		HeatingUp,

		[Description("In progress")]
		InProgress,

		[Description("Done")]
		Done,
	}

	public class ProxyTester
	{
		private static readonly Object locker = new Object();

		public ProxyTesterStatus Status = ProxyTesterStatus.Idle;

		private readonly SpinProxiesRootResponse spinProxiesData;
		private readonly SpinProxiesApiWrapper spinProxiesApiWrapper;

		public ProxyTesterState State { get; } = new ProxyTesterState();

		private bool IsInit = false;

		private BackgroundWorker backgroundWorker;

		static readonly ProxyTypes[] proxyTypesToTest = new[] {
			ProxyTypes.Socks4,
			ProxyTypes.Socks5
		};

		public static readonly TimeSpan InvalidProxyConnectionTime = TimeSpan.FromMinutes(-1);
		public static readonly TimeSpan MaximumConnectionTime = TimeSpan.FromSeconds(0.666);

		// const double maximumConnectionTime = 0.666 / 1.666; // ~0.39975
		// const double maximumConnectionTime = 1.666 / 0.666 / 1.666; // 1 / 1.666 = ~1.5

		byte[] probeProxyHeaderBuffer;

		private ProxyTester()
		{
			spinProxiesApiWrapper = new SpinProxiesApiWrapper();
			spinProxiesData = spinProxiesApiWrapper.FetchProxyList(SpinProxiesProxyClass.Socks5);

			probeProxyHeaderBuffer = new FluentHeaderBuilder()
				.AddMethod("http://c.statcounter.com/11592521/0/dc42a2e3/0/", HttpMethod.Get)
				.Add(HttpRequestHeader.Host, "c.statcounter.com")
				.Add(HttpRequestHeader.Connection, "keep-alive")
				.Add(HttpRequestHeader.CacheControl, "max-age=0")
				.AddCustom("Upgrade-Insecure-Requests", "1")
				.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36")
				.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8")
				.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate")
				.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.9,ro;q=0.8")
				.Add(HttpRequestHeader.Pragma, "no-cache")
				.BuildAsByteArray();
		}

		private static ProxyTester _Instance;
		public static ProxyTester Instance
		{
			get
			{
				lock (locker)
				{
					if (null == _Instance)
					{
						_Instance = new ProxyTester();
					}

					return _Instance;
				}
			}
		}

		private List<ProxyDatum> availableProxiesList = new List<ProxyDatum>();

		//public ReadOnlyCollection<ProxyDatum> GetAvailableProxies(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		public ProxyDatum[] GetAvailableProxies(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			return GetAvailableProxies(addressFamily, socketType, protocolType, true);
		}

		public ProxyDatum[] GetAvailableProxies(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, bool checkMaximumConnectionTime)
		{
			List<ProxyDatum> filteredProxiesList;

			lock (availableProxiesList)
			{
				filteredProxiesList = availableProxiesList
					.Where(w => IsProxyValidCandidate(w, addressFamily, socketType, protocolType, MaximumConnectionTime, checkMaximumConnectionTime))
					.ToList();

				/*
				Logger.Log.Debug(new
				{
					Message = "Get Available Proxies",
					Count = filteredProxiesList.Count,
					AddressFamily = addressFamily,
					SocketType = socketType,
					ProtocolType = protocolType
				});
				*/
			}

			//return filteredProxiesList.AsReadOnly();
			return filteredProxiesList.ToArray();
		}

		public bool IsProxyTested(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			lock (proxy)
			{
				return
				!(
					proxy.Tests == null ||
					!proxy.Tests.ContainsKey(addressFamily) ||
					proxy.Tests[addressFamily] == null ||
					!proxy.Tests[addressFamily].ContainsKey(socketType) ||
					proxy.Tests[addressFamily][socketType] == null ||
					!proxy.Tests[addressFamily][socketType].ContainsKey(protocolType) ||
					proxy.Tests[addressFamily][socketType][protocolType] == null ||
					!(proxy.Tests[addressFamily][socketType][protocolType].Count != 0)
				);
			}
		}

		public bool IsProxyValidCandidate(
			ProxyDatum proxy,
			AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType,
			TimeSpan maximumConnectionTime
			)
		{
			return IsProxyValidCandidate(
				proxy,
				addressFamily, socketType, protocolType,
				maximumConnectionTime,
				true
				);
		}

		public bool IsProxyValidCandidate(
			ProxyDatum proxy,
			AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType,
			TimeSpan maximumConnectionTime,
			bool checkMaximumConnectionTime
			)
		{
			var isTested = IsProxyTested(proxy, addressFamily, socketType, protocolType);
			if (isTested)
			{
				var testElement = proxy.Tests[addressFamily][socketType][protocolType];

				if (checkMaximumConnectionTime)
				{
					var maximumConnectionTimeInSeconds = maximumConnectionTime.TotalSeconds;

					return testElement
						.Any(w => w.Value >= 0 && w.Value <= maximumConnectionTimeInSeconds);
				}

				return testElement
					.Any(w => w.Value >= 0);
			}

			return false;
		}

		public void RunAsync()
		{
			lock (locker)
			{
				if (!IsInit)
				{
					backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += BackgroundWorker_DoWork;
					backgroundWorker.RunWorkerAsync();

					IsInit = true;
				}
			}
		}

		public void Run()
		{
			lock (locker)
			{
				if (!IsInit)
				{
					DoWork();

					IsInit = true;
				}
			}
		}

		private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			DoWork();
		}

		private void DoWork()
		{
			Status = ProxyTesterStatus.HeatingUp;

			var currentThread = System.Threading.Thread.CurrentThread;
			currentThread.Name = $"ProxyTester-{currentThread.ManagedThreadId}";

			var addressFamily = AddressFamily.InterNetwork;
			var socketType = SocketType.Stream;
			var protocolType = ProtocolType.Tcp;

			var proxies = spinProxiesData.Data.Proxies
				.Where(w =>
				{
					bool hasValidValues = false;
					var isProxyTested = IsProxyTested(w, addressFamily, socketType, protocolType);

					if (isProxyTested)
					{
						hasValidValues = w.Tests[addressFamily][socketType][protocolType]
							.Any(x => x.Value >= 0);
					}

					return !isProxyTested || hasValidValues;
				});

			State.Total = proxies.Count();
			State.Types = proxyTypesToTest.Length;

			Status = ProxyTesterStatus.InProgress;

			// TODO: Convert to array
			//var tasks = new List<Task>();

			foreach (var proxy in proxies)
			{
				DoWorkInternal(proxy);

				//tasks.Add(Task.Factory.StartNew(DoWorkInternal, proxy));
			}

			//Task.WaitAll(tasks.ToArray());

			Status = ProxyTesterStatus.Done;

			Logger.Log.Debug("Done testing proxies.");

			State.Done = true;
		}

		void DoWorkInternal(object actionState)
		{
			ProxyDatum proxy = actionState as ProxyDatum;

			//var addressFamily = AddressFamily.InterNetwork;
			var socketType = SocketType.Stream;
			var protocolType = ProtocolType.Tcp;

			bool isProxyInvalid = true;

			lock (State)
			{
				++State.Testing;
			}

			foreach (var proxyTypeToTest in proxyTypesToTest)
			{
				bool isProxySocketValid = ProbeProxy(proxy, socketType, protocolType, proxyTypeToTest, MaximumConnectionTime);

				SpinProxiesApiWrapper.WriteTempContent(spinProxiesData, SpinProxiesProxyClass.Socks5);

				isProxyInvalid = (isProxyInvalid && !isProxySocketValid);

				if (isProxySocketValid)
				{
					lock (State)
					{
						++State.Available;
					}

					lock (availableProxiesList)
					{
						availableProxiesList.Add(proxy);
					}

					break;
				}
			}

			lock (State)
			{
				++State.Tested;
			}

			if (isProxyInvalid)
			{
				lock (State)
				{
					++State.Failed;
				}
			}
		}

		public bool ProbeProxy(
			ProxyDatum proxy,
			SocketType socketType, ProtocolType protocolType, ProxyTypes proxyType,
			TimeSpan maximumConnectionTime
			)
		{
			var success = false;
			AddressFamily addressFamily = AddressFamily.Unspecified;

			var parentThread = Thread.CurrentThread;

			var task = Task.Factory.StartNew((object parentThreadName) =>
			{
				var currentThread = Thread.CurrentThread;
				currentThread.Name = $"{parentThreadName} -> TestProxySocket-{currentThread.ManagedThreadId}";

				/*
				Logger.Log.Debug(new
				{
					Message = "Testing proxy",
					proxy.Ip,
					proxy.Port,
					SocketType = socketType,
					ProtocolType = protocolType,
					ProxyType = proxyType
				});
				*/

				success = ProbeProxySocketImplementation(proxy, socketType, protocolType, proxyType, out addressFamily, out string errorMsg, out TimeSpan connectionTime);

				Logger.Log.Info(new
				{
					Message = "Proxy tested",
					Success = success,
					proxy.Ip,
					proxy.Port,
					AddressFamily = addressFamily,
					SocketType = socketType,
					ProtocolType = protocolType,
					ProxyType = proxyType,
					ConnectionTime = connectionTime,
					ErrorMessage = errorMsg
				});

				var testedConnectionTime = InvalidProxyConnectionTime;

				if (success)
				{
					//testedConnectionTime = (connectionTime <= maximumConnectionTime ? connectionTime : -connectionTime);
					testedConnectionTime = connectionTime;
				}

				SetTestValidity(proxy, addressFamily, socketType, protocolType, proxyType, testedConnectionTime);
			}, parentThread.Name);

			if (!task.Wait(TimeSpan.FromSeconds(maximumConnectionTime.TotalSeconds * 1.25)))
			{
				SetTestValidity(proxy, addressFamily, socketType, protocolType, proxyType, InvalidProxyConnectionTime);

				return false;
			}

			//WriteMasterContent(masterProxyListFilePath, storedData);

			return success;
		}

		private bool ProbeProxySocketImplementation(
			ProxyDatum proxy,
			SocketType socketType, ProtocolType protocolType, ProxyTypes proxyType,
			out AddressFamily addressFamily,
			out string errorMsg, out TimeSpan connectionSeconds
			)
		{
			Stopwatch stopWatch = new Stopwatch();

			addressFamily = AddressFamily.Unspecified;
			errorMsg = "";
			connectionSeconds = InvalidProxyConnectionTime;

			try
			{
				byte[] recvBuf = new byte[128];

				var targetIpAddress = Dns.GetHostEntry("example.com").AddressList[0];
				IPEndPoint endPoint = new IPEndPoint(targetIpAddress, 80);
				addressFamily = endPoint.AddressFamily;

				using (ProxySocket proxySocket = new ProxySocket(endPoint.AddressFamily, socketType, protocolType))
				{
					proxySocket.ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxy.Ip), proxy.Port);
					proxySocket.ProxyType = proxyType;

					proxySocket.NoDelay = true;

					stopWatch.Start();

					try
					{
						proxySocket.Connect(endPoint);
					}
					catch (SocketException) { return false; }

					proxySocket.Blocking = false;

					try
					{
						proxySocket.Send(probeProxyHeaderBuffer, SocketFlags.None);

						// TODO : Review
						/*
						if (!proxySocket.Poll((int)connectionSeconds.TotalMilliseconds * 1000, SelectMode.SelectRead))
						{
							return false;
						}
						//*/
						/*
						if (proxySocket.Blocking)
						{
							proxySocket.ReceiveTimeout = 10000;
							proxySocket.Receive(recvBuf, recvBuf.Length, SocketFlags.None);
						}
						//*/
					}
					catch (SocketException) { return false; }
				}

				return true;
			}
			catch (Exception ex)
			{
				errorMsg = ex.Message;
				return false;
			}
			finally
			{
				stopWatch.Stop();
				connectionSeconds = stopWatch.Elapsed;
			}
		}

		internal static void SetTestValidity(
			ProxyDatum proxy,
			AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, ProxyTypes proxyType,
			TimeSpan connectionTime
			)
		{
			lock (proxy)
			{
				if (null == proxy.Tests)
				{
					proxy.Tests = new Dictionary<AddressFamily, Dictionary<SocketType, Dictionary<ProtocolType, Dictionary<ProxyTypes, double>>>>();
				}

				if (!proxy.Tests.ContainsKey(addressFamily))
				{
					proxy.Tests[addressFamily] = new Dictionary<SocketType, Dictionary<ProtocolType, Dictionary<ProxyTypes, double>>>();
				}

				if (!proxy.Tests[addressFamily].ContainsKey(socketType))
				{
					proxy.Tests[addressFamily][socketType] = new Dictionary<ProtocolType, Dictionary<ProxyTypes, double>>();
				}

				if (!proxy.Tests[addressFamily][socketType].ContainsKey(protocolType))
				{
					proxy.Tests[addressFamily][socketType][protocolType] = new Dictionary<ProxyTypes, double>();
				}

				if (!proxy.Tests[addressFamily][socketType][protocolType].ContainsKey(proxyType))
				{
					proxy.Tests[addressFamily][socketType][protocolType].Add(proxyType, connectionTime.TotalSeconds);
				}
				else
				{
					proxy.Tests[addressFamily][socketType][protocolType][proxyType] = connectionTime.TotalSeconds;
				}
			}
		}
	}
}
