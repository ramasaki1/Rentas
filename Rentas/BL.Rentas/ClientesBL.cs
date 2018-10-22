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
            cliente1.Id = 1;
            cliente1.Nombre = "Daniel Ramirez";
            cliente1.Email = "dr@unah.hn";
            cliente1.Telefono = "111";
            cliente1.Direccion = "SPS";

            ListaClientes.Add(cliente1);

            var cliente2 = new Cliente();
            cliente2.Id = 2;
            cliente2.Nombre = "Roney Morales";
            cliente2.Email = "rm@unah.hn";
            cliente2.Telefono = "222";
            cliente2.Direccion = "Santa Rita";

            ListaClientes.Add(cliente2);

            var cliente3 = new Cliente();
            cliente3.Id = 3;
            cliente3.Nombre = "Angie Bautista";
            cliente3.Email = "ab@unah.hn";
            cliente3.Telefono = "333";
            cliente3.Direccion = "El Progreso";

            ListaClientes.Add(cliente3);

            var cliente4 = new Cliente();
            cliente4.Id = 4;
            cliente4.Nombre = "Andrea Guadron";
            cliente4.Email = "ag@unah.hn";
            cliente4.Telefono = "444";
            cliente4.Direccion = "Choloma";

            ListaClientes.Add(cliente4);

            var cliente5 = new Cliente();
            cliente5.Id = 1;
            cliente5.Nombre = "Gabriela Ortiz";
            cliente5.Email = "go@unah.hn";
            cliente5.Telefono = "555";
            cliente5.Direccion = "Tela";

            ListaClientes.Add(cliente5);
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            return ListaClientes;
        }

        public bool GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                cliente.Id = ListaClientes.Max(item => item.Id) + 1;
            }
            return true;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    return true;
                }
            }

            return false;
        }

        private Validacion validar(Cliente cliente)
        {
            var resultado = new Validacion();
            resultado.Exitoso = true;

            if(cliente.Nombre !="")
            {
                resultado.Mensaje = "Ingrese un nombre valido";
                resultado.Exitoso = false;
            }

            if (cliente.Email != "")
            {
                resultado.Mensaje = "Ingrese un Correo Electronico valido";
                resultado.Exitoso = false;
            }

            if (cliente.Telefono != "")
            {
                resultado.Mensaje = "Ingrese Un numero telefonico valido";
                resultado.Exitoso = false;
            }

            if (cliente.Direccion != "")
            {
                resultado.Mensaje = "Ingrese una direccion valida";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

        public Cliente()
        {
            Activo = true;
        }
    }

    public class Validacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
