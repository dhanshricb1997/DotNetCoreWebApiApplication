using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebApiApplication.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string productDescription { get; set; }
    }
}
