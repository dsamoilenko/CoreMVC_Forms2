using CoreMVC_Forms2.Models;
using System.ComponentModel.DataAnnotations;

namespace CoreMVC_Forms2.ViewModels
{
    public class BookFormViewModel
    {
        [Display(Name = "Жанр книги")]
        public IEnumerable<Genre> Genres { get; set; }

        public Book Book { get; set; }
    }
}
