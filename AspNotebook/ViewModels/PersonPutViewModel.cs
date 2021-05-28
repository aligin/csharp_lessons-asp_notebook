﻿using System.ComponentModel.DataAnnotations;

namespace AspNotebook.ViewModels
{
    public class PersonPutViewModel
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Telephone { get; set; }
    }
}
