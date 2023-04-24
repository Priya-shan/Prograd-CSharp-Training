using System.ComponentModel.DataAnnotations;

namespace DockerSupport.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string dept { get; set; }
        [Required]
        public string college_name { get; set; }
    }
}
