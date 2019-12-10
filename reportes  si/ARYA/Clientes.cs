using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARYA
{
    public partial class Clientes : Form
    {
        ClientesBL _clientes;
        public Clientes()

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

            if (resultado.Exitoso == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Guardado");
            }

            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void DeshabilitarHabilitarBotones(bool v)
        {
            bindingNavigatorMoveFirstItem.Enabled = v;
            bindingNavigatorMoveLastItem.Enabled = v;
            bindingNavigatorMovePreviousItem.Enabled = v;
            bindingNavigatorMoveNextItem.Enabled = v;
            bindingNavigatorPositionItem.Enabled = v;
            bindingNavigatorAddNewItem.Enabled = v;
            bindingNavigatorDeleteItem.Enabled = v;

            toolStripButton1.Visible = !v;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _clientes.AgregarCliente();
            listaClientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }
        private void Eliminar(int id)
        {
            var resultado = _clientes.EliminarCliente(id);

            if (resultado == true)
            {
                listaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _clientes.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var buscar = textBox2.Text;
            listaClientesBindingSource.DataSource =
             _clientes.ObtenerClientes(buscar);

            if (string.IsNullOrEmpty(buscar))

                listaClientesBindingSource.ResetBindings(false);
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                            && !string.IsNullOrEmpty(idTextBox.Text))
            {
                nombreTextBox.Focus();
            }
        }

        private void nombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(nombreTextBox.Text))
            {
                direcionTextBox.Focus();
            }
        }

        private void direcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void direcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(direcionTextBox.Text))
            {
                telefonoTextBox.Focus();
            }
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(telefonoTextBox.Text))
            {
                correoElectronicoTextBox.Focus();
            }
        }

        private void correoElectronicoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    }