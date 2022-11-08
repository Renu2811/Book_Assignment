using BookMVCWebApi.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookMVCWebApi.Api.Controllers
{
    public class BookController : Controller
    {

        Uri baseuri = new Uri("https://localhost:7255/api");
        HttpClient client = new HttpClient();


        List<BookViewModel> bookList = new List<BookViewModel>();


        public IActionResult Index()
        {
            client.BaseAddress = baseuri;
            HttpResponseMessage response = client.GetAsync(baseuri + "/Book").Result;
            if (response.IsSuccessStatusCode)
            {
                string bookData = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<BookViewModel>>(bookData); ;

            }

            return View(bookList);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(BookViewModel books)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7255/api/Book");
                var postTask = client.PostAsJsonAsync<BookViewModel>("Book",books);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
               
            }
            ModelState.AddModelError(string.Empty, "server error");
            return View(books);

        }

        
  

        public ActionResult Edit(int id)
        {
            client.BaseAddress = baseuri;
            HttpResponseMessage response = client.GetAsync(baseuri + "/Book").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            bookList = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            var book = bookList.Where(e => e.bookId == id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public IActionResult Save(BookViewModel books)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7255/api/");
                var put = client.PutAsJsonAsync($"Book?BookId={books.bookId}", books);
                put.Wait();
                var result = put.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "server error");
            return View();

        }

        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7255/api/Book/");
                var delete = client.DeleteAsync($"id?id={id}");
                delete.Wait();
                var result = delete.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "server error");
            return View();

        }

        public ActionResult Search(string searchString)
        {
            List<BookViewModel> bookList = new List<BookViewModel>();
            HttpResponseMessage response = client.GetAsync(baseuri + "/Book/" + searchString).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }
            return View("Index", bookList);
        }

        public ActionResult Details(int id)
        {
            client.BaseAddress = baseuri;
            HttpResponseMessage response = client.GetAsync(baseuri + $"/Book/id?id={id}").Result;
            string data = response.Content.ReadAsStringAsync().Result;
            var book = JsonConvert.DeserializeObject<BookViewModel>(data);
            return View(book);

        }

    }
}
