using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Requests.Assets
{
    public class DeleteAssetsRequest
    {
        [Required(ErrorMessage = "Asset Id is required")]
        public int Id { get; set; }
    }
}
