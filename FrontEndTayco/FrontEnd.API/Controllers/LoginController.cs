using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.API.Models;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FrontEnd.API.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //TaycoContext ctx;

        //public LoginController(TaycoContext _ctx)
        //{
        //    ctx = _ctx;
        //}

        //[BindProperty]
        //public User Usuario { get; set; }


        //public async Task<IActionResult> Login()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new JObject() {
        //            { "StatusCode", 400 },
        //            { "Message", "El usuario ya existe, seleccione otro." }
        //        });
        //    }
        //    else
        //    {
        //        var result = await ctx.Users.Where(x => x.Nombre == Usuario.UserName).SingleOrDefaultAsync();
        //        if (result == null)
        //        {
        //            return NotFound(new JObject() {
        //                { "StatusCode", 404 },
        //                { "Message", "Usuario no encontrado." }
        //            });
        //        }
        //        else
        //        {

        //            var data = from u in ctx.Users
        //                       where u.UserName == Usuario.UserName
        //                             && u.Password == Usuario.Password
        //                       select new
        //                       {
        //                           u.UserName,
        //                           u.Password,
        //                           u.UserId
        //                       };

        //            if (data.Any())
        //            {
        //                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        //                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()));
        //                identity.AddClaim(new Claim(ClaimTypes.Name, result.Nombre));
        //                identity.AddClaim(new Claim(ClaimTypes.Email,result.Correo));
        //                identity.AddClaim(new Claim("Dato", "Valor"));
        //                var principal = new ClaimsPrincipal(identity);
        //                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
        //                    new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(2), IsPersistent = true });
        //                return Ok(result);
        //            }
        //            else
        //            {
        //                var response = new JObject() {
        //                    { "StatusCode", 403 },
        //                    { "Message", "Usuario o contraseña no válida." }
        //                };
        //                return StatusCode(403, response);
        //            }
        //        }
        //    }
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return Redirect("/Login");
        //}
    }
}
