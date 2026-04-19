using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.FingerPrint
{
    public static class FingerService
    {
        public static IntPtr mDevHandle = IntPtr.Zero;
        public static IntPtr mDBHandle = IntPtr.Zero;
        public static IntPtr FormHandle = IntPtr.Zero;
        public static bool bIsTimeToDie = false;
        public static bool IsRegister = false;
        public static bool RegisterSuccess = false;
        public static bool IsInitialized = false;
        //public static bool IsOpen = false;
        public static bool bIdentify = true;
        public static byte[] FPBuffer;
        public static int RegisterCount = 0;
        public const int REGISTER_FINGER_COUNT = 3;

        public static byte[][] RegTmps = new byte[3][];
        public static byte[] RegTmp = new byte[2048];
        public static byte[] CapTmp = new byte[2048];
        public static int cbCapTmp = 2048;
        public static int cbRegTmp = 0;
        public static int iFid = 1;
        static Thread captureThread = null;

        public static int mfpWidth = 0;
        public static int mfpHeight = 0;

        public const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public static void InitZK()
        {
            if (IsInitialized)
                return;
            bIdentify = false;
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        //cmbIdx.Items.Add(i.ToString());
                    }
                    //cmbIdx.SelectedIndex = 0;
                    //bnInit.Enabled = false;
                    //bnFree.Enabled = true;
                    //bnOpen.Enabled = true;
                }
                else
                {
                    zkfp2.Terminate();
                    //MessageBox.Show("No se pudo conectar el lector de huella vuelva a intentarlo");
                    return;
                }
            }
            else
            {
                //MessageBox.Show("No se pudo conectar el lector de huella vuelva a intentarlo, ret=" + ret + " !");
                return;
            }
            Open();
        }

        private static void Open()
        {
            int ret2 = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(0)))
            {
                MessageBox.Show("No se pudo conectar el lector de huella vuelva a intentarlo");
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("No se pudo conectar el lector de huella vuelva a intentarlo");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }

            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            //MessageBox.Show("Open success");
            IsInitialized = true;
        }
        public static void Register()
        {
            //if (!IsRegister) // no me funciona si cierran la ventana antes de hacer el registro
            if (IsInitialized)
            {
                bIdentify = false;
                IsRegister = true;
                RegisterSuccess = false;
                RegisterCount = 0;
                cbRegTmp = 0;
                //MessageBox.Show("Please press your finger 3 times!");
            }
        }
        public static void Identify()
        {

            if (IsInitialized && !bIdentify)
            {
                bIdentify = true;
                IsRegister = false;
                RegisterSuccess = false;
                RegisterCount = 0;
                cbRegTmp = 0;
                //textRes.Text = "Please press your finger!";
            }
        }
        private static void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }
        //protected override static void DefWndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case MESSAGE_CAPTURED_OK:
        //            {
        //                MemoryStream ms = new MemoryStream();
        //                BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
        //                Bitmap bmp = new Bitmap(ms);
        //                //this.picFPImg.Image = bmp;
        //                if (IsRegister)
        //                {
        //                    int ret = zkfp.ZKFP_ERR_OK;
        //                    int fid = 0, score = 0;
        //                    ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
        //                    if (zkfp.ZKFP_ERR_OK == ret)
        //                    {
        //                        //textRes.Text = "This finger was already register by " + fid + "!";
        //                        return;
        //                    }
        //                    if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
        //                    {
        //                        //textRes.Text = "Please press the same finger 3 times for the enrollment";
        //                        return;
        //                    }
        //                    Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
        //                    String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
        //                    byte[] blob = zkfp2.Base64ToBlob(strBase64);
        //                    RegisterCount++;
        //                    if (RegisterCount >= REGISTER_FINGER_COUNT)
        //                    {
        //                        RegisterCount = 0;
        //                        if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)) &&
        //                               zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBAdd(mDBHandle, iFid, RegTmp)))
        //                        {
        //                            iFid++;
        //                            MessageBox.Show("enroll succ");
        //                        }
        //                        else
        //                        {
        //                            //textRes.Text = "enroll fail, error code=" + ret;
        //                        }
        //                        IsRegister = false;
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        //textRes.Text = "You need to press the " + (REGISTER_FINGER_COUNT - RegisterCount) + " times fingerprint";
        //                    }
        //                }
        //                else
        //                {
        //                    if (cbRegTmp <= 0)
        //                    {
        //                        //textRes.Text = "Please register your finger first!";
        //                        return;
        //                    }
        //                    if (bIdentify)
        //                    {
        //                        int ret = zkfp.ZKFP_ERR_OK;
        //                        int fid = 0, score = 0;
        //                        ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
        //                        if (zkfp.ZKFP_ERR_OK == ret)
        //                        {
        //                            MessageBox.Show("Identify succ, fid= " + fid + ",score=" + score + "!");
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            //textRes.Text = "Identify fail, ret= " + ret;
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
        //                        if (0 < ret)
        //                        {
        //                            MessageBox.Show("Match finger succ, score=" + ret + "!");
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Match finger fail, ret= " + ret);
        //                            return;
        //                        }
        //                    }
        //                }
        //            }
        //            break;

        //        default:
        //            base.DefWndProc(ref m);
        //            break;
        //    }
        //}
        public static void Free()
        {
            zkfp2.Terminate();
        }
        public static void CloseDevice()
        {
            if (IntPtr.Zero != mDevHandle)
            {
                bIsTimeToDie = true;
                Thread.Sleep(1000);
                captureThread.Join();
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                RegisterCount = 0;
                Thread.Sleep(1000);
                zkfp2.Terminate();
                cbRegTmp = 0;
            }
        }
    }
}
