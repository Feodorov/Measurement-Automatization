using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using NLog;

namespace measure
{
    public partial class SettingsTab : Form
    {
        public SettingsTab()
        {
            InitializeComponent();
            this.combo_box_keithley_com_port.Items.Clear();
            this.combo_box_keithley_com_port.Items.AddRange(SerialPort.GetPortNames());
            this.combo_box_keithley_com_port.SelectedIndex = this.combo_box_keithley_com_port.FindStringExact(measure.Properties.Settings.Default.keithley_com_port.ToString());
            this.combo_box_keithley_speed.SelectedIndex = this.combo_box_keithley_speed.FindStringExact(measure.Properties.Settings.Default.keithley_speed.ToString());
            this.combo_box_keithley_data_bits.SelectedIndex = this.combo_box_keithley_data_bits.FindStringExact(measure.Properties.Settings.Default.keithley_data_bits.ToString());

            switch (measure.Properties.Settings.Default.keithley_stop_bits.ToString())
            {
                case "One":
                    this.combo_box_keithley_stop_bits.SelectedIndex = this.combo_box_keithley_stop_bits.FindStringExact("1");
                    break;
                case "OnePointFive":
                    this.combo_box_keithley_stop_bits.SelectedIndex = this.combo_box_keithley_stop_bits.FindStringExact("1.5");
                    break;
                case "Two":
                    this.combo_box_keithley_stop_bits.SelectedIndex = this.combo_box_keithley_stop_bits.FindStringExact("2");
                    break;
            }

            this.combo_box_keithley_parity.SelectedIndex = this.combo_box_keithley_parity.FindStringExact(measure.Properties.Settings.Default.keithley_parity.ToString());

            switch (measure.Properties.Settings.Default.keithley_flow_control.ToString())
            {
                case "None":
                    this.combo_box_keithley_flow_control.SelectedIndex = this.combo_box_keithley_flow_control.FindStringExact("None");
                    break;
                case "RequestToSend":
                    this.combo_box_keithley_flow_control.SelectedIndex = this.combo_box_keithley_flow_control.FindStringExact("RTS/CTS");
                    break;
                case "XOnXOff":
                    this.combo_box_keithley_flow_control.SelectedIndex = this.combo_box_keithley_flow_control.FindStringExact("XON/XOFF");
                    break;
            }
            /*
            this.combo_box_agilent_com_port.Items.Clear();
            this.combo_box_agilent_com_port.Items.AddRange(SerialPort.GetPortNames());
            this.combo_box_agilent_com_port.SelectedIndex = this.combo_box_agilent_com_port.FindStringExact(measure.Properties.Settings.Default.agilent_com_port.ToString());
            this.combo_box_agilent_speed.SelectedIndex = this.combo_box_agilent_speed.FindStringExact(measure.Properties.Settings.Default.agilent_speed.ToString());
            this.combo_box_agilent_data_bits.SelectedIndex = this.combo_box_agilent_data_bits.FindStringExact(measure.Properties.Settings.Default.agilent_data_bits.ToString());

            switch (measure.Properties.Settings.Default.agilent_stop_bits.ToString())
            {
                case "One":
                    this.combo_box_agilent_stop_bits.SelectedIndex = this.combo_box_agilent_stop_bits.FindStringExact("1");
                    break;
                case "OnePointFive":
                    this.combo_box_agilent_stop_bits.SelectedIndex = this.combo_box_agilent_stop_bits.FindStringExact("1.5");
                    break;
                case "Two":
                    this.combo_box_agilent_stop_bits.SelectedIndex = this.combo_box_agilent_stop_bits.FindStringExact("2");
                    break;
            }

            this.combo_box_agilent_parity.SelectedIndex = this.combo_box_agilent_parity.FindStringExact(measure.Properties.Settings.Default.agilent_parity.ToString());

            switch (measure.Properties.Settings.Default.agilent_flow_control.ToString())
            {
                case "None":
                    this.combo_box_agilent_flow_control.SelectedIndex = this.combo_box_agilent_flow_control.FindStringExact("None");
                    break;
                case "RequestToSend":
                    this.combo_box_agilent_flow_control.SelectedIndex = this.combo_box_agilent_flow_control.FindStringExact("RTS/CTS");
                    break;
                case "XOnXOff":
                    this.combo_box_agilent_flow_control.SelectedIndex = this.combo_box_agilent_flow_control.FindStringExact("XON/XOFF");
                    break;
            }*/
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private void SaveKeithleyComSettings()
        {
            SerialPort serial_port = Serial_port_keithley.Instance;
            String error_string = "";
            try
            {
                if(!serial_port.IsOpen)
                    serial_port.PortName = combo_box_keithley_com_port.SelectedItem.ToString();
            }
            catch (System.Exception ex)
            {
                error_string += "Wrong COM port number\n";
                logger.Debug("Keithley wrong COM port number: " + ex.ToString());
            }
            try
            {
                serial_port.BaudRate = Convert.ToInt32(combo_box_keithley_speed.SelectedItem.ToString());
            }
            catch (System.Exception ex)
            {
                error_string += "Wrong Speed\n";
                logger.Debug("Keithley wrong Speed: " + ex.ToString());
            }
            try
            {
                serial_port.DataBits = Convert.ToInt32(combo_box_keithley_data_bits.SelectedItem.ToString());
            }
            catch (System.Exception ex)
            {
                error_string += "Wrong Data Bits\n";
                logger.Debug("Keithley wrong Data Bits: " + ex.ToString());
            }
            try
            {
                switch (combo_box_keithley_stop_bits.SelectedItem.ToString())
                {
                    case "1":
                        serial_port.StopBits = StopBits.One;
                        break;
                    case "1.5":
                        serial_port.StopBits = StopBits.OnePointFive;
                        break;
                    case "2":
                        serial_port.StopBits = StopBits.Two;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                error_string += "Wrong Stop Bits\n";
                logger.Debug("Keithley wrong Stop Bits: " + ex.ToString());
            }
            try
            {
                switch (combo_box_keithley_parity.SelectedItem.ToString())
                {
                    case "None":
                        serial_port.Parity = Parity.None;
                        break;
                    case "Even":
                        serial_port.Parity = Parity.Even;
                        break;
                    case "Odd":
                        serial_port.Parity = Parity.Odd;
                        break;
                    case "Space":
                        serial_port.Parity = Parity.Space;
                        break;
                    case "Mark":
                        serial_port.Parity = Parity.Mark;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                error_string += "Wrong Parity\n";
                logger.Debug("Keithley wrong Parity: " + ex.ToString());
            }
            try
            {
                switch (combo_box_keithley_flow_control.SelectedItem.ToString())
                {
                    case "None":
                        serial_port.Handshake = Handshake.None;
                        break;
                    case "XON/XOFF":
                        serial_port.Handshake = Handshake.XOnXOff;
                        break;
                    case "RTS/CTS":
                        serial_port.Handshake = Handshake.RequestToSend;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                error_string += "Wrong Flow Control\n";
                logger.Debug("Keithley wrong Flow Control: " + ex.ToString());
            }
            if (error_string.Length > 0)
            {
                this.label_keithley_com_response.Text = error_string;
                this.label_keithley_com_response.Update();
            }
            measure.Properties.Settings.Default.keithley_com_port = serial_port.PortName;
            measure.Properties.Settings.Default.keithley_speed = serial_port.BaudRate;
            measure.Properties.Settings.Default.keithley_parity = serial_port.Parity;
            measure.Properties.Settings.Default.keithley_data_bits = serial_port.DataBits;
            measure.Properties.Settings.Default.keithley_stop_bits = serial_port.StopBits;
            measure.Properties.Settings.Default.keithley_flow_control = serial_port.Handshake;
            measure.Properties.Settings.Default.Save();
        }

        private void SaveAgilentComSettings()
        {
            /*SerialPort serial_port = Serial_port_agilent.Instance;
            String error_string = "";
            try
            {
                serial_port.PortName = combo_box_agilent_com_port.SelectedItem.ToString();
            }
            catch (System.Exception ex)
            {
                error_string += "Agilent wrong COM port number\n";
                logger.Debug("Agilent wrong COM port number: " + ex.ToString());
            }
            try
            {
                serial_port.BaudRate = Convert.ToInt32(combo_box_agilent_speed.SelectedItem.ToString());
            }
            catch (System.Exception ex)
            {
                error_string += "Agilent wrong Speed\n";
                logger.Debug("Agilent wrong Speed: " + ex.ToString());
            }
            try
            {
                serial_port.DataBits = Convert.ToInt32(combo_box_agilent_data_bits.SelectedItem.ToString());
            }
            catch (System.Exception ex)
            {
                error_string += "Agilent wrong Data Bits\n";
                logger.Debug("Agilent wrong Data Bits: " + ex.ToString());
            }
            try
            {
                switch (combo_box_agilent_stop_bits.SelectedItem.ToString())
                {
                    case "1":
                        serial_port.StopBits = StopBits.One;
                        break;
                    case "1.5":
                        serial_port.StopBits = StopBits.OnePointFive;
                        break;
                    case "2":
                        serial_port.StopBits = StopBits.Two;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                error_string += "Agilent wrong Stop Bits\n";
                logger.Debug("Agilent wrong Stop Bits: " + ex.ToString());
            }
            try
            {
                switch (combo_box_agilent_parity.SelectedItem.ToString())
                {
                    case "None":
                        serial_port.Parity = Parity.None;
                        break;
                    case "Even":
                        serial_port.Parity = Parity.Even;
                        break;
                    case "Odd":
                        serial_port.Parity = Parity.Odd;
                        break;
                    case "Space":
                        serial_port.Parity = Parity.Space;
                        break;
                    case "Mark":
                        serial_port.Parity = Parity.Mark;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                error_string += "Agilent wrong Parity\n";
                logger.Debug("Agilent wrong Parity: " + ex.ToString());
            }
            try
            {
                switch (combo_box_agilent_flow_control.SelectedItem.ToString())
                {
                    case "None":
                        serial_port.Handshake = Handshake.None;
                        break;
                    case "XON/XOFF":
                        serial_port.Handshake = Handshake.XOnXOff;
                        break;
                    case "RTS/CTS":
                        serial_port.Handshake = Handshake.RequestToSend;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                error_string += "Agilent wrong Flow Control\n";
                logger.Debug("Agilent wrong Flow Control: " + ex.ToString());
            }
            if (error_string.Length > 0) MessageBox.Show(error_string);
            measure.Properties.Settings.Default.agilent_com_port = serial_port.PortName;
            measure.Properties.Settings.Default.agilent_speed = serial_port.BaudRate;
            measure.Properties.Settings.Default.agilent_parity = serial_port.Parity;
            measure.Properties.Settings.Default.agilent_data_bits = serial_port.DataBits;
            measure.Properties.Settings.Default.agilent_stop_bits = serial_port.StopBits;
            measure.Properties.Settings.Default.agilent_flow_control = serial_port.Handshake;
            measure.Properties.Settings.Default.Save();*/
        }

        private void button_settings_ok_Click(object sender, EventArgs e)
        {
            SaveKeithleyComSettings();
            SaveAgilentComSettings();
            this.Close();
        }
       
        private void button_setiings_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_agilent_test_connection_Click(object sender, EventArgs e)
        {
            /*SaveAgilentComSettings();
            SerialPort agilent = Serial_port_agilent.Instance;
            if (Serial_port_agilent.try_to_open_com_port() == true)
            {
                //Encoding.ASCII.GetBytes("message");
                agilent.WriteLine("*RST");
                agilent.WriteLine(":*IDN?");
                String response = agilent.ReadLine();
                this.label_agilent_com_response.Text = "Response: " + response;
                this.label_agilent_com_response.Update();
            }
            else
            {
                this.label_agilent_com_response.Text = "Failed to connect";
                this.label_agilent_com_response.Update();
            }*/
        }

        private void button_keithley_test_connection_Click(object sender, EventArgs e)
        {
            SaveKeithleyComSettings();
            Main.clear_buffer_keithley();
            SerialPort keithley = Serial_port_keithley.Instance;
            if (Serial_port_keithley.try_to_open_com_port() == true)
            {
                keithley.WriteLine("*RST");
                keithley.WriteLine("*IDN?");
                String response = keithley.ReadLine();           
                this.label_keithley_com_response.Text = response.ToString();
                this.label_keithley_com_response.Update();
            }
            else
            {
                this.label_keithley_com_response.Text = "Failed to connect";
                this.label_keithley_com_response.Update();
            }
        }
    }
}
