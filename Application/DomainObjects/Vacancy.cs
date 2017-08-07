using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrm.DomainObjects
{
	public class Vacancy
	{
		public int Id { get; set; }
		public string Header { get; set; }
		public long SalaryMinRub { get; set; }
		public long SalaryMaxRub { get; set; }
	}
}
