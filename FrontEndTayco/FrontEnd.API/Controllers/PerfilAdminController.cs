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
    public class PerfilAdminController : Controller
    {

        string baseurl = "http://localhost:30091/";

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = GetById(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }


        private data.Administrador GetById(int? id)
        {
            data.Administrador aux = new data.Administrador();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Administrador/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.Administrador>(auxres);
                }
            }
            return aux;
        }



    }
}
