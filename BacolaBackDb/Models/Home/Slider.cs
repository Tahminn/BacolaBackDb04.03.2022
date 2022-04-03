using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BacolaBackDb.Models.Home
{
    public class Slider : BaseEntity
    {
        public string Image { get; set; }
        public string? Description { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
