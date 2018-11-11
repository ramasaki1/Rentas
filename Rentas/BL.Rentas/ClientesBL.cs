using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
        contexto _contexto;
        public BindingList<Cliente> ListaClientes { get; set; }
        public ClientesBL()
        {
            _contexto = new contexto();
            ListaClientes = new BindingList<Cliente>();

            
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();
            return ListaClientes;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarCliente(Cliente cliente)
        {
           var resultado = validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
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
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado validar(Cliente cliente)
        {
            var resultado = new Resultado();

            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un nombre valido";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Email) == true)
            {
                resultado.Mensaje = "Ingrese un Correo Electronico valido";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese Un numero telefonico valido";
                resultado.Exitoso = false;
            }

            if (cliente.CiudadId == 0)
            {
                resultado.Mensaje = "Seleccione una Ciudad";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Direccion) == true)
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

        
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }

        public Byte[] Foto { get; set; }
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
