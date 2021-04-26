using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Administrador
    {
       
            public int AdministradorID { get; set; }
            public string NombreAdministrador { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string Correo { get; set; }
            public int? Telefono { get; set; }
            public bool? Estado { get; set; }
            public int? UsuarioId { get; set; }

            public virtual Users Usuario { get; set; }
        
    }
}
