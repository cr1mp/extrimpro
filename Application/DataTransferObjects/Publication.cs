namespace xrm.DataTransferObjects
{
	public class Publication
	{
		public int id { get; set; }
		public int geo_id { get; set; }
		public int? order_id { get; set; }
		public int vacancy_id { get; set; }
		public int company_id { get; set; }
		public string type { get; set; }
		public string action { get; set; }
		public bool is_active { get; set; }
		public bool is_free { get; set; }
		public bool logo_in_list { get; set; }
		public bool is_service_finished { get; set; }
		public int live_time { get; set; }
		public string expired_at { get; set; }
		public string published_at { get; set; }
		public string created_at { get; set; }
		public bool is_dummy { get; set; }
		public bool is_deleted { get; set; }
		public object prolong_data { get; set; }
	}
}