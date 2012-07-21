using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace measure
{
    class voltage_params
    {
        public bool isSweepModeUsed; //sweep mode for VAC measurements. If false, Voltage is const;
        public double const_voltage;
        public double start_voltage;
        public double stop_voltage;
        public double step_voltage;
    }
    class Keithley_command : Command
    {
        public Keithley_command(voltage_params param, String Duration, String TimeStep, String NPLC, String Range)
        {
            this.voltage = param;
           // if (!this.voltage.isSweepModeUsed && this.voltage.const_voltage > 42) 
             //   throw new Exception("Applied Voltage is higher than maximum allowed 42V.");//page 2-2 of User's Manual - Maximum Applied Voltage
            //if(this.voltage.isSweepModeUsed && (Math.Abs(this.voltage.start_voltage) > 42 || Math.Abs(this.voltage.stop_voltage) > 42))
              //  throw new Exception("Applied Voltage is higher than maximum allowed 42V.");//page 2-2 of User's Manual - Maximum Applied Voltage
            this.duration = Convert.ToInt32(Duration);
            if(!param.isSweepModeUsed)
                if (duration < 1 || duration > 2500) //page 7-7 bottom line
                    throw new Exception("Time value exceeds the limit 2500s");
            this.time_step = Convert.ToDouble(TimeStep.ToString());
            if (time_step < 0 || time_step >= 1000) //page 7-6
                throw new Exception("Step (Delay) value exceeds the limit");
            this.nplc = NPLC; //page 4-5 of instruction manual
            switch (Range)// page 4-2 of instruction manual
            {
                case "2 nA":
                    this.range = "2e-9";
                    break;
                case "20 nA":
                    this.range = "2e-8";
                    break;
                case "200 nA":
                    this.range = "2e-7";
                    break;
                case "2 uA":
                    this.range = "2e-6";
                    break;
                case "20 uA":
                    this.range = "2e-5";
                    break;
                case "200 uA":
                    this.range = "2e-4";
                    break;
                case "2 mA":
                    this.range = "2e-3";
                    break;
                case "20 mA":
                    this.range = "2e-2";
                    break;
                default:
                    break;
            }
            //Page 7-6 contains autodelay settings
            if (this.time_step < delay_nplc_limits[range])
                throw new Exception("NPLC is too small for the selected range/delay.");
            //Page 4-5 One PLC for 50Hz is 20msec. So, NPLC*20msec < step
            if (this.time_step < 0.02 * Double.Parse(this.nplc))
                throw new Exception("step is to small for for the selected NPLC.\nOne PLC for 50Hz is 20msec. So, NPLC*20msec < step.\n");
        }

        public override List<String> get_command_string()
        {
            List<String> command_list = new List<String>();
            if (!voltage.isSweepModeUsed)
            {
                int count = (Convert.ToInt32(duration / time_step));
                command_list.Add("*RST");
                command_list.Add("*CLS");
                command_list.Add("TRAC:CLE");
                command_list.Add("TRAC:TST:FORM DELT");
                command_list.Add("SYST:ZCH ON"); //page 2-15
                command_list.Add("CURR:RANG:AUTO ON");
                command_list.Add("CURR:RANG:AUTO:ULIM " + range.ToString());
                command_list.Add("CURR:NPLC " + nplc.ToString().Replace(',', '.'));
                command_list.Add("DISP:DIG 7");
                command_list.Add("INIT");
                command_list.Add("SYST:ZCOR:ACQ");
                command_list.Add("SYST:ZCOR ON");
                if (voltage.const_voltage != 0)
                {
                    command_list.Add("SOUR:VOLT:RANG 10");
                    command_list.Add("SOUR:VOLT " + voltage.const_voltage.ToString());
                    command_list.Add("SOUR:VOLT:ILIM 2.5E-3");
                }
                command_list.Add("ARM:SOUR IMM");
                command_list.Add("ARM:COUN 1");
                command_list.Add("TRIG:SOUR IMM");
                command_list.Add("TRIG:COUN " + count.ToString());
                command_list.Add("TRIG:DEL " + this.time_step.ToString().Replace(',', '.'));
                if (voltage.const_voltage != 0)
                    command_list.Add("SOUR:VOLT:STAT ON");
                command_list.Add("SYST:ZCH OFF");
                command_list.Add("READ?");
            }
            else
            {
                int count = Convert.ToInt32(Math.Abs(voltage.start_voltage - voltage.stop_voltage) / voltage.step_voltage ) + 1;
                command_list.Add("*RST");
                command_list.Add("*CLS");
                command_list.Add("CURR:RANG:AUTO ON");
                command_list.Add("CURR:RANG:AUTO:ULIM " + range.ToString());
                command_list.Add("CURR:NPLC " + nplc.ToString().Replace(',', '.'));
                command_list.Add("DISP:DIG 7");
                
 
                command_list.Add("SOUR:VOLT:SWE:STAR " + voltage.start_voltage.ToString());
                command_list.Add("SOUR:VOLT:SWE:STOP " + voltage.stop_voltage.ToString());
                command_list.Add("SOUR:VOLT:SWE:STEP " + voltage.step_voltage.ToString());
                command_list.Add("SOUR:VOLT:SWE:DEL " + time_step.ToString());

                command_list.Add("ARM:COUN " + count.ToString());

                command_list.Add("SOUR:VOLT:SWE:INIT");

                command_list.Add("SYST:ZCH OFF");
                command_list.Add("INIT");

                command_list.Add("TRAC:DATA?");
            }

            return command_list;
        }
        private int duration;
        private double time_step;
        private voltage_params voltage;
        private String nplc;
        private String range;
        private Dictionary<String, double> delay_nplc_limits = new Dictionary<String, double>()
        {
            {"2e-9", 0.01}, //10ms
            {"2e-8", 0.01}, //10ms
            {"2e-7", 0.01}, //10ms
            {"2e-6", 0.01}, //10ms
            {"2e-5", 0.005}, //5ms
            {"2e-4", 0.005}, //5ms
            {"2e-3", 0.001}, //1ms
            {"2e-2", 0.0005}, //0.5ms
        };      
    }
}
