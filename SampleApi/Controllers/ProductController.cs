using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Core;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<ProductEntity> products = new List<ProductEntity>(){
                new ProductEntity{Id=1, Name="Mobile Phone",Price="10000"},
                new ProductEntity{Id=2, Name="Desktop Computer",Price="20000"},
                new ProductEntity{Id=3, Name="Laptop",Price="25000"},
                new ProductEntity{Id=4, Name="Headphone",Price="350"},
                new ProductEntity{Id=5, Name="Keyboard",Price="500"}
            };
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(int Id)
        {
            var product = products.Find(x => x.Id == Id);
            if (product == null)
                return BadRequest("No product Id");
            return Ok(product);
        }

    }
}
