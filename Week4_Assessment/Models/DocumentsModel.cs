using System.ComponentModel.DataAnnotations;

namespace Text_Editor.Models
{
    public class DocumentsModel
    {
        [Key]
        [Required]
        public int doc_id { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public DateTime created_date { get; set; }


        [Required]
        public DateTime last_edited { get; set; }

        [Required]
        public string doc_title { get; set; }

        [Required]
        public string doc_content{ get; set; }
    }
}
