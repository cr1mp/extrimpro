using Prism.Commands;
using Prism.Mvvm;

namespace xrm.Views
{
	public class PagingViewModel:BindableBase
	{
		private int _start = 0;

		private int _itemCount = 25;

		private string _sortColumn = "Id";

		private bool _ascending = true;

		private int _totalItems = 0;

		public PagingViewModel()
		{
			Next = new DelegateCommand(() => { Start += ItemCount; }, () => Start+ItemCount<TotalItems);
			Prev = new DelegateCommand(() => { Start -= ItemCount; }, () => Start-ItemCount>=0 );
		}

		public DelegateCommand Next { get; set; }

		public DelegateCommand Prev { get; set; }

		public int Start
		{
			get
			{
				return _start;
			}
			set
			{
				_start = value;
				RaiseAllPropertyChanged();
			}
		}

		public int End { get { return Start + ItemCount < TotalItems ? Start + ItemCount : TotalItems; } }

		public int ItemCount { get { return _itemCount; } }
		public string SortColumn { get { return _sortColumn; }set { _sortColumn = value; } }
		public bool Ascending { get { return _ascending; } set { _ascending = value; RaiseAllPropertyChanged();} }

		public int TotalItems
		{
			get { return _totalItems; }
			set
			{
				_totalItems = value;
				RaisePropertyChanged();
			}
		}

		public void RaiseAllPropertyChanged()
		{
			RaisePropertyChanged(nameof( Start ) );
			RaisePropertyChanged( nameof( End ) );
			Next.RaiseCanExecuteChanged();
			Prev.RaiseCanExecuteChanged();
		}
	}
}