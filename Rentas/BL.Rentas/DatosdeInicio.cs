using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<contexto>
    {
        protected override void Seed(contexto contexto)
        {
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuario.Add(usuarioAdmin);

            var ciudad1 = new Ciudad();
            ciudad1.Descripcion = "SPS";
            contexto.Ciudad.Add(ciudad1);

            var ciudad2 = new Ciudad();
            ciudad2.Descripcion = "El Progreso";
            contexto.Ciudad.Add(ciudad2);

            var ciudad3 = new Ciudad();
            ciudad3.Descripcion = "La Lima";
            contexto.Ciudad.Add(ciudad3);

            var ciudad4 = new Ciudad();
            ciudad4.Descripcion = "Santa Rita";
            contexto.Ciudad.Add(ciudad4);

            /*  var cliente2 = new Cliente();
              cliente2.Nombre = "Tony Stark";
              contexto.Clientes.Add(cliente2);*/

            base.Seed(contexto);
        }
    }
}
