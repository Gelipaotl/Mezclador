using Mezclador.Users;
using System.ComponentModel;

namespace Mezclador
{
    public partial class EditProducto : Form
    {
        private SortOrder sortOrden = SortOrder.None;
        private int lastSortedColumnIndex = -1;
        public EditProducto()
        {
            InitializeComponent();
            RefreshDgv();
        }

        private void RefreshDgv()
        {
            var recipes = ConexionDB.GetProductos();
            dgvRecetas.DataSource = recipes;
            lblNoRecipes.Visible = dgvRecetas.Rows.Count <= 0;
        }

        private void formEditRecipe_Load(object sender, EventArgs e)
        {
            lblNoRecipes.Visible = dgvRecetas.Rows.Count <= 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditProducto addEditRecipe = new(ConexionDB.CrudType.Create);
            addEditRecipe.ShowDialog();
            RefreshDgv();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditarReceta();
        }

        private void dgvRecetas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // Obtener el índice de la columna seleccionada
            int columnIndex = e.ColumnIndex;

            // Llamar a la función de ordenación
            BindingList<Models.ProductoModel> materialList = new BindingList<Models.ProductoModel>();
            EditMaterial.SortDataGridView(ref lastSortedColumnIndex, ref sortOrden, columnIndex, materialList, dgvRecetas);
        }
        private void EditarReceta()
        {

            //if (!Usuario.Actions.CanModifyRecipes())
            //{
            //    MessageBox.Show("Permisos insuficientes");
            //    return;
            //}
            if (dgvRecetas.SelectedCells.Count > 0)
            {
                var selectedRow = dgvRecetas.SelectedRows[0];
                var selectedProduct = selectedRow.DataBoundItem as Models.ProductoModel;
                if (selectedProduct != null)
                {
                    AddEditProducto addEditRecipe = new(ConexionDB.CrudType.Update, selectedProduct);
                    addEditRecipe.ShowDialog();
                    RefreshDgv();
                }
            }
        }
        private void dgvRecetas_DoubleClick(object sender, EventArgs e)
        {
            EditarReceta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditProducto addEditRecipe = new(ConexionDB.CrudType.Create);
            addEditRecipe.ShowDialog();
            RefreshDgv();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanModifyRecipes())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            if (dgvRecetas.SelectedCells.Count > 0)
            {
                var selectedRow = dgvRecetas.SelectedRows[0];
                var selectedProduct = selectedRow.DataBoundItem as Models.ProductoModel;
                if (selectedProduct != null)
                {
                    var response = MessageBox.Show("Seguro que desea eliminar esta receta?","Advertencia",MessageBoxButtons.YesNo);
                    if (response == DialogResult.Yes)
                    {
                        ConexionDB.DeleteProduct(selectedProduct.Id);
                        RefreshDgv();
                    }
                }
            }
        }
    }
}
