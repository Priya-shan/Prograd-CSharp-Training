using System.ComponentModel.DataAnnotations;

namespace EntityExample.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? RollNo { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Dept { get; set; }

        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }

    }
}
