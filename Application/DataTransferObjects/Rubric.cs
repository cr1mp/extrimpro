using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class Rubric
	{
		public int id { get; set; }
		public string title { get; set; }
		public List<Speciality2> specialities { get; set; }
	}
}