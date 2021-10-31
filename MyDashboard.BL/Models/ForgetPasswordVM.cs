using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invaled Email")]
        public string Email { get; set; }
    }
}
