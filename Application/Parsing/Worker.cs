using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace xrm.Parsing
{
	public abstract class Worker
	{
		ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
		ManualResetEvent _pauseEvent = new ManualResetEvent(true);
		Thread _thread;

		public Worker() { }

		public virtual void Start()
		{
			_shutdownEvent.Reset();
			_thread = new Thread( DoWork )
			{
				Name = "ParsingThread"
			};
			_thread.Start();
		}

		public virtual void Pause()
		{
			_pauseEvent.Reset();
		}

		public virtual void Resume()
		{
			_pauseEvent.Set();
		}

		public virtual void Stop()
		{
			_shutdownEvent.Set();
			
			_pauseEvent.Set();
			
			_thread.Join();
		}

		protected virtual async void DoWork()
		{
			while ( true )
			{
				_pauseEvent.WaitOne( Timeout.Infinite );

				if ( _shutdownEvent.WaitOne( 0 ) )
					break;

				await MyWork();
			}
		}

		protected abstract Task MyWork();
	}
}
