using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyDashboard.BL.Models
{
    public class RegistrationVM
    {
        [Required (ErrorMessage = "User Name Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invaled Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [StringLength(20,ErrorMessage ="Min Length 10 Character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(20, ErrorMessage = "Min Length 10 Character")]
        [Compare("Password" , ErrorMessage ="Password Doesn't Match")]
        public string ConfirmPasword { get; set; }
    }
}
