

using System.ComponentModel;
using System.Configuration;

namespace Mezclador
{
	public partial class formOrdenes : Form
	{
		private SortOrder sortOrden = SortOrder.None;
		private int lastSortedColumnIndex = -1;
		public formOrdenes()
		{
			InitializeComponent();
			RefreshDgv();

			//dgvProduccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			//dgvProduccion.Columns["ID"].MinimumWidth = 50;
			//dgvProduccion.Columns["Producto"].MinimumWidth = 200;
			//dgvProduccion.Columns["Nombre"].MinimumWidth = 500;
		}


		private void RefreshDgv()
		{
			dgvProduccion.DataSource = ConexionDB.GetOrdenes();
			dgvConsumption.DataSource = ConexionDB.GetConsumptionSum();
			//lblNoRecipes.Visible = dgvProduccion.Rows.Count <= 0;
		}


		private void lblInstructions_Click(object sender, EventArgs e)
		{

		}

		private void formProduccion_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
				RefreshDgv();
		}

		private void dgvProduccion_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			// Obtener el índice de la columna seleccionada
			int columnIndex = e.ColumnIndex;

			// Llamar a la función de ordenación
			BindingList<OrdenViewModel> materialList = new BindingList<OrdenViewModel>();
			EditMaterial.SortDataGridView(ref lastSortedColumnIndex, ref sortOrden, columnIndex, materialList, dgvProduccion);
		}
	}
}
