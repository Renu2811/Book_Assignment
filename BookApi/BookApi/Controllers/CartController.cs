using BookDetails;
using BookDetails.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class CartController : ControllerBase
        {
            private readonly BookDbContext _cartcontext;


            public CartController(BookDbContext cartcontext)
            {
                _cartcontext = cartcontext;

            }
            [HttpPost]
            public ActionResult Addcart(AddCart addCart)
            {
                if (addCart == null)
                {
                    return BadRequest();
                }
                else
                {
                    _cartcontext.Cart.Add(addCart);
                    _cartcontext.SaveChanges();
                    return Ok(_cartcontext.Cart);
                }
            }
            [HttpGet]
            public ActionResult Index()
            {
                var employees = _cartcontext.Cart.ToList();
                _cartcontext.SaveChanges();
                if (employees != null)
                {
                    string jsondata = JsonConvert.SerializeObject(employees);
                    return Ok(jsondata);
                }
                else
                {
                    return NotFound();
                }
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
                    var delbook = _cartcontext.Cart.Find(id);
                    _cartcontext.Cart.Remove(delbook);
                    _cartcontext.SaveChanges();
                    return Ok("Deleted Successfully");
                }

            }
        }
    }


