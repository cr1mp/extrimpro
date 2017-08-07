using System;
using Prism.Commands;
using Prism.Mvvm;

namespace xrm.Views
{
	public class SearchViewModel:BindableBase
	{
		private readonly ReadModel _readModel;
		public event EventHandler<ChangedParamsEventArgs> ChangedParamsEvent;

		public SearchViewModel(ReadModel readModel)
		{
			_readModel = readModel;

			SalaryMax = MaximumSalary;

			Go =new DelegateCommand(() => { ChangedParamsEvent?.Invoke(this,new ChangedParamsEventArgs(Query, SalaryMin, SalaryMax ) ); } );
		}

		public string Query { get; set; }
		public long SalaryMin { get; set; }
		public long SalaryMax { get; set; }

		public long MaximumSalary
		{
			get { return _readModel.GetMaxSalary(); }
		}

		public DelegateCommand Go { get; set; }
	}
}