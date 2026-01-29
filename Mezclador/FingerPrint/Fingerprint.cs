
using DPFP;
using DPFP.Capture;

namespace Mezclador
{
	public partial class Fingerprint : Form, DPFP.Capture.EventHandler
	{
		public Fingerprint()
		{
			InitializeComponent();
		}
		protected virtual void Init()
		{
			try
			{
				Capturer = new Capture();               // Create a capture operation.

				if (null != Capturer)
					Capturer.EventHandler = this;                   // Subscribe for capturing events.
				else
					SetPrompt("No se puede iniciar la operacion de captura");
			}
			catch
			{
				MessageBox.Show("No se puede iniciar la operacion de captura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected virtual void Process(Sample Sample)
		{
			// Draw fingerprint sample image.
			DrawPicture(ConvertSampleToBitmap(Sample));
		}

		protected void Start()
		{
			if (null != Capturer)
			{
				try
				{
					Capturer.StartCapture();
					SetPrompt("Escanea tu huella.");
				}
				catch
				{
					SetPrompt("No se puede iniciar la captura.");
				}
			}
		}

		protected void Stop()
		{
			if (null != Capturer)
			{
				try
				{
					Capturer.StopCapture();
				}
				catch
				{
					SetPrompt("No se puede terminar la captura.");
				}
			}
		}
		public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
		{
			//MakeReport("The fingerprint sample was captured.");
			SetPrompt("La huella fue capturada.");
			Process(Sample);
		}

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

		public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
		{
			if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
				MakeReport("La calidad de la muestra de la huella es buena.");
			else
				MakeReport("La calidad de la muestra de la huella es mala.");
		}


		protected void SetPrompt(string prompt)
		{
			this.Invoke(new Function(delegate ()
			{
				Prompt.Text = prompt;
			}));
		}

		protected void SetStatus(string status)
		{
			this.Invoke(new Function(delegate ()
			{
				StatusLine.Text = status;
			}));
		}
		protected Bitmap ConvertSampleToBitmap(Sample Sample)
		{
			SampleConversion Convertor = new();  // Create a sample convertor.
			Bitmap bitmap = null;
			Convertor.ConvertToPicture(Sample, ref bitmap);
			return bitmap;
		}

		protected FeatureSet ExtractFeatures(Sample Sample, DPFP.Processing.DataPurpose Purpose)
		{
			DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
			CaptureFeedback feedback = CaptureFeedback.None;
			FeatureSet features = new();
			Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
			if (feedback == CaptureFeedback.Good)
				return features;
			else
				return null;
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

		private Capture Capturer;

		private void Fingerprint_Load(object sender, EventArgs e)
		{
			Init();
			Start();
		}

		private void Fingerprint_FormClosed(object sender, FormClosedEventArgs e)
		{
			Stop();
		}

		private void tBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void btnPassword_Click(object sender, EventArgs e)
		{

		}
	}
}
