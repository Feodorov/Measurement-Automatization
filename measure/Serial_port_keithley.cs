using System;
using System.IO.Ports;
using NLog;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace measure
{
    public sealed class Serial_port_keithley
    {
        public delegate void ResultDelegate(Object value);
        private static ResultDelegate callback;

        public static SerialPort Instance
        {
            get
            {
                return instance;
            }
        }

        public static void setCallback(ResultDelegate callback)
        {
            Serial_port_keithley.callback = callback;
        }

        private Serial_port_keithley() { }

        public static bool try_to_open_com_port()
        {
            if (false == instance.IsOpen)
            {
                instance.PortName = measure.Properties.Settings.Default.keithley_com_port;
                instance.BaudRate = measure.Properties.Settings.Default.keithley_speed;
                instance.Parity = measure.Properties.Settings.Default.keithley_parity;
                instance.DataBits = measure.Properties.Settings.Default.keithley_data_bits;
                instance.StopBits = measure.Properties.Settings.Default.keithley_stop_bits;
                instance.Handshake = measure.Properties.Settings.Default.keithley_flow_control;
                instance.ReceivedBytesThreshold = 43;
                instance.DiscardNull = true;
                instance.DataReceived += new SerialDataReceivedEventHandler(instance_DataReceived);
                try
                {
                    instance.Open();
                    instance.NewLine = "\r";
                    instance.ReadTimeout = System.Int32.MaxValue;
                    return true;
                }
                catch (System.Exception ex)
                {
                    logger.Error("Com port open error: " + ex.ToString());
                    return false;
                }
            }
            else return true;
        }


        private static void instance_DataReceived(object sender, EventArgs e)
        {
            char[] input_buffer = new char[43];
            Instance.Read(input_buffer, 0, input_buffer.Length);
            logger.Debug("Data from buffer: " + new String(input_buffer) + "\n");

            var regex_pairs = new Regex(@"[+-][0-9].[0-9]*E[+-][0-9]*");
            MatchCollection MatchList = regex_pairs.Matches(new String(input_buffer));
            if (MatchList.Count != 3)
                return;
            String response;
            if (MatchList[0].ToString().Contains("E+37")) //E+37 spoils all graphs
                response = "0.0A," + MatchList[1] + "," + MatchList[2];
            else response = MatchList[0] + "A," + MatchList[1] + "," + MatchList[2];
            lock (TransientSession.mutex)
            {
                TransientSession.currentTick++;
                if (TransientSession.isReady == false && TransientSession.currentTick == 1 &&
                    TransientSession.isFirstSetOfCommands == true)
                {
                    NumberStyles style = NumberStyles.AllowExponent | NumberStyles.Number;
                    System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                
                    TransientSession.measurement_start_time = Double.Parse(MatchList[1].ToString(), style);
                }
                    //TODO check if this equality is true
                if(TransientSession.currentTick == TransientSession.counterMax)
                    TransientSession.isReady = true;
            }
            callback(response);
        }
        private static SerialPort instance = new SerialPort();
        private static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
