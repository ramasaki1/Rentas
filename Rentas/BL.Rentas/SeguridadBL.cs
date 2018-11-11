using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class SeguridadBL
    {
        contexto _contexto;

        public SeguridadBL()
        {
            _contexto = new contexto();
        }

        public bool Autorizar(string usuario, string contrasena)
        {
             var usuarios = _contexto.Usuario.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && contrasena == usuarioDB.Contrasena)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}

