using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using data = FrontEnd.API.Models;

namespace FrontEnd.API.Controllers
{
    public class GraficoController1 : Controller
    {

        string baseurl = "http://localhost:30091/";

        public IActionResult Index()
        {
            return View();
        }

       

    }
}
