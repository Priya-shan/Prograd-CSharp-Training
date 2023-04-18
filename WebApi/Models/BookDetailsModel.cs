namespace WebApi.Models
{
    public class BookDetailsModel
    {
        public string book_code { get; set; }

        public string book_title { get; set; }
        public string category { get; set; }
        public string author { get; set;}
        public string publication { get; set; }

        public double price { get; set; }
        public int rem_quantity { get; set; }

        public int sold_quantity { get; set; }
    }
}
