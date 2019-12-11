using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbdielClub.Models
{
    public class Login
    {
        [Key]
        public string User { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }
    }
}