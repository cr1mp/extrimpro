using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace xrm.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		private DataGridColumn currentSortColumn;

		private ListSortDirection currentSortDirection;

		public MainWindow( MainWindowViewModel model )
		{
			InitializeComponent();
			this.DataContext = model;
			model.OnCompleDownloadedEvent += ModelOnOnCompleDownloadedEvent;
		}

		private void ModelOnOnCompleDownloadedEvent(object sender, EventArgs eventArgs)
		{
			 Application.Current.Dispatcher.BeginInvoke( DispatcherPriority.Background, new Action( () => this.ShowMessageAsync( "Парсинг", "Загрузка завершена." ) ) );
			
		}

		private void ParsingOnClick( object sender, RoutedEventArgs e )
		{
			ToggleFlyout( parsingFlyout );
		}

		private void SettingOnClick( object sender, RoutedEventArgs e )
		{
			ToggleFlyout( settingsFlyout );
		}

		private void ToggleFlyout( Flyout flyout )
		{
			if ( flyout == null )
			{
				return;
			}

			flyout.IsOpen = !flyout.IsOpen;
		}

		private void VacanciesDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
		{
			e.Handled = true;

			var mainViewModel = (MainWindowViewModel)DataContext;

			string sortField = e.Column.SortMemberPath;

			ListSortDirection direction = (e.Column.SortDirection != ListSortDirection.Ascending) ?
			ListSortDirection.Ascending : ListSortDirection.Descending;

			bool sortAscending = direction == ListSortDirection.Ascending;

			mainViewModel.Sort( sortField, sortAscending );

			currentSortColumn.SortDirection = null;

			e.Column.SortDirection = direction;

			currentSortColumn = e.Column;
			currentSortDirection = direction;
		}

		private void VacanciesDataGrid_TargetUpdated(object sender, DataTransferEventArgs e)
		{
			if (currentSortColumn != null)
			{
				currentSortColumn.SortDirection = currentSortDirection;
			}
		}

		private void VacanciesDataGrid_Loaded(object sender, RoutedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)sender;

			currentSortColumn = dataGrid.Columns.FirstOrDefault(c => c.SortDirection.HasValue) ?? dataGrid.Columns.First();
			if (currentSortColumn.SortDirection != null)
			{
				currentSortDirection = currentSortColumn.SortDirection.Value;
			}

			if (dataGrid.Items.Count == 0)
			{
				ToggleFlyout(parsingFlyout);
			}
		}
	}
}
