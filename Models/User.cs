﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace quick_asp_api_sample.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age from 1 to 100")]
        public int Age { get; set; }
    }
}
