using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrm.DataContext
{
	public class DbContextFactory:IDisposable
	{

		protected XrmDataContext DbContext;

		public XrmDataContext Create()
		{
			return DbContext = new XrmDataContext();
		}

		public void Dispose()
		{
			DbContext.Dispose();
		}
	}
}
