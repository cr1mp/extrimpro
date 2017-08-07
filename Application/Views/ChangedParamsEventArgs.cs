using System;

namespace xrm.Views
{
	public class ChangedParamsEventArgs:EventArgs
	{
		public string Header { get; set; }
		public long Smin { get; set; }
		public long Smax { get; set; }

		public ChangedParamsEventArgs( string header, long smin, long smax )
		{
			Header = header;
			Smin = smin;
			Smax = smax;
		}
	}
}