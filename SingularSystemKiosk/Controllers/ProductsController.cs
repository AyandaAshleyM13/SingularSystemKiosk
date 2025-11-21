
namespace SingularSystemKiosk.Controllers
{
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SingularSystemKiosk.Data;
    using SingularSystemKiosk.Dtos.ProductsDto;
    using SingularSystemKiosk.Models;

    [ApiController]
    public class ProductsController : BaseController
    {

        public ProductsController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
     : base(appDbContext, userManager, signInManager, roleManager)
        {
        }

        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAllProducts()//PascalCase
        {

           var products=  await this._appDbContext.Products.ToListAsync();

           List<ProductsDto> productsDtos= ProductsDto.EntityToDto(products);

            return Ok(productsDtos);
        }

        [HttpGet(), Route("GetProductById")]
          public async Task<IActionResult> GetProductById(int id)//PascalCase
        {

            if (id == 0||id<0)
            {

                return BadRequest("Id cannot be zero or less");
            }

            Products? products = await this._appDbContext.Products.FindAsync(id);

            if(products == null)
            {

                return NotFound();


            }

           ProductsDto productsDtos = ProductsDto.EntityToDto(products);

            return Ok(productsDtos);
        }

        [HttpPost, Route("AddProduct")]
        public async Task<IActionResult> AddProducts([FromBody] CreateProductDto productsDto)
        {

            if (!ModelState.IsValid)
            {

               return BadRequest(ModelState);

            }


            Products products = productsDto.DtoToEntity(productsDto);

           var result=await _appDbContext.Products.AddAsync(products);
            await _appDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProductById), new { id = products.Id },
            products);
        }
        [HttpPut("UpdateProducts/{id}")]
        public async Task<IActionResult> UpdateProducts(int id, [FromBody] UpdateProductDto productsDto)
        {

            if (!ModelState.IsValid)
            {

              return  BadRequest(ModelState);

            }

            if (id == 0 || id < 0)
            {

                return BadRequest("Id cannot be zero or less");
            }

            Products? existingProduct = await this._appDbContext.Products.FindAsync(id);

            if (existingProduct == null)
            {

                return NotFound();


            }


            existingProduct.Name = productsDto.Name;
            existingProduct.Image = productsDto.Image;
            existingProduct.Quantity = productsDto.Quantity;
            existingProduct.Price = productsDto.Price;
            existingProduct.CategoryId = productsDto.CategoryId;
            existingProduct.SupplierId = productsDto.SupplierId;
            existingProduct.Available = productsDto.Available;
            existingProduct.Description = productsDto.Description;
            
            
        
            var resulto= await this._appDbContext.SaveChangesAsync();

            ProductsDto productsDtos = ProductsDto.EntityToDto(existingProduct);


            return Ok(productsDtos);
        }
        [HttpDelete("DeleteProducts/{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {

            if (!ModelState.IsValid)
            {

              return  BadRequest(ModelState);

            }

            if (id == 0 || id < 0)
            {

                return BadRequest("Id cannot be zero or less");
            }

            Products? existingProduct = await this._appDbContext.Products.FindAsync(id);

            if (existingProduct == null)
            {

                return NotFound();


            }




            var result = this._appDbContext.Products.Remove(existingProduct);


            await _appDbContext.SaveChangesAsync();
            return Ok($"Product with Id {id} deleted successfully");
        }


        [HttpGet("by-category")]
        public async Task<IActionResult> GetProductsByCategory([FromQuery] GetCategoryDto getCategoryDto)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }


            if (getCategoryDto.PageNumber<=0||getCategoryDto.PageSize <= 0||getCategoryDto.PageSize>100)
            {
                return BadRequest("Invalid Pagination Values");
            }

            Category? existingCategory=await this._appDbContext.Categories.FirstOrDefaultAsync(c => c.Name == getCategoryDto.categoryName);
            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }




            var existingProducts =  _appDbContext.Products
                .Where(p => p.CategoryId == existingCategory.Id)
                .OrderBy(p => p.Name);


            if (existingProducts == null)
            {

                return NotFound("There are No Products under that Specified Category");


            }

            var totalItems = await existingProducts.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double) getCategoryDto.PageSize);

            var products= await existingProducts.Skip((getCategoryDto.PageNumber-1)*getCategoryDto.PageSize).Take(getCategoryDto.PageSize)
                .ToListAsync();

            List<ProductsDto> productsDtos = ProductsDto.EntityToDto(products);

            return Ok(new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                PageNumber = getCategoryDto.PageNumber,
                PageSize = getCategoryDto.PageSize,
                Items = productsDtos
            });


            
        }



    }
}
