using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models.Dtos
{
    public class CategoryDto
    {
        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }

        public DateTime Created_at { get; set; }


    }
}
