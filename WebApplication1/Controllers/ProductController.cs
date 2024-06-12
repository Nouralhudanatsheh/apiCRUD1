using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        List<Product> products = new List<Product>() { 
        
        new Product{ Id = 1, Name = "phone", Description = "iphone"},
        new Product{ Id = 2, Name = "shirt", Description = "three colors"},
        new Product{ Id = 3, Name = "paper", Description = "white"},

        };

        //get
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);

        }

        //get by id

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.First(product => product.Id == id);
            if (product is null)
                return NotFound();
            return Ok(product);

        }

        //new product

        [HttpPost]
        public IActionResult Add(Product request)
        {

            if (request is null)
                return BadRequest();
            var product = new Product { Id = request.Id, Name = request.Name, Description = request.Description };
            products.Add(product);
            return Ok(product);
        }

        //update

        [HttpPut("{id}")]

        public IActionResult Update(int id, Product request)
        {

            var currentProduct = products.FirstOrDefault(product => product.Id == request.Id);
            if (currentProduct is null)
                return NotFound();

            currentProduct.Name = request.Name;
            currentProduct.Description = request.Description;

            return Ok(currentProduct);
        }

        //delete

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product is null)
                return NotFound();

            products.Remove(product);
            return Ok();

        }
    }




}
