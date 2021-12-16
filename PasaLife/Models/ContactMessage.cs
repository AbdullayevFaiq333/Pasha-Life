using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ContactMessage
    {
        [Required(ErrorMessage ="Ad ve soyad  qeyd edilmelidir")]

        public string FullName { get; set; }
        [Required(ErrorMessage ="Mobil nomre qeyd edilmelidir")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email qeyd edilmelidir")]
        [EmailAddress(ErrorMessage = "Email yanlishdir")]

        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "Mesaj bolmesi qeyd edilmelidir")]

        public string Message { get; set; }
    }
}
