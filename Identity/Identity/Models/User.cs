using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(15,ErrorMessage ="Adin uzunluqu 15 herfden cox ola bilmez")]
        [Required(ErrorMessage ="Ad Yazmalisiz")]
       
        public string Username { get; set; }
       
        [Required(ErrorMessage = "Email Yazmalisiz")]
        [EmailAddress(ErrorMessage ="Email Duzgun Yazin")]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Parol yazin")]
      
        public string Password { get; set; }

       
        public string Token { get; set; }
    }
}