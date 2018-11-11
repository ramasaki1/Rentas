using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class CiudadBL
    {
       contexto _contexto;

        public BindingList<Ciudad> ListaCiudades { get; set; }

        public CiudadBL()
        {
            _contexto = new contexto();
            ListaCiudades = new BindingList<Ciudad>();
        }

        public BindingList<Ciudad> ObtenerCategorias()
        {
            _contexto.Ciudad.Load();
            ListaCiudades = _contexto.Ciudad.Local.ToBindingList();

            return ListaCiudades;
        }
    }
    public  class Ciudad
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }

    }
}
