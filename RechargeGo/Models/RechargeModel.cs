using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeGo.Models
{
    public class RechargeModel
    {
        [Key]
        [Required]
        public int recharge_id { get; set; }
        [Required]
        public string customer_name { get; set; }
        [Required]
        public string mobile_number { get; set;}
        [Required]
        public int amount { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string transact_status { get; set; }
        [ForeignKey("PlansInfo")]
        public int plan_id { get; set; }    




    }
}
