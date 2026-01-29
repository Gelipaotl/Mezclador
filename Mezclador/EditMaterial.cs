
using Mezclador.Users;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mezclador
{
	public partial class EditMaterial : Form
	{
		private SortOrder sortOrden = SortOrder.None;
		private int lastSortedColumnIndex = -1;
		public EditMaterial()
		{
			InitializeComponent();
			RefreshDgv();
		}
		private void RefreshDgv()
		{
			List<MaterialViewModel> products = ConexionDB.GetMateriales();
			dgvMateriales.DataSource = products;
			lblNoRecipes.Visible = dgvMateriales.Rows.Count <= 0;
		}
		public static void SortDataGridView<T>(ref int lastSorted, ref SortOrder sortOrder, int columnIndex, BindingList<T>dataList,DataGridView dgv )
		{
			// Verificar si hay datos enlazados
			if (dgv.DataSource is IList<T> productList)
			{
				// Obtener la propiedad de ordenación basada en el índice de columna
				PropertyInfo property = typeof(T).GetProperties()[columnIndex];

				// Determinar la dirección de ordenación
				if (lastSorted == columnIndex)
				{
					// Si es la misma columna que la anterior, invertir la dirección de ordenación
					sortOrder = sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
				}
				else
				{
					// Si es una columna diferente, iniciar la ordenación en orden ascendente
					sortOrder = SortOrder.Ascending;
				}

				// Ordenar la lista según la propiedad seleccionada y la dirección de ordenación
				productList = sortOrder == SortOrder.Ascending ?
					new BindingList<T>(productList.OrderBy(p => property.GetValue(p)).ToList()) :
					new BindingList<T>(productList.OrderByDescending(p => property.GetValue(p)).ToList());

				// Asignar la lista ordenada de nuevo al origen de datos del DataGridView
				dgv.DataSource = productList;

				// Actualizar el índice de la última columna ordenada
				lastSorted = columnIndex;
			}
		}
		private void formEditProduct_Load(object sender, EventArgs e)
		{
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!Usuario.Actions.CanModifyRecipes())
			{
				MessageBox.Show("Permisos insuficientes");
				return;
			}
			AddEditMaterial addEditProduct = new(ConexionDB.CrudType.Create);
			addEditProduct.ShowDialog();
			RefreshDgv();
		}

		private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanModifyRecipes())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            if (dgvMateriales.SelectedRows.Count > 0)
			{
				// Obtiene la primera celda de la fila seleccionada (la primera columna)
				DataGridViewCell cell = dgvMateriales.SelectedRows[0].Cells[0];

				// Verifica si la celda no está vacía
				if (cell.Value != null)
				{
					// Obtiene el valor de la celda
					int id = Convert.ToInt32(cell.Value);

					AddEditMaterial addEditProduct = new(ConexionDB.CrudType.Update, id);
					addEditProduct.ShowDialog();
					RefreshDgv();
				}
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			// Obtener el índice de la columna seleccionada
			int columnIndex = e.ColumnIndex;

			// Llamar a la función de ordenación
			BindingList<MaterialViewModel> materialList = new BindingList<MaterialViewModel>();
			SortDataGridView(ref lastSortedColumnIndex,ref sortOrden, columnIndex, materialList, dgvMateriales);
		}
	}
}
