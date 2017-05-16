using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DuneBuggy.Businesslayer.Models
{
    public class Product
    {             

        [Key]
        public int product_id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        //[MinLength(ValidationConstants.MinimumNameLength)]
        //[MaxLength(ValidationConstants.MaximumNameLength)]
        public string product_name { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        public string product_description { get; set; }

        [Required]
        [Display(Name = "Product Cost")]
        public string product_cost { get; set; }

        [Required]
        [Display(Name = "Product Added")]
        public DateTime product_added { get; set; }    
                
        [Display(Name = "Product Image")]
        public string product_image { get; set; }

    }
}
