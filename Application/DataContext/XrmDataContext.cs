using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrm.DataContext
{
	public class XrmDataContext:DbContext
	{
		public XrmDataContext()
			:base(Properties.Settings.Default.ConnectionString)
		{
			
		}

		public DbSet<DomainObjects.Vacancy> Vacancies { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<DomainObjects.Vacancy>().HasKey(p => p.Id);
				
			modelBuilder.Entity<DomainObjects.Vacancy>().Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

		}
	}
}
