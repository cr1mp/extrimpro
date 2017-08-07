using System;
using System.Data.Entity;
using System.Windows;
using AutoMapper;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Unity;
using xrm.DataContext;
using xrm.Parsing;

namespace xrm
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override async void OnStartup(StartupEventArgs e)
		{
			IUnityContainer container = new UnityContainer();
			ConfigureContainer(container);

			ConfigureDatabase( container );

			var mainWindow = container.Resolve<Views.MainWindow>();

			try
			{
				Application.Current.MainWindow = mainWindow;
				Application.Current.MainWindow.Show();
			}
			catch (Exception ex)
			{
				await mainWindow.ShowMessageAsync("Error",ex.Message);
				throw;
			}
		}

		private void ConfigureDatabase( IUnityContainer container )
		{
			Database.SetInitializer<XrmDataContext>( new CreateDatabaseIfNotExists<XrmDataContext>() );
			var factory = container.Resolve<DbContextFactory>();
			using ( var context = factory.Create() )
			{
				context.Database.Initialize( true );
				context.Database.CreateIfNotExists();
			}
		}

		private void ConfigureContainer(IUnityContainer container)
		{
			container.RegisterType<IParsing, ParsingSite>();

			var config = new MapperConfiguration(MapperInitialize);
			container.RegisterInstance<IMapper>(config.CreateMapper());

		}

		private void MapperInitialize(IMapperConfigurationExpression cfg)
		{
			cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
			cfg.DestinationMemberNamingConvention = new  PascalCaseNamingConvention();
			cfg.CreateMap<DataTransferObjects.Vacancy,DomainObjects.Vacancy>();
		}
	}
}
