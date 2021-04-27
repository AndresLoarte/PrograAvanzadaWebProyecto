using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class TipoEquipo
    {
        public TipoEquipo()
        {
            Equipo = new HashSet<Equipo>();
        }

        public int TipoEquipoId { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<Equipo> Equipo { get; set; }
    }
}
