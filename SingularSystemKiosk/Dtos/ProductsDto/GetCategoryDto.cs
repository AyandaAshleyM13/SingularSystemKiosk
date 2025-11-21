using System.ComponentModel.DataAnnotations;

namespace SingularSystemKiosk.Dtos.ProductsDto
{
    public class GetCategoryDto
    {
        [Required]
        [StringLength(20)]
        public string categoryName { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;




    }
}
