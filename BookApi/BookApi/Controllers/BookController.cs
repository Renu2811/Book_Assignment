using BookDetails;
using BookDetails.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BookApi.Controllers

{
   
        [Route("api/[controller]")]
        [ApiController]
        public class BookController : ControllerBase
        {
            private readonly BookDbContext _bookDbContext;
        public BookController(BookDbContext bookDbContext)
            {
                _bookDbContext = bookDbContext;
            }
            [HttpPost]
            public ActionResult Create(Book book)
            {
                if (book == null)
                {
                    return BadRequest();
                }
                else
                {
                    _bookDbContext.Books.Add(book);
                    _bookDbContext.SaveChanges();
                    return Ok("Created Successfully");
                }
            }
            [HttpPut]
            public IActionResult UpdateBook(int BookId, Book book)
            {
                if (book == null)
                {
                    return BadRequest("Book object can't be null");
                }
                if (_bookDbContext == null)
                {
                    return NotFound("Table doesn't exists");
                }
                var Update = _bookDbContext.Books.Where(e => e.BookId == BookId).FirstOrDefault();
                if (Update == null)
                {
                    return NotFound("Book with this BookId doesn't exists");
                }
                _bookDbContext.Books.Remove(Update);
                Update.BookName = book.BookName;
                Update.BookZoner = book.BookZoner;
                Update.RelaseDate = book.RelaseDate;
                Update.Cost = book.Cost;
                Update.BookImage = book.BookImage;

                _bookDbContext.Books.Update(Update);
                _bookDbContext.SaveChanges();

                return Ok(_bookDbContext.Books);
            }
            [HttpGet]
            public ActionResult<IEnumerable<Book>> GetBooks()
            {
                return Ok(_bookDbContext.Books);
            }
            [HttpDelete("id")]
            public ActionResult Delete(int id)
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                else
                {
                    var delbook = _bookDbContext.Books.Find(id);
                    _bookDbContext.Books.Remove(delbook);
                    _bookDbContext.SaveChanges();
                    return Ok("Deleted Successfully");
                }

            }
            [HttpGet("{searchString}")]

            public async Task<IActionResult> Show(string searchString)
            {
                if (searchString == null)
                {
                    return BadRequest("input can't be null");
                }
                if (_bookDbContext.Books == null)
                {
                    return NotFound("Table doesn't exists");
                }
                var books = _bookDbContext.Books.Where(e => e.BookName.Contains(searchString) || e.BookZoner.Contains(searchString)).ToList();
                if (books == null)
                {
                    return NotFound("Record doesn't exists");
                }
                return Ok(books);
            }

        [HttpGet("id")]
        public async Task<ActionResult> GetbyId(int id)
        {
            if (_bookDbContext.Books == null)
            {
                return NoContent();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var book = await _bookDbContext.Books.FindAsync(id);
            return Ok(book);

        }
    }
    }

