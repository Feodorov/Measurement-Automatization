using System;
using System.IO.Ports;
using NLog;

namespace measure
{
    public sealed class Serial_port_agilent
    {
        public static SerialPort Instance
        {
            get
            {
                return instance;
            }
        }

        private Serial_port_agilent()
        {

        }

        public static bool try_to_open_com_port()
        {
            if (false == instance.IsOpen)
            {
                instance.PortName = measure.Properties.Settings.Default.agilent_com_port;
                instance.BaudRate = measure.Properties.Settings.Default.agilent_speed;
                instance.Parity = measure.Properties.Settings.Default.agilent_parity;
                instance.DataBits = measure.Properties.Settings.Default.agilent_data_bits;
                instance.StopBits = measure.Properties.Settings.Default.agilent_stop_bits;
                instance.Handshake = measure.Properties.Settings.Default.agilent_flow_control;
                try
                {
                    instance.Open();
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
        private static SerialPort instance = new SerialPort();
        private static Logger logger = LogManager.GetCurrentClassLogger();
    }
}