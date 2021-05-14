using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_api.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Medicine Category")]
        public string CategoryName { get; set; }
    }
}
