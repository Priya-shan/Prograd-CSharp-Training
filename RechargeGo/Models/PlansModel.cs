using System.ComponentModel.DataAnnotations;

namespace RechargeGo.Models
{
    public class PlansModel
    {
        [Key]
        [Required]
        public int plan_id { get; set; }
        [Required]
        public string operator_name { get; set; }
        [Required]
        public string category { get; set;}
        [Required]
        public int amount { get; set; }
        [Required]
        public string data { get; set; }
        [Required]
        public string validity { get; set; }
    }
}
