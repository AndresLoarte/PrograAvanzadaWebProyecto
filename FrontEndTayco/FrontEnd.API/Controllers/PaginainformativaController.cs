using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.API.Controllers
{
    public class PaginainformativaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
