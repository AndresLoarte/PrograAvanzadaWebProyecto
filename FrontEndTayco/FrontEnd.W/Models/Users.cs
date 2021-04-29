using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class Users
    {

        [TempData]
        public string ErrorMessage { get; set; }

        public Users()
        {
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        [Required(ErrorMessage = "Favor digitar un nombre de usuario")]
        public int UserId { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Favor digitar nombre")]
        [RegularExpression("[a-zA-Z ]{2,254}", ErrorMessage = "Solo se permiten letras")]
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Favor digitar nombre")]
        [RegularExpression("[a-zA-Z ]{2,254}", ErrorMessage = "Solo se permiten letras")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "Favor digitar nombre")]
        [RegularExpression("[a-zA-Z ]{2,254}", ErrorMessage = "Solo se permiten letras")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Favor digitar el correo electronico")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El correo debe de contener un formato correcto")]
        public string Correo { get; set; }

        [RegularExpression("^[0-9]{8,}$", ErrorMessage = "El numero de teléfono debe contener 8 o más digitos")]
        [Required(ErrorMessage = "Favor digitar el numero de teléfono")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Favor digitar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Estado { get; set; }

        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
