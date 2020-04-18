using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using smart_street_backend.Model;

namespace smart_street_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private DatabaseContext _context;
        public ProductsController(DatabaseContext context){
            _context = context;
        }
        [HttpGet]
        public IActionResult getProducts()
        {
            return Ok(_context.products);
        }

        [HttpGet("get-categories")]
        public IActionResult getCategories(){
            return Ok(_context.catergories);
        }

        [HttpPost("create-catergories")]
        public IActionResult createCategory([FromBody] catergory catergory){
            catergory catergory1 = new catergory{
                name = catergory.name
            };
            _context.Add(catergory1);
            _context.SaveChanges();

            return Ok("created");
        }

        [HttpGet("get-supplier-product/{id}")]
        public IActionResult getSupplier(int id){
            return Ok(_context.products.Where(x => x.supplierId == id));
        }

        [HttpPost("add-product")]
        public IActionResult addProduct([FromBody] product product){

            supplier supplier = _context.suppliers.FirstOrDefault(x => x.Id == product.supplierId);
            catergory catergory = _context.catergories.FirstOrDefault(x => x.Id == product.catergoryID);

            product product1 = new product{
                name = product.name,
                description = product.description,
                price = product.price,
                stockCount = product.stockCount,
                Supplier = supplier,
                Catergory = catergory
            };

            try
            {
                _context.Add(product1);
                _context.SaveChanges();
                return Ok("product added");
            }
            catch (System.Exception)
            {
                return BadRequest("something went wrong");
            }
        }

    }
}
