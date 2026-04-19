
//using DPFP;
//using DPFP.Capture;

using libzkfpcsharp;
using Mezclador.FingerPrint;
using Mezclador.Models;
using Mezclador.Users;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Security.Principal;
using static Mezclador.FingerPrint.FingerService;
using static Mezclador.Users.Usuario;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mezclador
{

    public partial class Fingerprint : Form//, DPFP.Capture.EventHandler
    {
        public bool _onlyQuality = false;
        public Fingerprint()
        {
            InitializeComponent();
            Init();
            if (!IsInitialized)
            {
                Prompt.Text = "Lector de huella no encontrado.";
                Status.Text = "Reabra esta ventana para reintentar";
            }
            else
                Prompt.Text = "Coloque su huella.";
        }
        protected virtual void Init()
        {
            try
            {
                //Capturer = new Capture();               // Create a capture operation.

                //if (null != Capturer)
                //    Capturer.EventHandler = this;                   // Subscribe for capturing events.
                //else
                //    SetPrompt("No se puede iniciar la operacion de captura");
                InitZK();
            }
            catch
            {
                MessageBox.Show("No se puede iniciar la operacion de captura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        this.Picture.Image = bmp;
                        if (IsRegister) // si esta enrolando huella
                        {
                            int ret = zkfp.ZKFP_ERR_OK;
                            //int fid = 0, score = 0;
                            //ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            //if (zkfp.ZKFP_ERR_OK == ret)
                            //{
                            //    //textRes.Text = "This finger was already register by " + fid + "!";
                            //    return;
                            //}
                            
                            if (RegisterCount > 0)
                            {
                                int score = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]);
                                StatusLine.Text = $"Coincidencia de la huella: {score}";
                                if (score <= 0)
                                {
                                    MakeReport("Debes colocar la misma huella");
                                    return;
                                }
                            }
                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            RegisterCount++;
                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                RegisterCount = 0;
                                //if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)) &&
                                //       zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBAdd(mDBHandle, iFid, RegTmp)))
                                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)))
                                {
                                    //iFid++;
                                    RegisterSuccess = true;
                                    Close();
                                    //MessageBox.Show("Huella registrada con exito");
                                }
                                else
                                {
                                    MakeReport("Error al registrar la huella, error code=" + ret);
                                }
                                //IsRegister = false;
                                return;
                            }
                            else
                            {
                                MakeReport("Lecturas restantes: " + (REGISTER_FINGER_COUNT - RegisterCount));
                            }
                        }
                        else // si no esta enrolando huella
                        {
                            //if (cbRegTmp <= 0)
                            //{
                            //    //textRes.Text = "Please register your finger first!";
                            //    return;
                            //} 
                            if (bIdentify) //si esta leyendo huella
                            {
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                //ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);

                                //if (zkfp.ZKFP_ERR_OK == ret)
                                if (SearchDBFinger())
                                {
                                    //MessageBox.Show("Identify succ, fid= " + fid + ",score=" + score + "!");
                                    return;
                                }
                                else
                                {
                                    //textRes.Text = "Identify fail, ret= " + ret;
                                    return;
                                }
                            }
                            else //si quiere validar la calidad de la huella (tal vez se quite esto)
                            {
                                //int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                                //if (0 < ret)
                                //{
                                //    MessageBox.Show("Match finger succ, score=" + ret + "!");
                                //    return;
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Match finger fail, ret= " + ret);
                                //    return;
                                //}
                            }
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        private bool IsValidZkTemplate(byte[] template)
        {
            if (template == null || template.Length < 100)
                return false;

            IntPtr tempDb = zkfp2.DBInit();

            int ret = zkfp2.DBAdd(tempDb, 1, template);

            zkfp2.DBFree(tempDb);

            return ret == zkfp.ZKFP_ERR_OK;
        }
        public bool SearchDBFinger()
        {
            bool result = false;
            var template = CapTmp;
            var templateSize = cbCapTmp;

            foreach (var item in Huellas.ListHuellas)
            {
                if (item.Huella.Length > 1500)
                    continue;
                try
                {
                    if (!IsValidZkTemplate(item.Huella))
                    {
                        MakeReport("La huella es INCORRECTA.");
                        continue; // Es U.are.U, lo ignoramos
                    }

                    var score = zkfp2.DBMatch(mDBHandle, template, item.Huella);
                    StatusLine.Text = $"Coincidencia de la huella: {score}";
                    //DPFP.Template template = new();
                    //template.DeSerialize(item.Huella);

                    //Verificator.Verify(features, template, ref result);
                    //UpdateStatus(result.FARAchieved);
                    if (score > 60)
                    {
                        MakeReport("La huella es CORRECTA.");
                        if (_onlyQuality)
                        {
                            if (item.Permisos != Permisos.Calidad.ToString() &&
                                item.Permisos != Permisos.Total.ToString())
                            {
                                //MessageBox.Show("La huella no corresponde a Calidad");
                                MakeReport("La huella no corresponde a Calidad");
                            }
                            else
                            {
                                comentarioCalidad comCalidad = new();
                                comCalidad.ShowDialog();
                                string comentario = comCalidad.Comentario;

                                if (ConexionDB.QualityRegister(item.Id, comentario))
                                {
                                    MakeReport("Huella de calidad registrada");
                                    Close();
                                    //MessageBox.Show("Huella de calidad registrada");
                                }
                            }
                            break;
                        }
                        MoveModelToLogged(item.Id, item.Nombre, item.Permisos);
                        //UserLoged = true;
                        bIdentify = false;
                        Close();
                        break;
                    }
                    else
                        MakeReport("La huella es INCORRECTA.");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during deserialization or verification
                    MakeReport($"Error al verificar la huella de {item.Nombre}: {ex.Message}");
                }
            }

            if (Huellas.ListHuellas.Count <= 0)
                MakeReport("No hay usuarios registrados.");
            return false;
        }
        public void MoveModelToLogged(int Id, string Nombre, string Permisos)
        {
            try
            {
                Usuario.Id = Id;
                Usuario.Nombre = Nombre;
                // Intentar convertir el string al valor del enum
                if (Enum.TryParse(Permisos, true, out Permisos permiso))
                {
                    // La conversión fue exitosa
                    Usuario.Permiso = permiso;
                }
                else
                {
                    // El string no coincide con ningún valor del enum
                    MessageBox.Show("El permiso de este usuario en la base de datos no coincide con los de esta aplicación.");
                }
                if (ControlOrdenes.idOrden > 0 && ControlOrdenes.Order.Length > 0 && Usuario.Id > 0)
                {
                    OrdenModel? existentOrder = ConexionDB.CheckOrderExist(ControlOrdenes.Order);
                    if (existentOrder is not null)
                        ControlOrdenes.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), existentOrder.Status);
                    if (ControlOrdenes.Status == OrderStatus.InProcess)
                        ControlOrdenes.CreateCarga();
                    //MessageBox.Show($"No se pudo crear la carga, error en archivo: {this.Name}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error en MoveModelToLogged: " + ex.Message); }
        }
        //protected virtual void Process(Sample Sample)
        //{
        //    // Draw fingerprint sample image.
        //    DrawPicture(ConvertSampleToBitmap(Sample));
        //}

        //protected void Start()
        //{
        //    if (null != Capturer)
        //    {
        //        try
        //        {
        //            Capturer.StartCapture();
        //            SetPrompt("Escanea tu huella.");
        //        }
        //        catch
        //        {
        //            SetPrompt("No se puede iniciar la captura.");
        //        }
        //    }
        //}

        //protected void Stop()
        //{
        //    if (null != Capturer)
        //    {
        //        try
        //        {
        //            Capturer.StopCapture();
        //        }
        //        catch
        //        {
        //            SetPrompt("No se puede terminar la captura.");
        //        }
        //    }
        //}
        //public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        //{
        //    //MakeReport("The fingerprint sample was captured.");
        //    SetPrompt("La huella fue capturada.");
        //    Process(Sample);
        //}

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("La huella se ha retirado del lector de huellas.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("Se ha tocado el lector de huellas.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("El lector de huellas está conectado.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("El lector de huellas está desconectado.");
            //SetPrompt("El lector de huellas está desconectado.");
        }

        //public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        //{
        //    if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
        //        MakeReport("La calidad de la muestra de la huella es buena.");
        //    else
        //        MakeReport("La calidad de la muestra de la huella es mala.");
        //}


        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate ()
            {
                Prompt.Text = prompt;
            }));
        }

        //protected void SetStatus(string status)
        //{
        //    this.Invoke(new Function(delegate ()
        //    {
        //        StatusLine.Text = status;
        //    }));
        //}
        //protected Bitmap ConvertSampleToBitmap(Sample Sample)
        //{
        //    SampleConversion Convertor = new();  // Create a sample convertor.
        //    Bitmap bitmap = null;
        //    Convertor.ConvertToPicture(Sample, ref bitmap);
        //    return bitmap;
        //}

        //protected FeatureSet ExtractFeatures(Sample Sample, DPFP.Processing.DataPurpose Purpose)
        //{
        //    DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
        //    CaptureFeedback feedback = CaptureFeedback.None;
        //    FeatureSet features = new();
        //    Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
        //    if (feedback == CaptureFeedback.Good)
        //        return features;
        //    else
        //        return null;
        //}
        public void Register()
        {
            FingerService.Register();
            Status.Text = "Lecturas restantes: " + (FingerService.REGISTER_FINGER_COUNT - FingerService.RegisterCount);
        } 
        protected void MakeReport(string status)
        {
            this.Invoke(new Function(delegate ()
            {
                Status.Text = status;
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate ()
            {
                Picture.Image = new Bitmap(bitmap, Picture.Size);   // fit the image into the picture box
            }));
        }

        //private Capture Capturer;

        private void Fingerprint_Load(object sender, EventArgs e)
        {
            //Init();
            //Start();
            FormHandle = this.Handle;
        }

        private void Fingerprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Stop();
        }

        private void tBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }
    }
}
