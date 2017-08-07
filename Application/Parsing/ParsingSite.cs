using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using xrm.DataContext;

namespace xrm.Parsing
{
	internal class ParsingSite : Worker, IParsing
	{
		private readonly IMapper _mapper;
		private readonly DbContextFactory _contextFactory;
		private readonly HttpClient _client ;

		private ulong _i;
		private bool _pause;

		public event EventHandler<DownloadedEventArgs> DownloadedEvent;
		public event EventHandler OnCompleDownloadedEvent;

		public ParsingSite( IMapper mapper, DbContextFactory contextFactory )
		{
			_mapper = mapper;
			_contextFactory = contextFactory;
			_client = new HttpClient
			{
				BaseAddress = new Uri(Properties.Settings.Default.WebsiteRootPath)
			};
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
		}

		public override void Start()
		{
			_i = 0;
			base.Start();
		}

		protected override async Task MyWork()
		{
			
			var items = await GetItems(_i);
			if ( !items.Any() )
			{
				OnCompleDownloadedEvent?.Invoke(this,new EventArgs());
			}
			_i += 25;
			await SaveItems( items );
		}

		private async Task<List<DataTransferObjects.Vacancy>> GetItems( ulong i )
		{
			DataTransferObjects.RootObject product = null;

			var root = await ExecuteRequestAsync(string.Format( Properties.Settings.Default.RequestString, i ));
			return root.vacancies;
		}

		private async Task<DataTransferObjects.RootObject> ExecuteRequestAsync( string path )
		{
			DataTransferObjects.RootObject result = null;
			HttpResponseMessage response = await _client.GetAsync(path);
			if ( response.IsSuccessStatusCode )
			{
				result = await response.Content.ReadAsAsync<DataTransferObjects.RootObject>();
			}
			return result;
		}

		private async Task SaveItems( List<DataTransferObjects.Vacancy> items )
		{
			var domainObjects = _mapper.Map<List<DomainObjects.Vacancy>>(items);
			using ( var context = _contextFactory.Create() )
			{
				context.AddOrUpdateVacancies( domainObjects );
				await context.SaveChangesAsync();
			}

			OnDownloadedEvent(new DownloadedEventArgs(_i));
		}

		protected virtual void OnDownloadedEvent( DownloadedEventArgs e) => DownloadedEvent?.Invoke(this, e);

		public void PauseResume()
		{
			if (_pause)
			{
				Resume();
				_pause = false;
			}
			else
			{
				_pause = true;
				Pause();
			}
		}
	}
}
