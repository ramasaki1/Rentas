using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
        public BindingList<Cliente> ListaClientes { get; set; }

        public ClientesBL()
        {
            ListaClientes = new BindingList<Cliente>();

            var cliente1 = new Cliente();
            cliente1.ID = 1;
            cliente1.Nombre = "Daniel Ramirez";
            cliente1.Correo_Electronico = "dramirez@unah.hn";
            cliente1.Telefono = "5550055";
            cliente1.Direccion = "SPS";

            var cliente2 = new Cliente();
            cliente2.ID = 2;
            cliente2.Nombre = "Andrea Guachon";
            cliente2.Correo_Electronico = "guachon_a@unah.hn";
            cliente2.Telefono = "666";
            cliente2.Direccion = "Brisas del Carmen";

            var cliente3 = new Cliente();
            cliente3.ID = 3;
            cliente3.Nombre = "Roney Morales";
            cliente3.Correo_Electronico = "jalate_perro@unah.hn";
            cliente3.Telefono = "7872334";
            cliente3.Direccion = "Santa Rita";

            var cliente4 = new Cliente();
            cliente4.ID = 4;
            cliente4.Nombre = "Angie Bautista";
            cliente4.Correo_Electronico = "angie_bau@unah.hn";
            cliente4.Telefono = "45545555";
            cliente4.Direccion = "El Progreso";

            var cliente5 = new Cliente();
            cliente5.ID = 5;
            cliente5.Nombre = "Keyla Romero";
            cliente5.Correo_Electronico = "romero_keyla96@unah.hn";
            cliente5.Telefono = "7872345";
            cliente5.Direccion = "Choloma";

            ListaClientes.Add(cliente1);
            ListaClientes.Add(cliente2);
            ListaClientes.Add(cliente3);
            ListaClientes.Add(cliente4);
            ListaClientes.Add(cliente5);

        }

        public BindingList<Cliente> ObtenerClientes()
        {
            return ListaClientes;

        }

        public bool GuardarCliente(Cliente cliente)
        {
            if (cliente.ID == 0)
            {
                cliente.ID = ListaClientes.Max(item => item.ID) +1;
            }

            return true;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();

            ListaClientes.Add(nuevoCliente);

        }

        public bool EliminarCliente(int ID)
        {
            foreach (var cliente in ListaClientes)
            {
                if(cliente.ID == ID)
                {
                    ListaClientes.Remove(cliente);
                    return true;
                }

            }

            return false;
        }

    }

        public class Cliente
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Correo_Electronico { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public bool Activo { get; set; }

            public Cliente()
            {
                Activo = true;
            }
        }
    }

