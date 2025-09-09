//This controller manages product-related API endpoints like CRUD operations
//It is used to interact with product data in the database
//All the action methods in this controller will use the UnitOfWork to perform database operations
//Unit of work further abstracts the data access layer and provides a more cohesive API for the controller
//Unit of work is responsible for managing the lifetime of the repositories and ensuring that all changes are saved in a single transaction

using RepositioryDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace RepositioryDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Enables attribute routing and model validation
    public class ProductsController : ControllerBase
    //Above class is responsible for handling product-related API endpoints
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Action methods go here
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.Products.AddAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.Products.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _unitOfWork.Products.RemoveAsync(product);
            return NoContent();
        }
    }
}