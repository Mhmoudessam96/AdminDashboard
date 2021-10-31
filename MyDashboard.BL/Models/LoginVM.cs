using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Models
{
    public class LoginVM
    {
        //[Required(ErrorMessage = "Email Required")]
        //[EmailAddress(ErrorMessage = "Invaled Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password Required")]
        //[StringLength(10, ErrorMessage = "Min Length 10 Character")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
