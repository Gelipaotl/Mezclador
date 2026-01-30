using Mezclador.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mezclador.ConexionDB;

namespace Mezclador.Users
{
    public partial class ControlUsers : Form
    {
        public ControlUsers()
        {
            InitializeComponent();
            RefreshDgv();

        }
        void RefreshDgv()
        {
            dgvUsers.DataSource = ConexionDB.GetUsersList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            SignIn signIn = new(CrudType.Create);
            signIn.ShowDialog();
            RefreshDgv();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            var id = GetSelectedId();
            if (id > 0)
            {
                SignIn signIn = new(CrudType.Update, id);
                signIn.ShowDialog();
                RefreshDgv();
            }
        }
        private int GetSelectedId()
        {

            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewCell cell = dgvUsers.SelectedRows[0].Cells[0];

                // Verifica si la celda no está vacía
                if (cell.Value != null)
                {
                    return Convert.ToInt32(cell.Value);
                }
            }
            return 0;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }

            var id = GetSelectedId();
            if (id > 0)
            {
                if (Usuario.Id == id)
                {
                    MessageBox.Show("No es posible eliminarte a ti mismo");
                    return;
                }
                var result = MessageBox.Show("Eliminar usuario?", "Confirmación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ConexionDB.DeleteUser(id);
                    MessageBox.Show("Usuario eliminado");
                    RefreshDgv();
                }
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
