using Mezclador.FingerPrint;
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
using static Mezclador.Users.Usuario;

namespace Mezclador.Users
{
    public partial class SignIn : Form
    {
        byte[] FirstFinger;
        byte[] SecondFinger;
        CrudType _crudType;
        int _id;

        public SignIn(CrudType crudType, int Id = 0)
        {
            InitializeComponent();

            _crudType = crudType;

            List<string> permisos = Enum.GetNames(typeof(Usuario.Permisos)).ToList();
            if (!Usuario.Actions.CanModifyTotalUsers())
                permisos.Remove("Total");
            cboxPermisos.DataSource = permisos;

            if (_crudType == CrudType.Update)
            {
                Text = "Editar usuario";
                var usuario = ConexionDB.GetUserById(Id);

                tboxPass.Text = usuario.Pass;
                tboxName.Text = usuario.Nombre;
                cboxPermisos.Text = usuario.Permisos;
                _id = Id;
            }
        }
        private bool ValidateForm()
        {
            if (tboxName.Text == string.Empty)
            {
                MessageBox.Show("Introduce un nombre");
                return false;
            }
            if (tboxPass.Text.Length < 6)
            {
                MessageBox.Show("Introduce una contraseña mayor a 6 carácteres");
                return false;
            }

            //if (FirstFinger is null || SecondFinger is null)
            //{
            //    if (_crudType == CrudType.Create)
            //    {
            //        MessageBox.Show("Es necesario registrar ambas huellas");
            //        return false;
            //    }
            //}
            return true;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string permiso = cboxPermisos.SelectedItem.ToString();

            if (_crudType == CrudType.Create)
            {
                bool userExist = ConexionDB.CheckUserExist(tboxName.Text);
                if (!userExist)
                {
                    if (permiso is not null)
                        if (ConexionDB.SaveUser(tboxName.Text, tboxPass.Text, permiso, FirstFinger, SecondFinger))
                        {
                            MessageBox.Show("Usuario agregado correctamente.");
                            Close();
                        }
                }
                else
                {
                    MessageBox.Show("El usuario ya existe, intenta agregar apellidos");
                }
            }
            else if (_crudType == CrudType.Update)
            {
                if (ConexionDB.UpdateUser(_id,tboxName.Text, tboxPass.Text, permiso, FirstFinger, SecondFinger))
                {
                    MessageBox.Show("Usuario editado correctamente.");
                    Close();
                }
            }
        }
        private void btnRegFinger1_Click(object sender, EventArgs e)
        {
            RegistroHuella registroHuella = new RegistroHuella();
            registroHuella.ShowDialog();
            //if (registroHuella.Enroller.TemplateStatus ==
            //    DPFP.Processing.Enrollment.Status.Ready)
            if (FingerService.IsRegister && FingerService.RegisterSuccess)
            {
                FingerService.IsRegister = false;
                FingerService.RegisterSuccess = false;
                //FirstFinger = registroHuella.Enroller.Template.Bytes;
                FirstFinger = new byte[FingerService.cbRegTmp];
                Array.Copy(FingerService.RegTmp, FirstFinger, FingerService.cbRegTmp);
                btnRegFinger1.Text = "Huella registra";
                btnRegFinger1.Enabled = false;
            }
        }

        private void btnRegFinger2_Click(object sender, EventArgs e)
        {
            RegistroHuella registroHuella = new RegistroHuella();
            registroHuella.ShowDialog();
            if (FingerService.IsRegister && FingerService.RegisterSuccess)
            {
                FingerService.IsRegister = false;
                FingerService.RegisterSuccess = false;
                //SecondFinger = registroHuella.Enroller.Template.Bytes;
                SecondFinger = new byte[FingerService.cbRegTmp];
                Array.Copy(FingerService.RegTmp, SecondFinger, FingerService.cbRegTmp);
                btnRegFinger2.Text = "Huella registra";
                btnRegFinger2.Enabled = false;
            }
        }

        private void cboxPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
