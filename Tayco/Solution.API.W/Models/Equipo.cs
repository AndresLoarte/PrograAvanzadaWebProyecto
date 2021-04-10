using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class Equipo
    {
        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; }
        public int Cantidad { get; set; }
        public int TipoEquipoId { get; set; }
        public bool Estado { get; set; }

        public virtual TipoEquipo TipoEquipo { get; set; }
    }
}
