

namespace SingularSystemKiosk.Dtos.ProductsDto
{
    using System.ComponentModel.DataAnnotations;
    using SingularSystemKiosk.Models;
    public class ProductsDto
    {

        
        public int ProductId { get; set; }
        [Required]

        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
        [Required]

        public string Image { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Category Id must be greater than 0")]
        public int CategoryId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Supplier Id must be greater than 0")]
        public int SupplierId { get; set; }
        [Required]


        public bool Available { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public decimal Price { get; set; }
     
       




        public   Products DtoToEntity(ProductsDto productsDto)
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









        public static ProductsDto EntityToDto(Products product)
        {
            if (product == null) return null;

            return new ProductsDto
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        // Map a list of Product entities to a list of ProductDto
        public static List<ProductsDto> EntityToDto(List<Products> products)
        {
            var result = new List<ProductsDto>();

            foreach (var product in products)
            {
                result.Add(EntityToDto(product));
            }

            return result;
        }











    }
}

