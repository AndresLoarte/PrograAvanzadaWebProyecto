using FrontEnd.W.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.W.Controllers
{
    public class LoginController : Controller
    {

        private readonly TaycoContext _context;

        public LoginController(TaycoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Users user = new Users();
            return View(user);
        }

       
    }
}
