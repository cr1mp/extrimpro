using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class Contact
	{
		public int icq { get; set; }
		public string skype { get; set; }
		public object email { get; set; }
		public string url { get; set; }
		public string street { get; set; }
		public string building { get; set; }
		public object room { get; set; }
		public string name { get; set; }
		public object firstname { get; set; }
		public object lastname { get; set; }
		public object patronymic { get; set; }
		public List<object> phones { get; set; }
		public City city { get; set; }
		public string address_description { get; set; }
		public Coordinate coordinate { get; set; }
		public District district { get; set; }
		public Microdistrict microdistrict { get; set; }
		public Subway subway { get; set; }
		public string address { get; set; }
	}
}