using System.ComponentModel.DataAnnotations;

namespace Job_Application.Models
{
    public class JobDetails
    {
        [Key]
        [Required]
        public int job_id { get; set; }
        [Required]
        public string job_name { get; set; }
        [Required]
        public string job_category { get; set; }
        [Required]
        public string job_desc { get; set; }
        [Required]
        public double salary { get; set; }
        [Required]
        public string company_name { get; set; }

    }
}
