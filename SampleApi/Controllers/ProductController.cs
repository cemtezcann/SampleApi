using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Core;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> Get()  // Bring the all product in the Product List
        {
            return Ok(await _context.productEntities.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductEntity>> Get(int Id)  // Bring the product of Determined Id
        {
            var product = await _context.productEntities.FindAsync(Id); // It searches one by one until it found finally bring the product or return bad request.
            if (product == null)
                return BadRequest("No product Id");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)  // Let us add the new product on the List
        {
            _context.productEntities.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.productEntities.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity request)
        {
            var product = await _context.productEntities.FindAsync(request.Id);
            if (product == null)
                return BadRequest("No Id it will be changed");
            product.Name = request.Name; ;
            product.Price = request.Price;
            await _context.SaveChangesAsync();
            return Ok(await _context.productEntities.ToListAsync());
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int Id)
        {
            var product = await _context.productEntities.FindAsync(Id);
            if (product == null)
                return BadRequest("No Id it will be deleted");
            _context.productEntities.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.productEntities.ToListAsync());
        }
        

    }
}
