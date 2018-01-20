/* collection of some upper layer protocol stress-testing
 * loosely based on the slow-loris attempts and other low bandwidth attempts
 *
 * and always remember:
 * if you hit your own server, it is called: stress-testing
 * if you hit a server that is not yours, it is called: DOS-Attack
 * if you want to test your server but are too stoned to enter your ip correctly,
 * it is called: accident (and always blame it on the weed!)
 *
 * B²
 */

using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using Loic.BusinessLogic.Core.Attacks.Settings;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace BeanCannon.BusinessLogic.Core.Attacks
{
	/// <summary>
	/// Abstract class cHLDos contributed by B²
	/// and updated by kmataru
	/// </summary>
	public abstract class BaseFlooder : IFlooder
	{
		public AttackerThreadState State { get; } = new AttackerThreadState();

		public Stopwatch Clock { get; } = new Stopwatch();

		private BackgroundWorker backgroundWorker;

		public AttackSettings Settings { get; internal set; }

		protected abstract void OnDoWorkEvent(object sender, DoWorkEventArgs e);

		public virtual void BeforeStart() { }

		public virtual void Start()
		{
			State.IsFlooding = true;

			BeforeStart();

			this.backgroundWorker = new BackgroundWorker()
			{
				WorkerSupportsCancellation = true
			};
			this.backgroundWorker.DoWork += OnDoWorkEventInternal;
			this.backgroundWorker.RunWorkerAsync();
		}

		private void OnDoWorkEventInternal(object sender, DoWorkEventArgs e)
		{
			var currentThread = Thread.CurrentThread;
			State.ManagedThreadId = currentThread.ManagedThreadId;
			currentThread.Name = $"Flooder-{currentThread.ManagedThreadId}";

			OnDoWorkEvent(sender, e);
		}

		public virtual void Stop()
		{
			State.IsFlooding = false;
			State.IsDelayed = true;

			this.backgroundWorker.CancelAsync();
			Clock.Stop();
		}

		/// <summary>
		/// override this if you want to test the settings before spreading the word to the hivemind!
		/// should make a single connection and check for the expected outcome!
		/// </summary>
		public virtual bool Test()
		{
			return true;
		}
	}

	public abstract class BaseFlooder<T> : BaseFlooder, IFlooder<T>
		where T : AttackSettings
	{
		public new T Settings { get; internal set; }

		public BaseFlooder(T settings)
		{
			base.Settings =
			this.Settings = settings;
		}
	}
}
