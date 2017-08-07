using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrm.Parsing
{
	public interface IParsing
	{
		event EventHandler<DownloadedEventArgs> DownloadedEvent;
		event EventHandler OnCompleDownloadedEvent;

		void Start();
		void PauseResume();
		void Stop();
	}
}
