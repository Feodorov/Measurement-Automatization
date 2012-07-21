using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using ZedGraph;
using NLog;
using System.Text.RegularExpressions;

namespace measure
{
    public class TransientSession
    {
        public static double measurement_start_time;
        public static int currentTick;
        public static int counterMax;
        public static bool isReady;
        public static bool isFirstSetOfCommands;
        public static double voltage;
        public static readonly object mutex = new object();
    }
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Serial_port_keithley.setCallback(process_keithley_output);
            GraphPane pane_it = this.ZedGraph_I_t.GraphPane;
            pane_it.XAxis.Title = new AxisLabel("t, ms", "Verdana", (float)14, Color.Black, true, false, false);
            pane_it.YAxis.Title = new AxisLabel("I, A", "Verdana", (float)14, Color.Black, true, false, false);
            pane_it.Title.Text = "Transient current I(t)"; ZedGraph_I_t.AxisChange();
            ZedGraph_I_t.Invalidate();
            GraphPane pane_iv = this.ZedGraph_I_V.GraphPane;
            pane_iv.XAxis.Title = new AxisLabel("U, V", "Verdana", (float)14, Color.Black, true, false, false);
            pane_iv.YAxis.Title = new AxisLabel("I, A", "Verdana", (float)14, Color.Black, true, false, false);
            pane_iv.Title.Text = "Volt-Ampere Characteristic I(V)";
            ZedGraph_I_V.AxisChange();
            ZedGraph_I_V.Invalidate();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            logger.Info("Application starts");
        }

        private void strip_item_settings_Click(object sender, EventArgs e)
        {
            SettingsTab settings = new SettingsTab();
            settings.ShowDialog(this);
        }

        private void strip_item_exit_Click(object sender, EventArgs e)
        {
            logger.Info("Application stops");
            this.Close();
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Logger data_logger = LogManager.GetLogger("data_logger");

        private bool check_if_row_is_empty(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
                if (null == cell.Value) return true;
            return false;
        }
        private void button_start_transient_Click(object sender, EventArgs e)
        {
            this.keithley_command_line.clear();
            this.data_grid_view_keithley.Sort(this.data_grid_view_keithley.Columns[0], ListSortDirection.Ascending);

            int index = 0;
            foreach (DataGridViewRow row in this.data_grid_view_keithley.Rows)
            {
                if (!check_if_row_is_empty(row))
                {
                    try
                    {
                        voltage_params param = new voltage_params();
                        param.isSweepModeUsed = false;
                        param.const_voltage = Convert.ToDouble(row.Cells[1].Value.ToString());
                        Keithley_command command = new Keithley_command(param, row.Cells[3].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
                        this.keithley_command_line.add_command(index, command);
                        index++;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message + " Try another value.");
                        return;
                    }
                }
            }
            ObjectDelegate del = new ObjectDelegate(process_keithley_output);
            if (this.keithley_thread == null || !this.keithley_thread.IsAlive)
            {
                this.keithley_thread = new Thread(new ParameterizedThreadStart(this.keithley_work));
                this.keithley_thread.Start(del);
            }
        }

        private void button_meas_keithley_clear_Click(object sender, EventArgs e)
        {
            this.data_grid_view_keithley.RowCount = 1;
            this.data_grid_view_keithley.Rows.Clear();
            this.text_box_keithley_output.Clear();
            GraphPane pane = this.ZedGraph_I_t.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            this.ZedGraph_I_t.AxisChange();
            this.ZedGraph_I_t.Invalidate();
            this.list_keithley.Clear();
        }

        private void button_meas_agilent_clear_Click(object sender, EventArgs e)
        {
            this.data_grid_view_agilent.RowCount = 1;
            this.data_grid_view_agilent.Rows.Clear();
            this.text_box_agilent_output.Clear();
            GraphPane pane = this.ZedGraph_I_V.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            this.ZedGraph_I_V.AxisChange();
            this.ZedGraph_I_V.Invalidate();
            this.list_agilent.Clear();
        }

        private void button_keithley_autoscale_Click(object sender, EventArgs e)
        {
            GraphPane pane = this.ZedGraph_I_t.GraphPane;
            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            this.ZedGraph_I_t.AxisChange();
            this.ZedGraph_I_t.Invalidate();
        }

        private void button_agilent_autoscale_Click(object sender, EventArgs e)
        {
            GraphPane pane = ZedGraph_I_V.GraphPane;
            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            ZedGraph_I_V.AxisChange();
            ZedGraph_I_V.Invalidate();
        }
        private Command_line keithley_command_line = new Command_line();

        private Thread keithley_thread, agilent_thread;
        public static void clear_buffer_keithley()
        {
            SerialPort keithley = Serial_port_keithley.Instance;
            if (false == Serial_port_keithley.try_to_open_com_port()) return;

            //TODO any other way to clear the output queue?
            keithley.WriteLine("TRAC:CLE"); //page 6-3 of User's Guide
            char[] clear_the_buff = new char[256];
            if (keithley.BytesToRead > 0)
                while (keithley.Read(clear_the_buff, 0, clear_the_buff.Length) == clear_the_buff.Length) { }
        }
        private void keithley_work(object obj)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                List<List<String>> line = this.keithley_command_line.get_command_string();
                Main.clear_buffer_keithley();
                ObjectDelegate del = (ObjectDelegate)obj;
                SerialPort keithley = Serial_port_keithley.Instance;

                if (false == Serial_port_keithley.try_to_open_com_port()) return;

                int index = 0;
                TransientSession.isFirstSetOfCommands = true;
                foreach (List<String> command_list in line)
                {
                    clear_buffer_keithley();
                    String voltage_command = command_list[0];

                    foreach (String command in command_list)
                    {
                        keithley.WriteLine(command);
                        if (command.Contains("TRIG:COUN"))
                        {
                            lock (TransientSession.mutex)
                            {
                                String[] num_of_ticks = command.Split(' ');
                                TransientSession.voltage = Convert.ToDouble(this.data_grid_view_keithley.Rows[index].Cells[1].Value.ToString());
                                TransientSession.counterMax = Int32.Parse(num_of_ticks[1]);
                                TransientSession.currentTick = 0;
                                TransientSession.isReady = false;
                            }
                        }
                    }
                    //wait till current session stops;
                    while (!TransientSession.isReady) ;                  
                    stop_keithley();
                    lock (TransientSession.mutex)
                    {
                        TransientSession.isFirstSetOfCommands = false;
                    }
                    index++;
                }
            }
            catch (ThreadAbortException abortException)
            {
                logger.Info("Measurement stopped: " + (string)abortException.ExceptionState);
            }
            catch (Exception ex)
            {
                logger.Error("Keithley error: " + ex.ToString());
            }
        }
        private delegate void ObjectDelegate(object obj);
        public void process_keithley_output(object obj)
        {
            if (InvokeRequired)
            {
                ObjectDelegate method = new ObjectDelegate(process_keithley_output);
                Invoke(method, obj);
                return;
            }
            try
            {
                NumberStyles style = NumberStyles.AllowExponent | NumberStyles.Number;
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                char[] trim_char = { 'A' };
                //logger.Info("\n Data: " + (String)obj);
                List<String> data = new List<String>(((string)obj).Split(','));

                data[0] = data[0].TrimEnd(trim_char);
                double x = Double.Parse(data[1], style);
                double y = Double.Parse(data[0], style);
                x -= TransientSession.measurement_start_time;

                this.text_box_keithley_output.Text += x.ToString("####.##", CultureInfo.InvariantCulture) + "\t" + y + "\t" + TransientSession.voltage + "\r\n";
                this.text_box_keithley_output.SelectionStart = this.text_box_keithley_output.Text.Length;
                this.text_box_keithley_output.ScrollToCaret();
                this.text_box_keithley_output.Refresh();

                list_keithley.Add(x, y);
                data_logger.Trace("keithley: " + x.ToString("####.##", CultureInfo.InvariantCulture) + " " + y.ToString());
                GraphPane pane = ZedGraph_I_t.GraphPane;

                pane.CurveList.Clear();
                pane.AddCurve("Iph", list_keithley, Color.Blue, SymbolType.Default);
                ZedGraph_I_t.AxisChange();
                ZedGraph_I_t.Invalidate();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString() + "\n Data: " + (String)obj);
            }
        }
        private void stop_keithley()
        {
            SerialPort keithley = Serial_port_keithley.Instance;
            if (false == Serial_port_keithley.try_to_open_com_port()) return;
            char[] ctrlX = new char[1];
            ctrlX[0] = (char)24;
            keithley.WriteLine(new String(ctrlX));
            keithley.WriteLine("*RST");
            keithley.WriteLine("*CLS");
            keithley.WriteLine("TRAC:CLE");
        }
        private void button_stop_transient_Click(object sender, EventArgs e)
        {
            if (!(this.keithley_thread == null))
            {
                this.keithley_thread.Abort("Thread canceled by user");
                this.keithley_thread.Join();
            }
            stop_keithley();
        }

        private void button_keithley_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save Results";
            saveFileDialog1.ShowDialog();

            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.Write(this.text_box_keithley_output.Text);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't save data to file");
                logger.Error("Save output to file error: " + ex.ToString());
            }
        }

        private void button_agilent_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save Results";
            saveFileDialog1.ShowDialog();

            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.Write(this.text_box_agilent_output.Text);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't save data to file");
                logger.Error("Save output to file error: " + ex.ToString());
            }
        }

        private void button_start_vac_Click(object sender, EventArgs e)
        {
            this.data_grid_view_agilent.Sort(this.data_grid_view_agilent.Columns[0], ListSortDirection.Ascending);
            foreach (DataGridViewRow row in this.data_grid_view_agilent.Rows)
            {
                if (!check_if_row_is_empty(row))
                {
                    try
                    {
                        NumberStyles style = NumberStyles.Number;
                        double volt_start = Double.Parse(row.Cells[1].Value.ToString(), style);
                        double volt_stop = Double.Parse(row.Cells[2].Value.ToString(), style);
                        double volt_inc = Double.Parse(row.Cells[3].Value.ToString(), style);
                        double time_inc = Double.Parse(row.Cells[4].Value.ToString(), style);
                        if (time_inc < 0 || volt_inc < 0)
                            throw new Exception("No negative values are allowed.");
                        //if (volt_stop < volt_start) throw new Exception("Start > Stop.");
                        if (volt_inc > Math.Abs(volt_stop - volt_start)) throw new Exception("Voltage step is greater than |V stop - V start|.");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message + " Try another value.");
                        return;
                    }
                }
            }

            ObjectDelegate del = new ObjectDelegate(process_agilent_output);
            if (this.agilent_thread == null || !this.agilent_thread.IsAlive)
            {
                this.agilent_thread = new Thread(new ParameterizedThreadStart(this.agilent_work));
                this.agilent_thread.Start(del);
            }
        }

        private void button_stop_vac_Click(object sender, EventArgs e)
        {
            stop_keithley();
            //TODO send a message to a thread to stop processing
            if (!(this.agilent_thread == null))
            {
                this.agilent_thread.Abort("Thread canceled by user");
                //this.agilent_thread.Join();
            }
        }
        private void agilent_work(object obj)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                SerialPort agilent = Serial_port_agilent.Instance;
                SerialPort keithley = Serial_port_keithley.Instance;
                //if (false == Serial_port_agilent.try_to_open_com_port()) return;
                if (false == Serial_port_keithley.try_to_open_com_port()) return;
                ObjectDelegate del = (ObjectDelegate)obj;
                foreach (DataGridViewRow row in this.data_grid_view_agilent.Rows)
                {
                    if (!check_if_row_is_empty(row))
                    {
                        //try
                        {
                            NumberStyles style = NumberStyles.Number;

                            voltage_params param = new voltage_params();
                            param.isSweepModeUsed = true;
                            param.start_voltage = Double.Parse(row.Cells[1].Value.ToString(), style);
                            param.stop_voltage = Double.Parse(row.Cells[2].Value.ToString(), style);
                            param.step_voltage = Double.Parse(row.Cells[3].Value.ToString(), style);

                            Keithley_command command_keithley = new Keithley_command(param, "0", row.Cells[4].Value.ToString(),
                                row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString());
                    
                            stop_keithley();
                    
                            List<String> command_list = command_keithley.get_command_string();
                            foreach (String command in command_list)
                                keithley.WriteLine(command);

                            String response = param.start_voltage.ToString() + ", " +
                                param.stop_voltage.ToString() + ", " + param.step_voltage.ToString() + ", ";

                            var regex_pairs = new Regex(@"[+-][0-9].[0-9]*E[+-][0-9]*");
                            String fromBuffer = keithley.ReadLine();

                            MatchCollection MatchList = regex_pairs.Matches(fromBuffer);
                            while (MatchList.Count == 0)
                            {
                                fromBuffer = keithley.ReadLine();
                                MatchList = regex_pairs.Matches(fromBuffer);
                            }
                            response += fromBuffer;

                            del.Invoke(response);
                        }
                    }
                }
            }
            catch (ThreadAbortException abortException)
            {
                logger.Info("Measurement stopped: " + (string)abortException.ExceptionState);
            }
            catch (Exception ex)
            {
                logger.Error("Agilent error: " + ex.ToString());
            }
        }

        private void process_agilent_output(object obj)
        {
            if (InvokeRequired)
            {
                ObjectDelegate method = new ObjectDelegate(process_agilent_output);
                Invoke(method, obj);
                return;
            }
            List<String> data = new List<String>(((String)obj.ToString()).Split(',')); ;
            int j = 0;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                NumberStyles volt_style = NumberStyles.Number;
                double volt_start = Double.Parse(data[0], volt_style);
                data.RemoveAt(0);
                double volt_stop = Double.Parse(data[0], volt_style);
                data.RemoveAt(0);
                double volt_inc = Double.Parse(data[0], volt_style);
                data.RemoveAt(0);

                for (int i = data.Count - 1; i > 1; i -= 3)
                    data.RemoveAt(i);

                char[] trim_char = { 'A' };

                NumberStyles style = NumberStyles.AllowExponent | NumberStyles.Number;
                if (volt_start < volt_stop)
                {
                    for (double i = volt_start; i <= volt_stop; i += volt_inc)
                    {
                        this.text_box_agilent_output.Text += i + "\t" + data[j] + "\r\n";
                        data[j] = data[j].TrimEnd(trim_char);
                        double x = i;
                        double y = Double.Parse(data[j], style);
                        list_agilent.Add(x, y);
                        data_logger.Trace("agilent: " + x.ToString() + " " + y.ToString());
                        this.text_box_agilent_output.SelectionStart = this.text_box_agilent_output.Text.Length;
                        this.text_box_agilent_output.ScrollToCaret();
                        this.text_box_agilent_output.Refresh();
                        j += 2;
                    }
                }
                else
                {
                    for (double i = volt_start; i >= volt_stop; i -= volt_inc)
                    {
                        this.text_box_agilent_output.Text += i + "\t" + data[j] + "\r\n";
                        data[j] = data[j].TrimEnd(trim_char);
                        double x = i;
                        double y = Double.Parse(data[j], style);
                        list_agilent.Add(x, y);
                        data_logger.Trace("agilent: " + x.ToString() + " " + y.ToString());
                        this.text_box_agilent_output.SelectionStart = this.text_box_agilent_output.Text.Length;
                        this.text_box_agilent_output.ScrollToCaret();
                        this.text_box_agilent_output.Refresh();
                        j += 2;
                    }
                }
                GraphPane pane = ZedGraph_I_V.GraphPane;
                pane.AddCurve("I", list_agilent, Color.Blue, SymbolType.Default);
                ZedGraph_I_V.AxisChange();
                ZedGraph_I_V.Invalidate();
            }
            catch (System.Exception)
            {
                logger.Debug("Data: " + data[j]);
            }
        }
        PointPairList list_keithley = new PointPairList();
        PointPairList list_agilent = new PointPairList();
    }
}
