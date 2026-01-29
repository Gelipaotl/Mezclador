using Mezclador.Models;
using Mezclador.Services;
using Mezclador.Users;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Mezclador.ConexionDB;

namespace Mezclador
{
    public partial class AddEditProducto : Form
    {
        private class CboxMaterialsModel
        {
            public string Material { get; set; } = "";
            public string Nombre { get; set; } = "";
            public string Display => $"{Material} {Nombre}";

        }
        const string columnLigera = "Ligera";
        const string columnPesada = "Pesada";

        string ErrorMsg = string.Empty;
        ConexionDB.CrudType _crudType;
        string Codigo = string.Empty;
        bool Escaneable = false;
        string RutaImagen = string.Empty;
        string Producto = string.Empty;
        //private MaterialModel producto;
        ProductoModel? _producto;
        int Id;
        List<MaterialParaProducto> materialesDelProducto = new();
        List<MaterialViewModel> materialesList;

        public AddEditProducto(ConexionDB.CrudType crudType, ProductoModel? producto = null)
        {
            InitializeComponent();
            _producto = producto;
            _crudType = crudType;
            materialesList = ConexionDB.GetMateriales();
            cBoxMateriales.DataSource = materialesList.Select(c => new CboxMaterialsModel { Material = c.Material, Nombre = c.Nombre }).OrderBy(c => c.Material).ToList();
            cBoxMateriales.DisplayMember = "Display";
            cBoxMateriales.ValueMember = "Material";

            if (_crudType == CrudType.Update)
            {
                if (producto == null)
                    return;

                var instructions = GetInstructionsList(producto.Producto);
                materialesDelProducto = instructions.Where(c => c.Habilitado == true).Select(c =>
                new MaterialParaProducto() { IdInstruccion = c.IdInstruccion, Material = c.Material, Nombre = c.Nombre, Cantidad = c.Cantidad.ToString(), Paso = c.Paso, Ligera = c.Ligera, Pesada = c.Pesada }).ToList();
                tBoxProducto.Text = producto.Producto;
                tBoxName.Text = producto.Nombre;
                //materialesDelProducto.AddRange();
                //GetInstructionsList(producto);
                RefreshDgv();
            }



            if (!Usuario.Actions.CanModifyRecipes())
            {
                btnSave.Enabled = amountDown.Enabled = amountUp.Enabled
                    = tBoxName.Enabled = tBoxProducto.Enabled = cBoxMateriales.Enabled
                    = btnAddProd.Enabled = btnDeleteRow.Enabled = false;
                //MessageBox.Show("Permisos insuficientes");
                //return;
            }

            //ControlButtonPasos();
            //btnSubirPaso.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                MessageBox.Show(ErrorMsg);
                return;
            }
            if (ConexionDB.SaveProducto(_crudType, tBoxProducto.Text, tBoxName.Text, materialesList, materialesDelProducto, numCantidad.Value.ToString(), _producto?.Id))
                Close();
        }
        private bool ValidateData()
        {
            string pattern = @"^ZZ\.\d{2}\.\d{4}$";

            if (Regex.IsMatch(tBoxProducto.Text, pattern))
            {

            }
            else
            {
                ErrorMsg = "Producto no válido, ejemplo válido: ZZ.01.0001";
                return false;
            }
            //if (!radEscanear.Checked && !radPesar.Checked)
            //{
            //    ErrorMsg = "Selecciona si el producto tiene que ser pesado o escaneado";
            //    isValid = false;
            //}
            if (tBoxName.Text.Length <= 0)
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

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if (lblErrDuplicate.Visible) lblErrDuplicate.Visible = false;

            //var selectedMaterial = "";

            //if (cBoxMateriales.SelectedIndex >= 0)
            if (cBoxMateriales.SelectedItem is CboxMaterialsModel selectedItem)
            {
                //selectedMaterial = cBoxMateriales.SelectedItem.ToString();

                if (materialesDelProducto.FirstOrDefault(c => c.Material == selectedItem.Material) != null)
                {
                    lblErrDuplicate.Visible = true;
                    return;
                }
                int maxPaso = materialesDelProducto.Any() ? materialesDelProducto.Max(mp => mp.Paso) : 0;
                materialesDelProducto.Add(new()
                {
                    Material = selectedItem.Material,
                    Nombre = selectedItem.Nombre,
                    Cantidad = numCantidad.Value.ToString("0.000"),
                    Paso = maxPaso + 1,
                    Ligera = true,
                    Pesada = false,
                });
                RefreshDgv();
            }
            else
            {
                MessageBox.Show("Selecciona un material de la lista");
                return;
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila seleccionada
            if (dgvRecetaMateriales.SelectedRows.Count > 0)
            {
                materialesDelProducto.RemoveAt(dgvRecetaMateriales.SelectedRows[0].Index);
                for (int i = 0; i < materialesDelProducto.Count; i++)
                {
                    materialesDelProducto[i].Paso = i + 1;
                }
                // Eliminar la primera fila seleccionada (solo se elimina una fila a la vez)
                RefreshDgv();
            }
        }
        private void RefreshDgv()
        {
            materialesDelProducto = materialesDelProducto.OrderBy(c => c.Paso).ToList();
            dgvRecetaMateriales.DataSource = null;
            dgvRecetaMateriales.DataSource = materialesDelProducto;

            //dgvRecetaMateriales.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Auto
            //         dgvRecetaMateriales.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;     // *
            //         dgvRecetaMateriales.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewColumn column in dgvRecetaMateriales.Columns)
            {
                column.ReadOnly = true;
            }

            string idInstruccion = "idInstruccion";
            if (dgvRecetaMateriales.Columns.Contains(idInstruccion))
                dgvRecetaMateriales.Columns[idInstruccion].Visible = false;

            if (dgvRecetaMateriales.Columns.Contains("Cantidad"))
                dgvRecetaMateriales.Columns["Cantidad"].ReadOnly = false;
            if (dgvRecetaMateriales.Columns.Contains("Ligera"))
                dgvRecetaMateriales.Columns["Ligera"].ReadOnly = false;
            if (dgvRecetaMateriales.Columns.Contains("Pesada"))
                dgvRecetaMateriales.Columns["Pesada"].ReadOnly = false;

            lblTotalMat.Text = $"{dgvRecetaMateriales.RowCount} Materiales";
        }


        private void dgvRecetaMateriales_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvRecetaMateriales.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                // Obtener el valor ingresado por el usuario
                if (decimal.TryParse(e.FormattedValue.ToString(), out decimal nuevaCantidad))
                {
                    // Validar el valor ingresado contra los límites del NumericUpDown
                    if (nuevaCantidad < numCantidad.Minimum || nuevaCantidad > numCantidad.Maximum)
                    {
                        // Mostrar un mensaje de error
                        MessageBox.Show($"Por favor, ingrese un valor entre {numCantidad.Minimum} y {numCantidad.Maximum} con hasta {numCantidad.DecimalPlaces} decimales.", "Valor fuera de límites", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Cancelar la edición
                        e.Cancel = true;
                    }
                    else
                    {
                        // Validar el número de decimales
                        var decimalPlaces = BitConverter.GetBytes(decimal.GetBits(nuevaCantidad)[3])[2];
                        if (decimalPlaces > numCantidad.DecimalPlaces)
                        {
                            // Mostrar un mensaje de error
                            MessageBox.Show($"Por favor, ingrese un valor con hasta {numCantidad} decimales.", "Número de decimales excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            // Cancelar la edición
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    // Mostrar un mensaje de error si el valor ingresado no es numérico
                    MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Cancelar la edición
                    e.Cancel = true;
                }
            }
        }

        private void dgvRecetaMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvRecetaMateriales.Columns[e.ColumnIndex].Name;
            var rowIndex = e.RowIndex;

            // Verificar que el índice de la fila es válido
            if (rowIndex < 0 || rowIndex >= dgvRecetaMateriales.Rows.Count)
            {
                return;
            }

            // Verificar que la fila y las celdas no son nulas
            var row = dgvRecetaMateriales.Rows[rowIndex];
            if (row == null)
            {
                return;
            }

            // Manejar la lógica de acuerdo al nombre de la columna
            switch (columnName)
            {
                case columnLigera:
                    row.Cells[columnPesada].Value = false;
                    break;
                case columnPesada:
                    row.Cells[columnLigera].Value = false;
                    break;
                default:
                    // No hacer nada si la columna no es relevante
                    break;
            }

        }

        private void btnAllLigera_Click(object sender, EventArgs e)
        {
            if (dgvRecetaMateriales.Columns.Contains(columnLigera) && dgvRecetaMateriales.Columns.Contains(columnPesada))
            {
                foreach (DataGridViewRow row in dgvRecetaMateriales.Rows)
                {
                    dgvRecetaMateriales.Rows[row.Index].Cells[columnLigera].Value = true;
                    dgvRecetaMateriales.Rows[row.Index].Cells[columnPesada].Value = false;
                }
            }
        }

        private void btnAllPesada_Click(object sender, EventArgs e)
        {

            if (dgvRecetaMateriales.Columns.Contains(columnLigera) && dgvRecetaMateriales.Columns.Contains(columnPesada))
            {
                foreach (DataGridViewRow row in dgvRecetaMateriales.Rows)
                {
                    dgvRecetaMateriales.Rows[row.Index].Cells[columnLigera].Value = false;
                    dgvRecetaMateriales.Rows[row.Index].Cells[columnPesada].Value = true;
                }
            }
        }

        private void tBoxProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void amountUp_Click(object sender, EventArgs e)
        {
            numCantidad.UpButton();
        }

        private void amountDown_Click(object sender, EventArgs e)
        {
            numCantidad.DownButton();
        }

        private void btnSubirPaso_Click(object sender, EventArgs e)
        {
            if (dgvRecetaMateriales.SelectedRows.Count > 0)
            {
                var actualIndex = dgvRecetaMateriales.SelectedRows[0].Index;
                var prevIndex = dgvRecetaMateriales.SelectedRows[0].Index - 1;
                if (prevIndex < 0)
                    return;
                materialesDelProducto[actualIndex].Paso -= 1;
                materialesDelProducto[prevIndex].Paso += 1;
                RefreshDgv();
                dgvRecetaMateriales.CurrentCell = dgvRecetaMateriales.Rows[prevIndex].Cells[1];
            }
        }

        private void btnBajarPaso_Click(object sender, EventArgs e)
        {
            if (dgvRecetaMateriales.SelectedRows.Count > 0)
            {
                var actualIndex = dgvRecetaMateriales.SelectedRows[0].Index;
                var nextIndex = dgvRecetaMateriales.SelectedRows[0].Index + 1;
                if (nextIndex >= dgvRecetaMateriales.RowCount)
                    return;
                materialesDelProducto[actualIndex].Paso += 1;
                materialesDelProducto[nextIndex].Paso -= 1;
                RefreshDgv();
                dgvRecetaMateriales.CurrentCell = dgvRecetaMateriales.Rows[nextIndex].Cells[1];
            }
        }

        private void tBoxProducto_TextChanged(object sender, EventArgs e)
        {
            if (tBoxProducto.TextLength == 10)//validar que tenga por lo menos 8 caracteres para hacer la busqueda ZZ.00.0089
            {
                int productoId = SearchDeletedProducto(tBoxProducto.Text);
                if (productoId >0){
                   var response = MessageBox.Show($"Este número de receta se encontró como eliminada, quieres recuperarla?","",MessageBoxButtons.YesNo);
                    if (response == DialogResult.Yes)
                    {
                        RestoreDeletedProduct(productoId);
                        Close();
                    }
                    else
                    {
                        tBoxProducto.Text = tBoxProducto.Text.Remove(tBoxProducto.TextLength -1);
                    }

                }
            }
        }
    }
    public class MaterialParaProducto
    {
        public int? IdInstruccion { get; set; }
        public string? Material { get; set; }
        public string? Nombre { get; set; }
        public string? Cantidad { get; set; }
        public int Paso { get; set; }
        public bool Ligera { get; set; }
        public bool Pesada { get; set; }
    }
}
