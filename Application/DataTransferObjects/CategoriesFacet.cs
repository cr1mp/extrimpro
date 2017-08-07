using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class CategoriesFacet
	{
		public int id { get; set; }
		public string title { get; set; }
		public int count { get; set; }
		public List<Speciality> specialities { get; set; }
	}
}