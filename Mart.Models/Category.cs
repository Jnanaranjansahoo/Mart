using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mart.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
    }
}
