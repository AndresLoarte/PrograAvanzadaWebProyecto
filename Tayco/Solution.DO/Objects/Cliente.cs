using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Cliente
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
}
