using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormClientes : Form
    {
        ClientesBL _clientes;

        public FormClientes()
        {
            InitializeComponent();

            _clientes = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientes.ObtenerClientes();
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Cliente)listaClientesBindingSource.Current;
            var resultado = _clientes.GuardarCliente(cliente);

            if(resultado == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);

            }
            else
            {
                MessageBox.Show("Ocurrio un error guardando al cliente");

            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            _clientes.AgregarCliente();
            listaClientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (iDTextBox.Text != "")
            {
                var ID = Convert.ToInt32(iDTextBox.Text);
                var resultado = _clientes.EliminarCliente(ID);

                if (resultado == true)
                {
                    listaClientesBindingSource.ResetBindings(false);

                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar un producto");
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormClientes
            // 
            this.ClientSize = new System.Drawing.Size(313, 261);
            this.Name = "FormClientes";
            this.ResumeLayout(false);

        }
    }
}
