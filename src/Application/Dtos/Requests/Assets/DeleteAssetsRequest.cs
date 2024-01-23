using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests.Assets
{
    public class DeleteAssetsRequest
    {
        [Required(ErrorMessage = "Asset Id is required")]
        public int Id { get; set; }
    }
}
