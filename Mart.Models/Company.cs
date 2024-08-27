using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MartWeb.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Company Name")]
        public string? Name { get; set; }
    }
}
