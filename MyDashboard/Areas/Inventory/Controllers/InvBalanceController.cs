using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDashboard.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InvBalanceController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
