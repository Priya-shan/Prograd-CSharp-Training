using System.ComponentModel.DataAnnotations;

namespace Concurrency_Token.Models
{
    public class ProductsModel
    {
            [Key]
            [Required]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int quantity { get; set; }

            [Timestamp]
            public byte[] RowVersion { get; set; }
    }
}
