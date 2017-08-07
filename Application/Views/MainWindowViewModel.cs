using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Mvvm;

namespace xrm.Views
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly ReadModel _readModel;
		private ObservableCollection<DomainObjects.Vacancy> _vacancies;


		public MainWindowViewModel( ParsingViewModel parsingViewModel,
			SettingViewModel settingViewModel,
			PagingViewModel pagingViewModel,
			SearchViewModel searchViewModel,
			ReadModel readModel
			)
		{
			_readModel = readModel;
			Parsing = parsingViewModel;
			Setting = settingViewModel;
			Paging = pagingViewModel;
			Search = searchViewModel;

			Paging.PropertyChanged+=PagingOnPropertyChanged;
			Search.ChangedParamsEvent += (sender, args) =>Paging.Start = 0 ;
			Parsing.CollectionUpdateEvent+=	(sender, args) => Paging.Start = 0;
			Parsing.OnCompleDownloadedEvent+=(sender, args) => { OnCompleDownloadedEvent?.Invoke(sender,args);};

			Vacancies = new ObservableCollection<DomainObjects.Vacancy>();
			RefreshVacancies();
		}

		public event EventHandler OnCompleDownloadedEvent;

		private void PagingOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			if (propertyChangedEventArgs.PropertyName != nameof(Paging.TotalItems ) )
			{
				RefreshVacancies();
			}
		}

		private void RefreshVacancies()
		{
			var query = new GetVacanciesQueryObject(Search.Query, Search.SalaryMin, Search.SalaryMax)
			{
				Start = Paging.Start,
				ItemCount = Paging.ItemCount,
				SortColumn = Paging.SortColumn,
				Ascending = Paging.Ascending,

			};
			Vacancies = _readModel.GetVacancies( query ) ;
			Paging.TotalItems = query.TotalItems;
		}

		public ParsingViewModel Parsing { get; set; }
		public SettingViewModel Setting { get; set; }
		public PagingViewModel Paging { get; set; }
		public SearchViewModel Search { get; set; }

		public ObservableCollection<DomainObjects.Vacancy> Vacancies
		{
			get
			{
				return _vacancies;
			}
			set
			{
				_vacancies = value;
				RaisePropertyChanged();
			}
		}

		public void Sort(string sortField, bool sortAscending)
		{
			Paging.SortColumn = sortField;
			Paging.Ascending = sortAscending;
		}
	}
}