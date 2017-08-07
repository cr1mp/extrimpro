using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class Metadata
	{
		public Query query { get; set; }
		public List<CategoriesFacet> categories_facets { get; set; }
		public int average_salary { get; set; }
		public List<object> highlight { get; set; }
		public List<Deprecation> deprecations { get; set; }
		public Resultset resultset { get; set; }
	}
}