using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ProveedoresBL
    {
        public BindingList<Proveedor> ListaProveedores { get; set; }
        public ProveedoresBL()
        {
            ListaProveedores = new BindingList<Proveedor>();

            var proveedor1 = new Proveedor();
            proveedor1.ID = 1;
            proveedor1.Nombre = "Juan Perez";
            proveedor1.Telefono = "555";
            proveedor1.Correo = "a@unah.hn";
            proveedor1.Direccion = "SPS";
            proveedor1.Activo = true;

            ListaProveedores.Add(proveedor1);

            var proveedor2 = new Proveedor();
            proveedor2.ID = 2;
            proveedor2.Nombre = "Roney Morales";
            proveedor2.Telefono = "666";
            proveedor2.Correo = "b@unah.hn";
            proveedor2.Direccion = "Teguz";
            proveedor2.Activo = true;

            ListaProveedores.Add(proveedor2);

            var proveedor3 = new Proveedor();
            proveedor3.ID = 3;
            proveedor3.Nombre = "Angie Mendoza";
            proveedor3.Telefono = "444";
            proveedor3.Correo = "c@unah.hn";
            proveedor3.Direccion = "La Ceiba";
            proveedor3.Activo = true;

            ListaProveedores.Add(proveedor3);
        }

        public BindingList<Proveedor> ObtenerProveedor()
        {
            return ListaProveedores;
        }

        public bool GuardarProveedor(Proveedor proveedor)
        {
            if(proveedor.ID==0)
            {
                proveedor.ID = ListaProveedores.Max(item => item.ID) + 1;
            }
            return true;
        }

        public void AgregarProveedor()
        {
            var nuevoProveedor = new Proveedor();
            ListaProveedores.Add(nuevoProveedor);
        }

        public bool EliminarProveedor(int ID)
        {
            foreach (var proveedor in ListaProveedores)
            {
                ListaProveedores.Remove(proveedor);
                return true;
            }
            return false;
        }
    }


    public class Proveedor
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
    }
}
