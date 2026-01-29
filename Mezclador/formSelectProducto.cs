

namespace Mezclador
{
	public partial class formSelectProducto : Form
	{
		public bool clearOrder = false;
		public formSelectProducto()
		{
			InitializeComponent();
			var recipes = ConexionDB.GetProductos();
			dataGridView1.DataSource = recipes;

			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dataGridView1.Columns["ID"].MinimumWidth = 50;
			dataGridView1.Columns["Producto"].MinimumWidth = 200;
			dataGridView1.Columns["Nombre"].MinimumWidth = 500;

			tBoxOrder.Text = ControlOrdenes.Order;

		}

		private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
		{

			if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("RutaImagen")) // Reemplaza con el nombre de tu columna de ruta de imagen
			{
				if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn columnaImagen)
				{
					columnaImagen.ImageLayout = DataGridViewImageCellLayout.Zoom; // O el valor que desees, como Zoom, Normal, etc.
				}
			}
		}

		private void formSelectRecipe_Load(object sender, EventArgs e)
		{
			lblNoRecipes.Visible = dataGridView1.Rows.Count <= 0;
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count > 0)
			{
				//ProductoViewModel selectedProduct = new();
				var idSelected = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
				var selectedProduct = ConexionDB.Get1Producto(idSelected);

				//selectedProduct.Id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
				//selectedProduct.Producto = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
				//selectedProduct.Nombre = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
				//string selectedRecipe = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
				var materialsProduct = ConexionDB.GetInstructionsList(selectedProduct.Producto);
				ControlOrdenes.LoadRecipe(selectedProduct, materialsProduct);

				formSetAmount formSetAmount = new(selectedProduct, ConexionDB.CrudType.Create);
				formSetAmount.ShowDialog();
				if (formSetAmount.completed)
					Close();
			}
		}

		private void btnRegresar_Click(object sender, EventArgs e)
		{
			ControlOrdenes.ClearOrder();
			clearOrder = true;
			Close();
		}

		private void lblInstructions_Click(object sender, EventArgs e)
		{

		}
	}
}
