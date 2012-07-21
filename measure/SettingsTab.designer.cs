namespace measure
{
    partial class SettingsTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_keithley_com = new System.Windows.Forms.Label();
            this.tab_control_settings = new System.Windows.Forms.TabControl();
            this.tab_page_keithley = new System.Windows.Forms.TabPage();
            this.label_keithley_com_response = new System.Windows.Forms.Label();
            this.combo_box_keithley_stop_bits = new System.Windows.Forms.ComboBox();
            this.combo_box_keithley_data_bits = new System.Windows.Forms.ComboBox();
            this.combo_box_keithley_com_port = new System.Windows.Forms.ComboBox();
            this.button_keithley_test_connection = new System.Windows.Forms.Button();
            this.label_keithley_parity = new System.Windows.Forms.Label();
            this.combo_box_keithley_parity = new System.Windows.Forms.ComboBox();
            this.label_keithley_flow_control = new System.Windows.Forms.Label();
            this.combo_box_keithley_flow_control = new System.Windows.Forms.ComboBox();
            this.label_keithley_stop_bits = new System.Windows.Forms.Label();
            this.combo_box_keithley_speed = new System.Windows.Forms.ComboBox();
            this.label_keithley_databits = new System.Windows.Forms.Label();
            this.label_keithley_com_speed = new System.Windows.Forms.Label();
            this.button_settings_ok = new System.Windows.Forms.Button();
            this.button_setiings_cancel = new System.Windows.Forms.Button();
            this.tab_control_settings.SuspendLayout();
            this.tab_page_keithley.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_keithley_com
            // 
            this.label_keithley_com.AutoSize = true;
            this.label_keithley_com.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_keithley_com.Location = new System.Drawing.Point(28, 27);
            this.label_keithley_com.Name = "label_keithley_com";
            this.label_keithley_com.Size = new System.Drawing.Size(110, 17);
            this.label_keithley_com.TabIndex = 0;
            this.label_keithley_com.Text = "COM port #: ";
            // 
            // tab_control_settings
            // 
            this.tab_control_settings.Controls.Add(this.tab_page_keithley);
            this.tab_control_settings.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tab_control_settings.Location = new System.Drawing.Point(12, 12);
            this.tab_control_settings.Name = "tab_control_settings";
            this.tab_control_settings.SelectedIndex = 0;
            this.tab_control_settings.Size = new System.Drawing.Size(424, 332);
            this.tab_control_settings.TabIndex = 7;
            // 
            // tab_page_keithley
            // 
            this.tab_page_keithley.Controls.Add(this.label_keithley_com_response);
            this.tab_page_keithley.Controls.Add(this.combo_box_keithley_stop_bits);
            this.tab_page_keithley.Controls.Add(this.combo_box_keithley_data_bits);
            this.tab_page_keithley.Controls.Add(this.combo_box_keithley_com_port);
            this.tab_page_keithley.Controls.Add(this.button_keithley_test_connection);
            this.tab_page_keithley.Controls.Add(this.label_keithley_parity);
            this.tab_page_keithley.Controls.Add(this.combo_box_keithley_parity);
            this.tab_page_keithley.Controls.Add(this.label_keithley_flow_control);
            this.tab_page_keithley.Controls.Add(this.combo_box_keithley_flow_control);
            this.tab_page_keithley.Controls.Add(this.label_keithley_stop_bits);
            this.tab_page_keithley.Controls.Add(this.combo_box_keithley_speed);
            this.tab_page_keithley.Controls.Add(this.label_keithley_databits);
            this.tab_page_keithley.Controls.Add(this.label_keithley_com_speed);
            this.tab_page_keithley.Controls.Add(this.label_keithley_com);
            this.tab_page_keithley.Location = new System.Drawing.Point(4, 25);
            this.tab_page_keithley.Name = "tab_page_keithley";
            this.tab_page_keithley.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_keithley.Size = new System.Drawing.Size(416, 303);
            this.tab_page_keithley.TabIndex = 0;
            this.tab_page_keithley.Text = "Keithley 6485";
            this.tab_page_keithley.UseVisualStyleBackColor = true;
            // 
            // label_keithley_com_response
            // 
            this.label_keithley_com_response.AutoSize = true;
            this.label_keithley_com_response.Location = new System.Drawing.Point(28, 208);
            this.label_keithley_com_response.Name = "label_keithley_com_response";
            this.label_keithley_com_response.Size = new System.Drawing.Size(0, 16);
            this.label_keithley_com_response.TabIndex = 22;
            // 
            // combo_box_keithley_stop_bits
            // 
            this.combo_box_keithley_stop_bits.FormattingEnabled = true;
            this.combo_box_keithley_stop_bits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.combo_box_keithley_stop_bits.Location = new System.Drawing.Point(255, 117);
            this.combo_box_keithley_stop_bits.Name = "combo_box_keithley_stop_bits";
            this.combo_box_keithley_stop_bits.Size = new System.Drawing.Size(121, 24);
            this.combo_box_keithley_stop_bits.TabIndex = 21;
            // 
            // combo_box_keithley_data_bits
            // 
            this.combo_box_keithley_data_bits.FormattingEnabled = true;
            this.combo_box_keithley_data_bits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.combo_box_keithley_data_bits.Location = new System.Drawing.Point(255, 88);
            this.combo_box_keithley_data_bits.Name = "combo_box_keithley_data_bits";
            this.combo_box_keithley_data_bits.Size = new System.Drawing.Size(121, 24);
            this.combo_box_keithley_data_bits.TabIndex = 20;
            // 
            // combo_box_keithley_com_port
            // 
            this.combo_box_keithley_com_port.FormattingEnabled = true;
            this.combo_box_keithley_com_port.Location = new System.Drawing.Point(256, 27);
            this.combo_box_keithley_com_port.Name = "combo_box_keithley_com_port";
            this.combo_box_keithley_com_port.Size = new System.Drawing.Size(121, 24);
            this.combo_box_keithley_com_port.TabIndex = 19;
            // 
            // button_keithley_test_connection
            // 
            this.button_keithley_test_connection.Location = new System.Drawing.Point(153, 262);
            this.button_keithley_test_connection.Name = "button_keithley_test_connection";
            this.button_keithley_test_connection.Size = new System.Drawing.Size(132, 23);
            this.button_keithley_test_connection.TabIndex = 18;
            this.button_keithley_test_connection.Text = "Test connection";
            this.button_keithley_test_connection.UseVisualStyleBackColor = true;
            this.button_keithley_test_connection.Click += new System.EventHandler(this.button_keithley_test_connection_Click);
            // 
            // label_keithley_parity
            // 
            this.label_keithley_parity.AutoSize = true;
            this.label_keithley_parity.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label_keithley_parity.Location = new System.Drawing.Point(28, 151);
            this.label_keithley_parity.Name = "label_keithley_parity";
            this.label_keithley_parity.Size = new System.Drawing.Size(59, 17);
            this.label_keithley_parity.TabIndex = 16;
            this.label_keithley_parity.Text = "Parity:";
            // 
            // combo_box_keithley_parity
            // 
            this.combo_box_keithley_parity.FormattingEnabled = true;
            this.combo_box_keithley_parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.combo_box_keithley_parity.Location = new System.Drawing.Point(256, 148);
            this.combo_box_keithley_parity.Name = "combo_box_keithley_parity";
            this.combo_box_keithley_parity.Size = new System.Drawing.Size(121, 24);
            this.combo_box_keithley_parity.TabIndex = 17;
            // 
            // label_keithley_flow_control
            // 
            this.label_keithley_flow_control.AutoSize = true;
            this.label_keithley_flow_control.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label_keithley_flow_control.Location = new System.Drawing.Point(29, 182);
            this.label_keithley_flow_control.Name = "label_keithley_flow_control";
            this.label_keithley_flow_control.Size = new System.Drawing.Size(111, 17);
            this.label_keithley_flow_control.TabIndex = 14;
            this.label_keithley_flow_control.Text = "Flow control:";
            // 
            // combo_box_keithley_flow_control
            // 
            this.combo_box_keithley_flow_control.FormattingEnabled = true;
            this.combo_box_keithley_flow_control.Items.AddRange(new object[] {
            "None",
            "XON/XOFF",
            "RTS/CTS"});
            this.combo_box_keithley_flow_control.Location = new System.Drawing.Point(256, 179);
            this.combo_box_keithley_flow_control.Name = "combo_box_keithley_flow_control";
            this.combo_box_keithley_flow_control.Size = new System.Drawing.Size(121, 24);
            this.combo_box_keithley_flow_control.TabIndex = 15;
            this.combo_box_keithley_flow_control.Text = "XON/XOFF";
            // 
            // label_keithley_stop_bits
            // 
            this.label_keithley_stop_bits.AutoSize = true;
            this.label_keithley_stop_bits.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label_keithley_stop_bits.Location = new System.Drawing.Point(29, 120);
            this.label_keithley_stop_bits.Name = "label_keithley_stop_bits";
            this.label_keithley_stop_bits.Size = new System.Drawing.Size(83, 17);
            this.label_keithley_stop_bits.TabIndex = 13;
            this.label_keithley_stop_bits.Text = "Stop bits:";
            // 
            // combo_box_keithley_speed
            // 
            this.combo_box_keithley_speed.FormattingEnabled = true;
            this.combo_box_keithley_speed.Items.AddRange(new object[] {
            "9600",
            "57600"});
            this.combo_box_keithley_speed.Location = new System.Drawing.Point(256, 56);
            this.combo_box_keithley_speed.Name = "combo_box_keithley_speed";
            this.combo_box_keithley_speed.Size = new System.Drawing.Size(121, 24);
            this.combo_box_keithley_speed.TabIndex = 11;
            // 
            // label_keithley_databits
            // 
            this.label_keithley_databits.AutoSize = true;
            this.label_keithley_databits.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label_keithley_databits.Location = new System.Drawing.Point(29, 91);
            this.label_keithley_databits.Name = "label_keithley_databits";
            this.label_keithley_databits.Size = new System.Drawing.Size(82, 17);
            this.label_keithley_databits.TabIndex = 10;
            this.label_keithley_databits.Text = "Data bits:";
            // 
            // label_keithley_com_speed
            // 
            this.label_keithley_com_speed.AutoSize = true;
            this.label_keithley_com_speed.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label_keithley_com_speed.Location = new System.Drawing.Point(28, 60);
            this.label_keithley_com_speed.Name = "label_keithley_com_speed";
            this.label_keithley_com_speed.Size = new System.Drawing.Size(122, 17);
            this.label_keithley_com_speed.TabIndex = 8;
            this.label_keithley_com_speed.Text = "Speed (baud):";
            // 
            // button_settings_ok
            // 
            this.button_settings_ok.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_settings_ok.Location = new System.Drawing.Point(272, 350);
            this.button_settings_ok.Name = "button_settings_ok";
            this.button_settings_ok.Size = new System.Drawing.Size(75, 23);
            this.button_settings_ok.TabIndex = 8;
            this.button_settings_ok.Text = "OK";
            this.button_settings_ok.UseVisualStyleBackColor = true;
            this.button_settings_ok.Click += new System.EventHandler(this.button_settings_ok_Click);
            // 
            // button_setiings_cancel
            // 
            this.button_setiings_cancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_setiings_cancel.Location = new System.Drawing.Point(358, 350);
            this.button_setiings_cancel.Name = "button_setiings_cancel";
            this.button_setiings_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_setiings_cancel.TabIndex = 9;
            this.button_setiings_cancel.Text = "Cancel";
            this.button_setiings_cancel.UseVisualStyleBackColor = true;
            this.button_setiings_cancel.Click += new System.EventHandler(this.button_setiings_cancel_Click);
            // 
            // SettingsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 385);
            this.Controls.Add(this.button_setiings_cancel);
            this.Controls.Add(this.button_settings_ok);
            this.Controls.Add(this.tab_control_settings);
            this.Name = "SettingsTab";
            this.Text = "Settings";
            this.tab_control_settings.ResumeLayout(false);
            this.tab_page_keithley.ResumeLayout(false);
            this.tab_page_keithley.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_keithley_com;
        private System.Windows.Forms.TabControl tab_control_settings;
        private System.Windows.Forms.TabPage tab_page_keithley;
        private System.Windows.Forms.Button button_settings_ok;
        private System.Windows.Forms.Button button_setiings_cancel;
        private System.Windows.Forms.ComboBox combo_box_keithley_speed;
        private System.Windows.Forms.Label label_keithley_databits;
        private System.Windows.Forms.Label label_keithley_com_speed;
        private System.Windows.Forms.Label label_keithley_stop_bits;
        private System.Windows.Forms.Label label_keithley_parity;
        private System.Windows.Forms.ComboBox combo_box_keithley_parity;
        private System.Windows.Forms.Label label_keithley_flow_control;
        private System.Windows.Forms.ComboBox combo_box_keithley_flow_control;
        private System.Windows.Forms.Button button_keithley_test_connection;
        private System.Windows.Forms.ComboBox combo_box_keithley_com_port;
        private System.Windows.Forms.ComboBox combo_box_keithley_stop_bits;
        private System.Windows.Forms.ComboBox combo_box_keithley_data_bits;
        private System.Windows.Forms.Label label_keithley_com_response;
    }
}