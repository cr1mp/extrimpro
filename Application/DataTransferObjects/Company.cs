using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class Company
	{
		public int? id { get; set; }
		public string title { get; set; }
		public Logo logo { get; set; }
		public List<object> interviews { get; set; }
		public List<object> onedays { get; set; }
		public List<object> photos { get; set; }
		public bool? show_logo { get; set; }
		public int? state { get; set; }
		public int? validate_state { get; set; }
		public Employees employees { get; set; }
		public int? parent_id { get; set; }
		public Reviews reviews { get; set; }
	}
}