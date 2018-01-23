using BeanCannon.BusinessLogic.Core;
using System;

namespace Loic.BusinessLogic.Core.Attacks.Settings
{
	public class AttackerThreadState
	{
		public RequestStatus Status = RequestStatus.Ready;

		/// <summary>
		/// Shows if all possible sockets are build.
		/// TRUE as long as the maximum amount of sockets is NOT reached.
		/// </summary>
		public bool IsDelayed { get; set; }

		/// <summary>
		/// Set or get the current working state.
		/// </summary>
		public bool IsFlooding { get; set; }

		/// <summary>
		/// Amount of send requests.
		/// </summary>
		public int Requested { get; set; }

		/// <summary>
		/// Amount of received responses / packets.
		/// </summary>
		public int Downloaded { get; set; }

		/// <summary>
		/// Amount of failed packets / requests.
		/// </summary>
		public int Failed { get; set; }

		/// <summary>
		/// Managed Worker Thread Id.
		/// </summary>
		public int ManagedThreadId { get; set; }

		// TODO: Implement in all attackers
		internal TimeSpan TotalElepsedTime { get; set; }

		internal TimeSpan AverageResponseTime
		{
			get
			{
				if (TotalElepsedTime <= TimeSpan.Zero)
				{
					return TimeSpan.Zero;
				}

				return TimeSpan.FromSeconds(TotalElepsedTime.TotalSeconds / Downloaded);
			}
		}
	}
}
