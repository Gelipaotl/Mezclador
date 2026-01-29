using Mezclador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mezclador
{
    public partial class AddEditMaterial : Form
    {

        string ErrorMsg = string.Empty;
        ConexionDB.CrudType CrudType;
        string Codigo = string.Empty;
        bool Escaneable = false;
        string RutaImagen = string.Empty;
        string Producto = string.Empty;
        private MaterialModel producto;
        private double convertedPesoSaco = 0.0;
        private double convertedFactor = 0.0;
        int Id;

        public AddEditMaterial(ConexionDB.CrudType crudType, int id = 0)
        {
            InitializeComponent();
            Id = id;

            CrudType = crudType;
            if (CrudType == ConexionDB.CrudType.Update)
            {
                producto = ConexionDB.Get1Material(Id);
                if (Producto is not null)
                    LoadFields();
            }
        }
        private void LoadFields()
        {
            tBoxMaterial.Text = producto.Material;
            tBoxNombre.Text = producto.Nombre;
            checkEscaneable.Checked = producto.Escaneable;
            tBoxCodigo.Text = producto.Codigo;
            checkSaco.Checked = producto.Saco;
            tBoxSaco.Text = producto.PesoSaco;

            checkAceite.Checked = producto.esAceite;
            tBoxFactor.Text = producto.Factor.ToString();

            if (producto.Imagen is not null)
                RutaImagen = producto.Imagen.ToString();
        }
        private bool ValidateData()
        {

            string pattern = @"^ZZ\.\d{2}\.\d{4}$";

            if (!Regex.IsMatch(tBoxMaterial.Text, pattern))
            {
                ErrorMsg = "Material no válido, ejemplo válido: ZZ.01.0001";
                return false;
            }

            if (checkEscaneable.Checked && tBoxCodigo.Text.Length <= 0)
            {
                ErrorMsg = "Favor de llenar el campo del código";
                return false;
            }

            if (checkSaco.Checked && tBoxSaco.Text.Length <= 0)
            {
                ErrorMsg = "Favor de llenar el campo de peso del saco";
                return false;
            }

            bool isDouble = double.TryParse(tBoxSaco.Text, out convertedPesoSaco);

            if (checkSaco.Checked && !isDouble)
            {
                ErrorMsg = "No esta bien escrito el peso del saco";
                return false;
            }
            else convertedPesoSaco = Math.Round(convertedPesoSaco, 3);

            if (checkAceite.Checked && tBoxFactor.Text.Length <= 0)
            {
                ErrorMsg = "Favor de llenar el campo de Factor L a Kg";
                return false;
            }

            isDouble = double.TryParse(tBoxFactor.Text, out convertedFactor);

            if (checkAceite.Checked && !isDouble)
            {
                ErrorMsg = "No esta bien escrito el Factor L a Kg";
                return false;
            }
            else convertedFactor = Math.Round(convertedFactor, 3);
            //if (!radEscanear.Checked && !radPesar.Checked)
            //{
            //    ErrorMsg = "Selecciona si el producto tiene que ser pesado o escaneado";
            //    isValid = false;
            //}
            if (tBoxMaterial.Text.Length <= 0)
            {
                ErrorMsg = "Favor de llenar el campo del material";
                return false;
            }
            if (tBoxNombre.Text.Length <= 0)
            {
                ErrorMsg = "Favor de llenar el campo del nombre";
                return false;
            }
            //if ()
            //{
            //    ErrorMsg = "nombre repetido";
            //    return false;
            //}

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                MessageBox.Show(ErrorMsg);
                return;
            }
            if (ConexionDB.SaveMaterial(CrudType, tBoxMaterial.Text, tBoxNombre.Text, checkEscaneable.Checked, tBoxCodigo.Text, checkSaco.Checked, convertedPesoSaco.ToString(),checkAceite.Checked, convertedFactor, RutaImagen, Id))
                Close();
        }

        private void checkEscaneable_CheckedChanged(object sender, EventArgs e)
        {
            tBoxCodigo.Enabled = checkEscaneable.Checked;
        }

        private void checkSaco_CheckedChanged(object sender, EventArgs e)
        {
            tBoxSaco.Enabled = checkSaco.Checked;
            if (checkSaco.Checked)
                tBoxFactor.Enabled = checkAceite.Checked = false;
        }

        private void checkAceite_CheckedChanged(object sender, EventArgs e)
        {
            //tBoxCodigo.Enabled = checkEscaneable.Checked = false;
            tBoxFactor.Enabled = checkAceite.Checked;
            if (checkAceite.Checked)
                tBoxSaco.Enabled = checkSaco.Checked = false;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new()
            {
                Title = "Seleccionar imagen",
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                RutaImagen = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(RutaImagen);
            }
        }
        private void tBoxMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSaco_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumeric(sender, e);
        }

        private void tBoxLaKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumeric(sender, e);
        }
        private void OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Permitir el uso de la tecla de retroceso
            if (ch == 8) // 8 es el código ASCII para Backspace
            {
                return;
            }

            // Permitir solo números y un punto decimal
            if (!Char.IsDigit(ch) && ch != 46) // 46 es el código ASCII para el punto decimal
            {
                e.Handled = true;
            }
            else
            {
                // Solo permitir un punto decimal
                if (ch == 46 && (sender as TextBox).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void tBoxSaco_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
