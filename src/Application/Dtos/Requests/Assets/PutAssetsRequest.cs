using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests.Assets
{
    public class PutAssetsRequest
    {
        [Required(ErrorMessage = "Asset Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Asset name is required")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "Symbol is required")]
        public string? Symbol { get; set; }

        [Required(ErrorMessage = "AvailableQuantity is required")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
