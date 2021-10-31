using Microsoft.AspNetCore.Mvc;
using MyDashboard.BL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDashboard.Controllers
{
    public class MailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string Title, string Msg)
        {
            TempData["Message"] = MailSender.Mail(Title, Msg);
            return View();
        }
    }
}
