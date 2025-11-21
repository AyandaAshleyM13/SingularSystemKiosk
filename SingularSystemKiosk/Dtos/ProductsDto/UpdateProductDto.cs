
namespace SingularSystemKiosk.Dtos.ProductsDto
{
    using System.ComponentModel.DataAnnotations;
    using SingularSystemKiosk.Models;

    public class UpdateProductDto
    {

        [Required]
        public int ProductId { get; set; }
        [Required]

        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        [Required]

        public int SupplierId { get; set; }
        [Required]


        public bool Available { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Products DtoToEntity(ProductsDto productsDto)
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
