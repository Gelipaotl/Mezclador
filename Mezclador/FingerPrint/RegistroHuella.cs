using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mezclador
{
    public partial class RegistroHuella : Fingerprint
    {
        bool CanClose = false;
        public delegate void OnTemplateEventHandler(DPFP.Template template);

        public event OnTemplateEventHandler OnTemplate;
        protected override void Init()
        {
            base.Init();
            base.Text = "Registro de huella";
            // Create an enrollment.
            Enroller = new DPFP.Processing.Enrollment();
            //Enroller.Template = new();
            lblPassword.Visible = false;
            tBoxPassword.Visible = false;
            btnPassword.Visible = false;
            UpdateStatus();
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    MakeReport("Se creó el registro de la huella.");
                    Enroller.AddFeatures(features);     // Add feature set to template.
                }
                finally
                {
                    UpdateStatus();

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            //OnTemplate(Enroller.Template);
                            SetPrompt("Ya puedes cerrar esta ventana.");
                            Stop();
                            CloseForm();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }

        private void UpdateStatus()
        {
            // Show number of samples needed.
            SetStatus(String.Format($"Lecturas restantes: {Enroller.FeaturesNeeded}"));
        }
        private void CloseForm()
        {
            //se utiliza para acceder al form base, si se usa this.Close(); a secas genera exception 
            this.Invoke((MethodInvoker)delegate
            {
                this.Close();
            });
        }
        public DPFP.Processing.Enrollment Enroller;

    }
}
