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
    public partial class FormProveedores : Form
    {
        ProveedoresBL _proveedores;

        public FormProveedores()
        {
            InitializeComponent();

            _proveedores = new ProveedoresBL();
            listaProveedoresBindingSource.DataSource = _proveedores.ObtenerProveedor();
        }

        private void listaProveedoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProveedoresBindingSource.EndEdit();
            var proveedor = (Proveedor)listaProveedoresBindingSource.Current;
            var resultado = _proveedores.GuardarProveedor(proveedor);

            if (resultado == true)
            {
                listaProveedoresBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show("Ocurrio un error guardando el producto");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _proveedores.AgregarProveedor();
            listaProveedoresBindingSource.MoveLast();

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
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (iDTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var ID = Convert.ToInt32(iDTextBox.Text);
                    Eliminar(ID);
                }
            }

        }

        private void Eliminar(int ID)
        {
            
            var resultado = _proveedores.EliminarProveedor(ID);

            if (resultado == true)
            {
                listaProveedoresBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
