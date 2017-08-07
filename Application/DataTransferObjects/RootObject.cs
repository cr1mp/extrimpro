using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class RootObject
	{
		public Metadata metadata { get; set; }
		public List<Vacancy> vacancies { get; set; }
	}
}