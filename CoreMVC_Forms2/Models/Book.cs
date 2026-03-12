using System.ComponentModel.DataAnnotations;

namespace CoreMVC_Forms2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Название книги")]
        public String Title { get; set; }

        [Display(Name = "Автор книги")]
        public String Author { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PubDate { get; set; }

        public int Price { get; set; }

        public Boolean hasAudioBook { get; set; }
    }
}
