using BeanCannon.BusinessLogic.Core.Attacks;
using BeanCannon.BusinessLogic.Core.Factory;
using BeanCannon.BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BeanCannon.BusinessLogic.Core.Services
{
	public enum AttackServiceStatus
	{
		[Description("Idle")]
		Idle,

		[Description("Cleaning")]
		Cleaning,

		[Description("Heating up")]
		HeatingUp,

		[Description("In progress")]
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
		public void Toggle(IApplicationSettings settings, bool toggle, bool on)
		{
			if ((Status == AttackServiceStatus.Idle && toggle) || (!toggle && on))
			{
				this.Start(settings);
			}
			else if (toggle || !on)
			{
				this.Stop();
			}
		}

		public void Start(IApplicationSettings settings)
		{
			if (floodersList.Count > 0)
			{
				Status = AttackServiceStatus.Cleaning;

				foreach (IFlooder flooder in floodersList)
				{
					flooder.Stop();
					flooder.State.IsFlooding = false;
				}

				floodersList.Clear();
			}

			Status = AttackServiceStatus.HeatingUp;

			for (int i = 0; i < settings.Threads; i++)
			{
				IFlooder flooder = attackFactory.Get(settings);

				if (flooder != null)
				{
					flooder.Start();
					floodersList.Add(flooder);
				}
			}

			Status = AttackServiceStatus.InProgress;
		}

		public void Stop()
		{
			if (floodersList != null && floodersList.Count > 0)
			{
				Status = AttackServiceStatus.Cleaning;

				foreach (IFlooder flooder in floodersList)
				{
					flooder.Stop();
					flooder.State.IsFlooding = false;
				}
			}

			Status = AttackServiceStatus.Idle;
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
				TimeSpan totalResponseTime = TimeSpan.Zero;

				for (int a = (floodersList.Count - 1); a >= 0; a--)
				{
					if (floodersList[a] != null && (floodersList[a] is BaseFlooder))
					{
						BaseFlooder flooder = (BaseFlooder)floodersList[a];

						totalResponseTime += flooder.State.AverageResponseTime;
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
							TimeSpan totalElepsedTime = flooder.State.TotalElepsedTime;
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

								newFlooder.State.TotalElepsedTime = totalElepsedTime;
								newFlooder.State.Downloaded = iaDownloaded;
								newFlooder.State.Requested = iaRequested;
								newFlooder.State.Failed = iaFailed;

								newFlooder.Start();

								floodersList.Add(newFlooder);
							}
						}
					}
				}

				attackState.AverageResponseTime = TimeSpan.FromSeconds(totalResponseTime.TotalSeconds / settings.Threads);

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

			intShowStats = false;

			return true;
		}
	}
}
