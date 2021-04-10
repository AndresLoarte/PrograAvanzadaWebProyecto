using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public bool Estado { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Users Usuario { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
