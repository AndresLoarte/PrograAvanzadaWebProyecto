using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class Bitacora
    {
        public int BitacoraId { get; set; }
        public string UsuarioAplicacion { get; set; }
        public string AccionSistema { get; set; }
        public DateTime Fecha { get; set; }
    }
}
