using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrm.DataContext
{
	public static class XrmDataContextExtensions
	{
		public static void AddOrUpdateVacancies(this XrmDataContext context, IEnumerable<DomainObjects.Vacancy> entities )
		{
			var dbSet = context.Vacancies;
			foreach (var entity in entities)
			{
				var id = entity.Id;
				if ( dbSet.Any( e => e.Id == id ) )
				{
					context.Entry( entity ).State=EntityState.Modified;
				}
				else
				{
					dbSet.Add( entity );
				}
			}
		}
	}
}
