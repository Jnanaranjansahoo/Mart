//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

//namespace Mart.Models
//{
//    public class Product
//    {
//        [Key]
//        public int Id { get; set; }
//        [Required]
//        [Display(Name = "Name")]
//        public string? Name { get; set; }
//        [Display(Name = "Description")]
//        public string? Description { get; set; }
//        [Required]
//        [Display(Name = "Price for")]
//        public double? Price { get; set; }
//        public int CategoryId { get; set; }
//        [ValidateNever]
//        [ForeignKey("CategoryId")]
//        public Category? Category { get; set; }
//        public int CompanyId { get; set; }
//        [ValidateNever]
//        [ForeignKey("CompanyId")]
//        public Company? Company { get; set; }
//        [ValidateNever]
//        public string? ImageUrl { get; set; }
//    }
//}
