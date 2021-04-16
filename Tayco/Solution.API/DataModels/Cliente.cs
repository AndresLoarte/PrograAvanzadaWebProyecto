using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Cliente
    {

        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public bool Estado { get; set; }
        public int? UsuarioId { get; set; }

        public Users Usuario { get; set; }
        //public ICollection<Reserva> Reserva { get; set; }

    }
}
