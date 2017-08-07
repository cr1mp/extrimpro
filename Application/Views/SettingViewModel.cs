using Prism.Commands;
using Prism.Mvvm;

namespace xrm.Views
{
	public class SettingViewModel:BindableBase
	{
		public SettingViewModel()
		{
			Save = new DelegateCommand(() => { Properties.Settings.Default.Save();});
		}

		public string DatabaseConnectionString
		{
			get { return Properties.Settings.Default.ConnectionString; }
			set
			{
				Properties.Settings.Default.ConnectionString=value;
			}
		}

		public string WebsiteRootPath
		{
			get { return Properties.Settings.Default.WebsiteRootPath; }
			set
			{
				Properties.Settings.Default.WebsiteRootPath = value;
			}
		}

		public string RequestString
		{
			get { return Properties.Settings.Default.RequestString; }
			set
			{
				Properties.Settings.Default.RequestString = value;
			}
		}

		public DelegateCommand Save { get; set; }
	}
}