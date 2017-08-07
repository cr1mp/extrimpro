using System;

namespace xrm.Parsing
{
	public class DownloadedEventArgs : EventArgs
	{
		private ulong _count;

		public ulong Count
		{
			get { return _count; }
			set { _count = value; }
		}

		public DownloadedEventArgs(ulong count)
		{
			Count = count;
		}

		
	}
}