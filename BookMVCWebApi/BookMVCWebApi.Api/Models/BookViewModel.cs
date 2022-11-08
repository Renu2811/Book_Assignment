using System.ComponentModel.DataAnnotations;

namespace BookMVCWebApi.Api.Models
{
    public class BookViewModel
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookZoner { get; set; }

        [DataType(DataType.Date)]
        public DateTime relaseDate { get; set; }
        public int cost { get; set; }
        public string bookImage { get; set; }
    }
}
