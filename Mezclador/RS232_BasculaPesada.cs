using Mezclador.UserConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador
{
    public static class RS232_BasculaPesada
    {
        static int baudRate = 9600;
        static string portName = "";
        public static SerialPort? serialPort = new();
        static int appendCount = 0;
        public static bool? StatusConexion = false;
        public static string receivedData = string.Empty;

        static bool DataCompleted;
        static StringBuilder receivedDataTemp = new();
        static string receivedDataHold = string.Empty;
        public static string weight = string.Empty;
        static DataTable dataTable = new();
        static System.Timers.Timer? timer;
        public static void Initialize()
        {
            timer = new()
            {
                Interval = 500
            };
            timer.Elapsed += Timer_Elapsed;
        }
        public static void Connect()
        {
            serialPort?.Close();
            // Configurar el puerto serie
            portName = UserSettings.COM_BasculaPesada;

            try
            {
                serialPort = new SerialPort(portName, baudRate);
                serialPort.DataReceived += SerialPort_DataReceived;

                serialPort?.Open();
            }
            catch (Exception ex)
            {

            }
        }

        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            StatusConexion = serialPort?.IsOpen;
        }

        public static string[] GetComPorts()
        {
            // Obtener los nombres de los puertos COM disponibles
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length <= 0)
            {
                MessageBox.Show("No se encontraron puertos COM disponibles.");
            }

            return portNames;
        }

        // Manejador de eventos para la recepción de datos
        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);
                string receivedString = Encoding.ASCII.GetString(buffer);
                //receivedData = receivedString;
                try
                {
                    //receivedString = serialPort.ReadLine();
                    //10 los caracteres necesarios para interpretarlos
                    //kg para dato valido en posicion [9] y [10] en ascci es 107 y 103
                    //el primer valor [0] debe ser ascci 32 indicando que no es . ni - ni numero
                    //el peso esta del [3] al [7]

                    //if (receivedString.StartsWith(" WT:"))
                    //{
                    //	receivedData = weight = receivedString.Substring(4).Trim();
                    //}
                    //if (receivedString.Length > 10)
                    //if (receivedString.EndsWith("\r\n"))
                    //{
                    //int index = 0;
                    //if (receivedString.IndexOf('k') > 9 || receivedString.IndexOf('k') < 11)
                    //{

                    if ((receivedString.IndexOf('k') - 6) > 0)
                    {
                        var index = receivedString.IndexOf('k') - 6;
                        if (receivedString[index + 2] == '.')
                            receivedData = weight = receivedString.Substring(index, 5).Trim();
                    }
                    //}
                    //else receivedData = "-";
                }
                catch (Exception ex) { }
            }
        }
        //Debug.WriteLine(weight);
        public static void Close()
        {
            receivedData = "";
            // Cerrar el puerto serie al salir
            try
            {
                if (serialPort is not null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
