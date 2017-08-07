using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using xrm.DataContext;
using xrm.DomainObjects;

namespace xrm
{
	public class ReadModel
	{
		private readonly DbContextFactory _contextFactory;

		public ReadModel( DataContext.DbContextFactory contextFactory )
		{
			_contextFactory = contextFactory;
		}

		public ObservableCollection<Vacancy> GetVacancies( GetVacanciesQueryObject queryObject )
		{
			using ( var context = _contextFactory.Create() )
			{
				

				IQueryable<Vacancy> sortedVacancys=context.Vacancies ;


				switch ( queryObject.SortColumn )
				{
					case ( "Id" ):
						sortedVacancys = sortedVacancys.OrderBy( x => x.Id );
						break;

					case ( "Header" ):
						sortedVacancys = sortedVacancys.OrderBy( x => x.Header );
						break;

					case ( "SalaryMaxRub" ):
						sortedVacancys = sortedVacancys.OrderBy( x => x.SalaryMaxRub );
						break;

					case ( "SalaryMinRub" ):
						sortedVacancys = sortedVacancys.OrderBy( x => x.SalaryMinRub );
						break;
				}

				sortedVacancys = queryObject.Ascending ? sortedVacancys : sortedVacancys.Reverse();

				var items =
					sortedVacancys
					.Where(queryObject.Query)
					;

				queryObject.TotalItems = items.Count();

				return new ObservableCollection<Vacancy>( items.Skip( queryObject.Start ).Take( queryObject.Start + queryObject.ItemCount ) );
			}
		}

		public long GetMaxSalary()
		{
			using (var context = _contextFactory.Create())
			{
				if (context.Vacancies.Any())
				{
					return context.Vacancies.Max(x => x.SalaryMaxRub);
				}
				else
				{
					return 0;
				}
			}
		}
	}

	public class GetVacanciesQueryObject : PagingQueryObject
	{
		public GetVacanciesQueryObject( string header, long salaryMin, long salaryMax )
		{
			header = header ?? "";
			Query = x => ( header=="" || x.Header.ToLower().Contains( header.ToLower() ) ) &&
						 ( salaryMin <= x.SalaryMinRub && x.SalaryMinRub <= salaryMax ) &&
						 ( salaryMin <= x.SalaryMaxRub && x.SalaryMaxRub <= salaryMax );

		}

		public Expression<Func<Vacancy, bool>> Query { get; }
	}

	public class PagingQueryObject
	{
		public int Start { get; set; }
		public int ItemCount { get; set; }
		public string SortColumn { get; set; }
		public bool Ascending { get; set; }
		public int TotalItems { get; set; }
	}
}

