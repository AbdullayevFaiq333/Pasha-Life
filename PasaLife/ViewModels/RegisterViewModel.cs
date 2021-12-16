using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PasaLife.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required,DataType(DataType.Password)]
        public string Passsword { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Passsword))]
        public string ConfirmPassword { get; set; }


    }
}
