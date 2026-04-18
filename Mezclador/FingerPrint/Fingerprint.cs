
//using DPFP;
//using DPFP.Capture;

using libzkfpcsharp;
using Mezclador.FingerPrint;
using static Mezclador.FingerPrint.FingerService;
using System;
using System.Security.Principal;

namespace Mezclador
{

    public partial class Fingerprint : Form//, DPFP.Capture.EventHandler
    {
        public Fingerprint()
        {
            InitializeComponent();
            Init();
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
                        if (IsRegister)
                        {
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                //textRes.Text = "This finger was already register by " + fid + "!";
                                return;
                            }
                            if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
                            {
                                //textRes.Text = "Please press the same finger 3 times for the enrollment";
                                return;
                            }
                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            RegisterCount++;
                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                RegisterCount = 0;
                                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)) &&
                                       zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBAdd(mDBHandle, iFid, RegTmp)))
                                {
                                    iFid++;
                                    MessageBox.Show("enroll succ");
                                }
                                else
                                {
                                    //textRes.Text = "enroll fail, error code=" + ret;
                                }
                                IsRegister = false;
                                return;
                            }
                            else
                            {
                                //textRes.Text = "You need to press the " + (REGISTER_FINGER_COUNT - RegisterCount) + " times fingerprint";
                            }
                        }
                        else
                        {
                            if (cbRegTmp <= 0)
                            {
                                //textRes.Text = "Please register your finger first!";
                                return;
                            }
                            if (bIdentify)
                            {
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {
                                    MessageBox.Show("Identify succ, fid= " + fid + ",score=" + score + "!");
                                    return;
                                }
                                else
                                {
                                    //textRes.Text = "Identify fail, ret= " + ret;
                                    return;
                                }
                            }
                            else
                            {
                                int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                                if (0 < ret)
                                {
                                    MessageBox.Show("Match finger succ, score=" + ret + "!");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Match finger fail, ret= " + ret);
                                    return;
                                }
                            }
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
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
            MakeReport("Se ha tocado el lector de huellas.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huellas está conectado.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El lector de huellas está desconectado.");
            SetPrompt("El lector de huellas está desconectado.");
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
