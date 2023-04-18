using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApiWIthEntity.Models
{
    [Keyless]
    public class StudentModel
    {
        [Required]
        public string RollNo { get; set; }

        [Required]
        public string? Name { get; set; }


    }
}
