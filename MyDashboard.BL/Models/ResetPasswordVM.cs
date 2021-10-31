using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Models
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Password Required")]
        [StringLength(10, ErrorMessage = "Min Length 10 Character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(10, ErrorMessage = "Min Length 10 Character")]
        [Compare("Password", ErrorMessage = "Password Doesn't Match")]
        public string ConfirmPasword { get; set; }

        public string Token { get; set; }

        public string  Email{ get; set; }
    }
}
