using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class Query
	{
		public string state { get; set; }
		public bool average_salary { get; set; }
		public bool categories_facets { get; set; }
		public List<int> geo_id { get; set; }
		public bool highlight { get; set; }
		public string search_type { get; set; }
	}
}