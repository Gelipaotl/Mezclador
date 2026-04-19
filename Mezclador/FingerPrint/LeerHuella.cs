
using System.Runtime.InteropServices;
using System.Text;
using Mezclador.FingerPrint;
using Mezclador.Models;
using Mezclador.Users;
using static Mezclador.Users.Usuario;

namespace Mezclador
{
    public partial class LeerHuella : Fingerprint
    {
        public LeerHuella(bool OnlyQuality = false)
        {
            _onlyQuality = OnlyQuality;
        }
        public bool UserLoged = false;
        public void Verify()
        {
            //Template = template;

            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Lectura de huella";
            //Verificator = new DPFP.Verification.Verification();     // Create a fingerprint template verificator
            UpdateStatus(0);

            btnPassword.Click += new EventHandler(btnPass_Click);
            tBoxPassword.KeyPress += new KeyPressEventHandler(tBoxPassword_KeyPress);
            FingerService.Identify();
        }

        //protected override void Process(DPFP.Sample Sample)
        //{
        //    base.Process(Sample);
        //    try
        //    {
        //        // Process the sample and create a feature set for the enrollment purpose.
        //        DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

        //        // Check quality of the sample and start verification if it's good

        //        if (features != null)
        //        {
        //            // Compare the feature set with our template
        //            DPFP.Verification.Verification.Result result = new();

        //            //Encoding encoding = Encoding.UTF8;

        //            foreach (var item in Huellas.ListHuellas)
        //            {
        //                if (item.Huella.Length > 1500)
        //                {
        //                    try
        //                    {
        //                        DPFP.Template template = new();
        //                        template.DeSerialize(item.Huella);

        //                        Verificator.Verify(features, template, ref result);
        //                        UpdateStatus(result.FARAchieved);
        //                        if (result.Verified)
        //                        {
        //                            MakeReport("La huella es CORRECTA.");
        //                            if (_onlyQuality)
        //                            {
        //                                if (item.Permisos != Permisos.Calidad.ToString() &&
        //                                    item.Permisos != Permisos.Total.ToString())
        //                                {
        //                                    //MessageBox.Show("La huella no corresponde a Calidad");
        //                                    MakeReport("La huella no corresponde a Calidad");
        //                                }
        //                                else
        //                                {
        //                                    comentarioCalidad comCalidad = new();
        //                                    comCalidad.ShowDialog();
        //                                    string comentario = comCalidad.Comentario;

        //                                    if (ConexionDB.QualityRegister(item.Id, comentario))
        //                                    {
        //                                        MakeReport("Huella de calidad registrada");
        //                                        CloseForm();
        //                                        //MessageBox.Show("Huella de calidad registrada");
        //                                    }
        //                                }
        //                                break;
        //                            }
        //                            MoveModelToLogged(item.Id, item.Nombre, item.Permisos);
        //                            UserLoged = true;
        //                            CloseForm();
        //                            break;
        //                        }
        //                        else
        //                            MakeReport("La huella es INCORRECTA.");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Handle any exceptions that occur during deserialization or verification
        //                        MakeReport($"Error al verificar la huella de {item.Nombre}: {ex.Message}");
        //                    }
        //                }
        //            }
        //            if (Huellas.ListHuellas.Count <= 0)
        //                MakeReport("No hay usuarios registrados.");
        //        }
        //    }
        //    catch (COMException) { }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            //SetStatus(String.Format($"Tasa de rechazo (FAR) = {FAR}"));
        }
        //private void MoveModelToLogged(int Id, string Nombre, string Permisos)
        //{
        //    try
        //    {
        //        Usuario.Id = Id;
        //        Usuario.Nombre = Nombre;
        //        // Intentar convertir el string al valor del enum
        //        if (Enum.TryParse(Permisos, true, out Permisos permiso))
        //        {
        //            // La conversión fue exitosa
        //            Usuario.Permiso = permiso;
        //        }
        //        else
        //        {
        //            // El string no coincide con ningún valor del enum
        //            MessageBox.Show("El permiso de este usuario en la base de datos no coincide con los de esta aplicación.");
        //        }
        //        if (ControlOrdenes.idOrden > 0 && ControlOrdenes.Order.Length > 0 && Usuario.Id > 0)
        //        {
        //            OrdenModel? existentOrder = ConexionDB.CheckOrderExist(ControlOrdenes.Order);
        //            if (existentOrder is not null)
        //                ControlOrdenes.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), existentOrder.Status);
        //            if (ControlOrdenes.Status == OrderStatus.InProcess)
        //                ControlOrdenes.CreateCarga();
        //            //MessageBox.Show($"No se pudo crear la carga, error en archivo: {this.Name}");
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show("Error en MoveModelToLogged: " + ex.Message); }
        //}


        private void button_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void tBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CheckSpecialPass();
            }
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            CheckSpecialPass();
        }

        private void CheckSpecialPass()
        {
            //if (tBoxPassword.Text == "specialPass" || tBoxPassword.Text == "1")
            //{
            UsuarioModel? user = ConexionDB.GetUserWithPass(tBoxPassword.Text);
            if (user is not null)
            {
                //Usuario.Nombre = "Administrador";
                //Usuario.Permiso = Usuario.Permisos.Administrador;
                if (_onlyQuality)
                {
                    if (user.Permisos != Permisos.Calidad.ToString() &&
                        user.Permisos != Permisos.Total.ToString())
                        MessageBox.Show("La contraseña no corresponde a Calidad");
                    else
                    {
                        comentarioCalidad comCalidad = new();
                        comCalidad.ShowDialog();
                        string comentario = comCalidad.Comentario;

                        if (ConexionDB.QualityRegister(user.Id, comentario))
                        {
                            MessageBox.Show("Personal de calidad registrado");
                            CloseForm();
                        }
                    }
                    return;
                }
                MoveModelToLogged(user.Id, user.Nombre, user.Permisos);
                UserLoged = true;
                CloseForm();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        private void CloseForm()
        {
            //se utiliza para acceder al form base, si se usa this.Close(); a secas genera exception 
            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
