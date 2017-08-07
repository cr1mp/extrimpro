using System.Collections.Generic;

namespace xrm.DataTransferObjects
{
	public class Vacancy
	{
		public int id { get; set; }
		public string add_date { get; set; }
		public int owner_id { get; set; }
		public string header { get; set; }
		public int state { get; set; }
		public int validate_state { get; set; }
		public string visibility_type { get; set; }
		public bool removal { get; set; }
		public int site_id { get; set; }
		public int bonus { get; set; }
		public long salary_min { get; set; }
		public long salary_max { get; set; }
		public Currency currency { get; set; }
		public Education education { get; set; }
		public ExperienceLength experience_length { get; set; }
		public WorkingType working_type { get; set; }
		public Schedule schedule { get; set; }
		public bool logo_in_list { get; set; }
		public Publication publication { get; set; }
		public string user_type { get; set; }
		public string description { get; set; }
		public Contact contact { get; set; }
		public object address { get; set; }
		public string payment_type_alias { get; set; }
		public PaymentType payment_type { get; set; }
		public Company company { get; set; }
		public string mod_date { get; set; }
		public int views { get; set; }
		public bool is_anonymous { get; set; }
		public Owner owner { get; set; }
		public bool is_moderated { get; set; }
		public object imported_via { get; set; }
		public List<object> subways { get; set; }
		public List<object> tags { get; set; }
		public List<object> institutions { get; set; }
		public List<object> jobs { get; set; }
		public bool show_email { get; set; }
		public bool show_phone { get; set; }
		public bool use_messages { get; set; }
		public bool is_commerce { get; set; }
		public bool is_upped { get; set; }
		public bool is_premium { get; set; }
		public List<object> toponyms { get; set; }
		public object log_state_update { get; set; }
		public bool favorite { get; set; }
		public bool hided { get; set; }
		public string url { get; set; }
		public long salary_min_rub { get; set; }
		public long salary_max_rub { get; set; }
		public List<Rubric> rubrics { get; set; }
		public string requirements_short { get; set; }
		public string requirements { get; set; }
		public int priority { get; set; }
		public string salary { get; set; }
		public string salary_formatted { get; set; }
		public bool can_accept_replies { get; set; }
		public bool has_cpa { get; set; }
	}
}