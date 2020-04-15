﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(250)]
        public string Location { get; set; }

        [Required]
        public CusineType Cusine { get; set; }
    }
}
