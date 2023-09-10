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
        public async Task<ActionResult<List<ProductEntity>>> Get()  // Bring the all product in the Product List
        {
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductEntity>> Get(int Id)  // Bring the product of Determined Id
        {
            var product = products.Find(x => x.Id == Id); // It searches one by one until it found finally bring the product or return bad request.
            if (product == null)
                return BadRequest("No product Id");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)  // Let us add the new product on the List
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity request)
        {
            var product = products.Find(x => x.Id == request.Id);
            if (product == null)
                return BadRequest("No Id it will be changed");
            product.Name = request.Name; ;
            product.Price = request.Price;
            return Ok(products);
        }
        [HttpDelete]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int Id)
        {
            var product = products.Find( x => x.Id == Id);
            if (product == null)
                return BadRequest("No Id it will be deleted");
            products.Remove(product);
            return Ok(products);
        }
        

    }
}
