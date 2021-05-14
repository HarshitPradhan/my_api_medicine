using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace my_api.Models
{
    public class Medicine
    {

        public int Id { get; set; }


        [Required]
        [Display(Name = "Medicine Name")]
        public string Name { get; set; }


        [Required]
        public decimal Price { get; set; }


        public string Image { get; set; }


        [Required]
        public string Seller { get; set; }

        public string Description { get; set; }





        [Display(Name = "Category")]
        [Required]

        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


    }
}
