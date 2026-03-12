using CoreMVC_Forms2.Models;
using CoreMVC_Forms2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC_Forms2.Controllers
{
    public class BooksController : Controller
    {
        public static Books books = new Books();

        public IActionResult Index()
        {
            //return Content("Hello world!");

            //string htmlContent = "<h1>Hello World!</h1>";
            //return Content(htmlContent, "text/html");

            //string xmlContent = "<test>Hello World!<ok/></test>";
            //return Content(xmlContent, "text/xml");

            //return new NotFoundResult();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { param = "test1"});

            return View(books);
        }

        // GET: Books/Details/1
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                id = 1;

            var book = books.SingleOrDefault(c => c.Id == id);

            return View(book);
        }

        [Route("books/{id:regex(^\\d+$)}")]
        public ActionResult BookById(int? id)
        {
            if (!id.HasValue)
                id = 1;

            var book = books.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return new NotFoundResult();

            return View(book);
        }

        [Route("books/released/{year:range(1900, 2100)}")]
        public ActionResult BooksByYear(int year)
        {
            var filteredBooks = from p in books
                                where p.PubDate.Year == year
                                select p;
            return View(filteredBooks);
        }

        [Route("books/genre/{genre:regex(^(Poetry|Drama|Sci-fi|Roman)$)}")]
        public ActionResult BooksByGenre(String genre)
        {
            var filteredBooks = from p in books
                                where p.Genre.Equals(genre)
                                select p;
            return View(filteredBooks);
        }

        public ActionResult New()
        {
            var book = new Book();

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = new List<Genre>
                {
                    new Genre {Id = 1, Name = "Poetry" },
                    new Genre {Id = 3, Name = "Drama" },
                    new Genre {Id = 4, Name = "Sci-fi" },
                    new Genre {Id = 5, Name = "Novel" },
                    new Genre {Id = 6, Name = "Comedy" },
                    new Genre {Id = 7, Name = "Detective" }
                }
            };

            return View("BookForm", viewModel);
        }

        // GET: Books/Edit/1
        public ActionResult Edit(int? id)
        {
            ViewBag.Test = "Hello big world!!!";
            ViewData["MyMessage"] = "My message to you!!!";

            if (!id.HasValue)
                id = 1;

            var book = books.SingleOrDefault(c => c.Id == id);

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = new List<Genre>
                {
                    new Genre {Id = 1, Name = "Poetry" },
                    new Genre {Id = 3, Name = "Drama" },
                    new Genre {Id = 4, Name = "Sci-fi" },
                    new Genre {Id = 5, Name = "Novel" },
                    new Genre {Id = 6, Name = "Comedy" },
                    new Genre {Id = 7, Name = "Detective" }
                }
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Book book)
        {
            // создаётся новая книга
            if (book.Id == 0)
            {
                book.Id = books.Id++;
                if (book.Title == null || book.Author == null || book.Genre == null)
                    return RedirectToAction("Index", "Books");
                books.Add(book);
            }
            else    // сохранение книги после редактирования
            {
                var bookInDB = books.Single(c => c.Id == book.Id);

                bookInDB.Title = book.Title;
                bookInDB.Author = book.Author;
                if (book.Genre != null)
                    bookInDB.Genre = book.Genre;
                bookInDB.PubDate = book.PubDate;
                bookInDB.Price = book.Price;
                bookInDB.hasAudioBook = book.hasAudioBook;
            }

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Delete(int? id)
        {
            var bookInDB = books.Single(c => c.Id == id);
            if (bookInDB != null)
            {
                books.Remove(bookInDB);
            }

            return RedirectToAction("Index", "Books");
        }
    }
}
