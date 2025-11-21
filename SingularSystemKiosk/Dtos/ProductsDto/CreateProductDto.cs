
namespace SingularSystemKiosk.Dtos.ProductsDto
{
    using System.ComponentModel.DataAnnotations;
    using SingularSystemKiosk.Models;

    public class CreateProductDto
    {


        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(500, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public int CategoryId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public int SupplierId { get; set; }
        [Required]

        public bool Available { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }
        public Products DtoToEntity(CreateProductDto productsDto)
        {

            Products newProduct = new Products()
            {



                Name = productsDto.Name,
                Description = productsDto.Description,
                Image = productsDto.Image,
                CategoryId = productsDto.CategoryId,
                SupplierId = productsDto.SupplierId,
                Available = productsDto.Available,
                Quantity = productsDto.Quantity,
                Price = productsDto.Price,
                CreatedAt = DateTime.Now,



            };

            return newProduct;

        }


        public ProductsDto EntityToDto(Products products)
        {



            ProductsDto newProdDto = new ProductsDto()
            {
                Name = products.Name,
                Description = products.Description,
                Image = products.Image,
                CategoryId = products.CategoryId,
                SupplierId = products.SupplierId,
                Available = products.Available,
                Quantity = products.Quantity,
                Price = products.Price,


            };
            return newProdDto;
        }
    }
}
