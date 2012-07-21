namespace measure
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.strip_item_file = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_item_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_item_options = new System.Windows.Forms.ToolStripMenuItem();
            this.strip_item_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ZedGraph_I_t = new ZedGraph.ZedGraphControl();
            this.ZedGraph_I_V = new ZedGraph.ZedGraphControl();
            this.label_meas_plan = new System.Windows.Forms.Label();
            this.button_start_transient = new System.Windows.Forms.Button();
            this.button_stop_transient = new System.Windows.Forms.Button();
            this.button_stop_vac = new System.Windows.Forms.Button();
            this.button_start_vac = new System.Windows.Forms.Button();
            this.label_meas_keithley_plan = new System.Windows.Forms.Label();
            this.data_grid_view_keithley = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Step_keithley = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPLC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button_meas_keithley_clear = new System.Windows.Forms.Button();
            this.data_grid_view_agilent = new System.Windows.Forms.DataGridView();
            this.button_meas_agilent_clear = new System.Windows.Forms.Button();
            this.button_keithley_autoscale = new System.Windows.Forms.Button();
            this.button_agilent_autoscale = new System.Windows.Forms.Button();
            this.text_box_keithley_output = new System.Windows.Forms.TextBox();
            this.text_box_agilent_output = new System.Windows.Forms.TextBox();
            this.button_keithley_save = new System.Windows.Forms.Button();
            this.button_agilent_save = new System.Windows.Forms.Button();
            this.label_keithley_output_time = new System.Windows.Forms.Label();
            this.label_keithley_output_current = new System.Windows.Forms.Label();
            this.label_keithley_output_voltage = new System.Windows.Forms.Label();
            this.label_agilent_output_voltage = new System.Windows.Forms.Label();
            this.label_agilent_output_current = new System.Windows.Forms.Label();
            this.numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Step_agilent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Increment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPLC_agilent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Range_agilent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menu_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_keithley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_agilent)).BeginInit();
            this.SuspendLayout();
            // 
            // menu_strip
            // 
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_item_file,
            this.strip_item_options});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(1170, 24);
            this.menu_strip.TabIndex = 0;
            this.menu_strip.Text = "menuStrip1";
            // 
            // strip_item_file
            // 
            this.strip_item_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_item_exit});
            this.strip_item_file.Name = "strip_item_file";
            this.strip_item_file.Size = new System.Drawing.Size(35, 20);
            this.strip_item_file.Text = "File";
            // 
            // strip_item_exit
            // 
            this.strip_item_exit.Name = "strip_item_exit";
            this.strip_item_exit.Size = new System.Drawing.Size(103, 22);
            this.strip_item_exit.Text = "Exit";
            this.strip_item_exit.Click += new System.EventHandler(this.strip_item_exit_Click);
            // 
            // strip_item_options
            // 
            this.strip_item_options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_item_settings});
            this.strip_item_options.Name = "strip_item_options";
            this.strip_item_options.Size = new System.Drawing.Size(56, 20);
            this.strip_item_options.Text = "Options";
            // 
            // strip_item_settings
            // 
            this.strip_item_settings.Name = "strip_item_settings";
            this.strip_item_settings.Size = new System.Drawing.Size(124, 22);
            this.strip_item_settings.Text = "Settings";
            this.strip_item_settings.Click += new System.EventHandler(this.strip_item_settings_Click);
            // 
            // ZedGraph_I_t
            // 
            this.ZedGraph_I_t.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.ZedGraph_I_t.Location = new System.Drawing.Point(44, 42);
            this.ZedGraph_I_t.Name = "ZedGraph_I_t";
            this.ZedGraph_I_t.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.ZedGraph_I_t.ScrollGrace = 0;
            this.ZedGraph_I_t.ScrollMaxX = 0;
            this.ZedGraph_I_t.ScrollMaxY = 0;
            this.ZedGraph_I_t.ScrollMaxY2 = 0;
            this.ZedGraph_I_t.ScrollMinX = 0;
            this.ZedGraph_I_t.ScrollMinY = 0;
            this.ZedGraph_I_t.ScrollMinY2 = 0;
            this.ZedGraph_I_t.Size = new System.Drawing.Size(505, 333);
            this.ZedGraph_I_t.TabIndex = 1;
            // 
            // ZedGraph_I_V
            // 
            this.ZedGraph_I_V.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.ZedGraph_I_V.Location = new System.Drawing.Point(596, 42);
            this.ZedGraph_I_V.Name = "ZedGraph_I_V";
            this.ZedGraph_I_V.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.ZedGraph_I_V.ScrollGrace = 0;
            this.ZedGraph_I_V.ScrollMaxX = 0;
            this.ZedGraph_I_V.ScrollMaxY = 0;
            this.ZedGraph_I_V.ScrollMaxY2 = 0;
            this.ZedGraph_I_V.ScrollMinX = 0;
            this.ZedGraph_I_V.ScrollMinY = 0;
            this.ZedGraph_I_V.ScrollMinY2 = 0;
            this.ZedGraph_I_V.Size = new System.Drawing.Size(540, 333);
            this.ZedGraph_I_V.TabIndex = 14;
            // 
            // label_meas_plan
            // 
            this.label_meas_plan.AutoSize = true;
            this.label_meas_plan.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_meas_plan.Location = new System.Drawing.Point(41, 489);
            this.label_meas_plan.Name = "label_meas_plan";
            this.label_meas_plan.Size = new System.Drawing.Size(148, 16);
            this.label_meas_plan.TabIndex = 7;
            this.label_meas_plan.Text = "Measurement plan:";
            // 
            // button_start_transient
            // 
            this.button_start_transient.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start_transient.Location = new System.Drawing.Point(44, 692);
            this.button_start_transient.Name = "button_start_transient";
            this.button_start_transient.Size = new System.Drawing.Size(75, 23);
            this.button_start_transient.TabIndex = 9;
            this.button_start_transient.Text = "Start";
            this.button_start_transient.UseVisualStyleBackColor = true;
            this.button_start_transient.Click += new System.EventHandler(this.button_start_transient_Click);
            // 
            // button_stop_transient
            // 
            this.button_stop_transient.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_stop_transient.Location = new System.Drawing.Point(125, 692);
            this.button_stop_transient.Name = "button_stop_transient";
            this.button_stop_transient.Size = new System.Drawing.Size(75, 23);
            this.button_stop_transient.TabIndex = 10;
            this.button_stop_transient.Text = "Stop";
            this.button_stop_transient.UseVisualStyleBackColor = true;
            this.button_stop_transient.Click += new System.EventHandler(this.button_stop_transient_Click);
            // 
            // button_stop_vac
            // 
            this.button_stop_vac.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_stop_vac.Location = new System.Drawing.Point(700, 692);
            this.button_stop_vac.Name = "button_stop_vac";
            this.button_stop_vac.Size = new System.Drawing.Size(75, 23);
            this.button_stop_vac.TabIndex = 21;
            this.button_stop_vac.Text = "Stop";
            this.button_stop_vac.UseVisualStyleBackColor = true;
            this.button_stop_vac.Click += new System.EventHandler(this.button_stop_vac_Click);
            // 
            // button_start_vac
            // 
            this.button_start_vac.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start_vac.Location = new System.Drawing.Point(619, 692);
            this.button_start_vac.Name = "button_start_vac";
            this.button_start_vac.Size = new System.Drawing.Size(75, 23);
            this.button_start_vac.TabIndex = 20;
            this.button_start_vac.Text = "Start";
            this.button_start_vac.UseVisualStyleBackColor = true;
            this.button_start_vac.Click += new System.EventHandler(this.button_start_vac_Click);
            // 
            // label_meas_keithley_plan
            // 
            this.label_meas_keithley_plan.AutoSize = true;
            this.label_meas_keithley_plan.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_meas_keithley_plan.Location = new System.Drawing.Point(593, 489);
            this.label_meas_keithley_plan.Name = "label_meas_keithley_plan";
            this.label_meas_keithley_plan.Size = new System.Drawing.Size(148, 16);
            this.label_meas_keithley_plan.TabIndex = 18;
            this.label_meas_keithley_plan.Text = "Measurement plan:";
            // 
            // data_grid_view_keithley
            // 
            this.data_grid_view_keithley.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.data_grid_view_keithley.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_grid_view_keithley.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_keithley.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.Voltage,
            this.Step_keithley,
            this.Time,
            this.NPLC,
            this.Range});
            this.data_grid_view_keithley.Location = new System.Drawing.Point(44, 510);
            this.data_grid_view_keithley.Name = "data_grid_view_keithley";
            this.data_grid_view_keithley.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data_grid_view_keithley.Size = new System.Drawing.Size(505, 176);
            this.data_grid_view_keithley.TabIndex = 8;
            // 
            // num
            // 
            this.num.HeaderText = "#";
            this.num.Name = "num";
            this.num.Width = 25;
            // 
            // Voltage
            // 
            this.Voltage.HeaderText = "Volt. (V)";
            this.Voltage.Name = "Voltage";
            this.Voltage.Width = 80;
            // 
            // Step_keithley
            // 
            this.Step_keithley.HeaderText = "Step Δt(s)";
            this.Step_keithley.Name = "Step_keithley";
            this.Step_keithley.Width = 85;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time (s)";
            this.Time.Name = "Time";
            this.Time.Width = 90;
            // 
            // NPLC
            // 
            this.NPLC.HeaderText = "NPLC";
            this.NPLC.Items.AddRange(new object[] {
            "0,01",
            "0,1",
            "1",
            "5"});
            this.NPLC.Name = "NPLC";
            this.NPLC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NPLC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NPLC.Width = 80;
            // 
            // Range
            // 
            this.Range.HeaderText = "Range";
            this.Range.Items.AddRange(new object[] {
            "2 nA",
            "20 nA",
            "200 nA",
            "2 uA",
            "20 uA",
            "200 uA",
            "2 mA",
            "20 mA"});
            this.Range.Name = "Range";
            this.Range.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Range.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Range.Width = 80;
            // 
            // button_meas_keithley_clear
            // 
            this.button_meas_keithley_clear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_meas_keithley_clear.Location = new System.Drawing.Point(206, 692);
            this.button_meas_keithley_clear.Name = "button_meas_keithley_clear";
            this.button_meas_keithley_clear.Size = new System.Drawing.Size(89, 23);
            this.button_meas_keithley_clear.TabIndex = 11;
            this.button_meas_keithley_clear.Text = "Clear All";
            this.button_meas_keithley_clear.UseVisualStyleBackColor = true;
            this.button_meas_keithley_clear.Click += new System.EventHandler(this.button_meas_keithley_clear_Click);
            // 
            // data_grid_view_agilent
            // 
            this.data_grid_view_agilent.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.data_grid_view_agilent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_grid_view_agilent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_agilent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numb,
            this.Start,
            this.Stop,
            this.Step_agilent,
            this.Increment,
            this.NPLC_agilent,
            this.Range_agilent});
            this.data_grid_view_agilent.Location = new System.Drawing.Point(596, 510);
            this.data_grid_view_agilent.Name = "data_grid_view_agilent";
            this.data_grid_view_agilent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data_grid_view_agilent.Size = new System.Drawing.Size(540, 176);
            this.data_grid_view_agilent.TabIndex = 19;
            // 
            // button_meas_agilent_clear
            // 
            this.button_meas_agilent_clear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_meas_agilent_clear.Location = new System.Drawing.Point(781, 692);
            this.button_meas_agilent_clear.Name = "button_meas_agilent_clear";
            this.button_meas_agilent_clear.Size = new System.Drawing.Size(89, 23);
            this.button_meas_agilent_clear.TabIndex = 22;
            this.button_meas_agilent_clear.Text = "Clear All";
            this.button_meas_agilent_clear.UseVisualStyleBackColor = true;
            this.button_meas_agilent_clear.Click += new System.EventHandler(this.button_meas_agilent_clear_Click);
            // 
            // button_keithley_autoscale
            // 
            this.button_keithley_autoscale.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_keithley_autoscale.Location = new System.Drawing.Point(301, 692);
            this.button_keithley_autoscale.Name = "button_keithley_autoscale";
            this.button_keithley_autoscale.Size = new System.Drawing.Size(106, 23);
            this.button_keithley_autoscale.TabIndex = 12;
            this.button_keithley_autoscale.Text = "Scale Graph";
            this.button_keithley_autoscale.UseVisualStyleBackColor = true;
            this.button_keithley_autoscale.Click += new System.EventHandler(this.button_keithley_autoscale_Click);
            // 
            // button_agilent_autoscale
            // 
            this.button_agilent_autoscale.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_agilent_autoscale.Location = new System.Drawing.Point(876, 692);
            this.button_agilent_autoscale.Name = "button_agilent_autoscale";
            this.button_agilent_autoscale.Size = new System.Drawing.Size(106, 23);
            this.button_agilent_autoscale.TabIndex = 23;
            this.button_agilent_autoscale.Text = "Scale Graph";
            this.button_agilent_autoscale.UseVisualStyleBackColor = true;
            this.button_agilent_autoscale.Click += new System.EventHandler(this.button_agilent_autoscale_Click);
            // 
            // text_box_keithley_output
            // 
            this.text_box_keithley_output.Location = new System.Drawing.Point(44, 404);
            this.text_box_keithley_output.Multiline = true;
            this.text_box_keithley_output.Name = "text_box_keithley_output";
            this.text_box_keithley_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_box_keithley_output.Size = new System.Drawing.Size(505, 82);
            this.text_box_keithley_output.TabIndex = 6;
            // 
            // text_box_agilent_output
            // 
            this.text_box_agilent_output.Location = new System.Drawing.Point(596, 404);
            this.text_box_agilent_output.Multiline = true;
            this.text_box_agilent_output.Name = "text_box_agilent_output";
            this.text_box_agilent_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_box_agilent_output.Size = new System.Drawing.Size(540, 82);
            this.text_box_agilent_output.TabIndex = 17;
            // 
            // button_keithley_save
            // 
            this.button_keithley_save.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_keithley_save.Location = new System.Drawing.Point(413, 692);
            this.button_keithley_save.Name = "button_keithley_save";
            this.button_keithley_save.Size = new System.Drawing.Size(111, 23);
            this.button_keithley_save.TabIndex = 13;
            this.button_keithley_save.Text = "Save results";
            this.button_keithley_save.UseVisualStyleBackColor = true;
            this.button_keithley_save.Click += new System.EventHandler(this.button_keithley_save_Click);
            // 
            // button_agilent_save
            // 
            this.button_agilent_save.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_agilent_save.Location = new System.Drawing.Point(989, 692);
            this.button_agilent_save.Name = "button_agilent_save";
            this.button_agilent_save.Size = new System.Drawing.Size(111, 23);
            this.button_agilent_save.TabIndex = 0;
            this.button_agilent_save.Text = "Save results";
            this.button_agilent_save.UseVisualStyleBackColor = true;
            this.button_agilent_save.Click += new System.EventHandler(this.button_agilent_save_Click);
            // 
            // label_keithley_output_time
            // 
            this.label_keithley_output_time.AutoSize = true;
            this.label_keithley_output_time.Location = new System.Drawing.Point(48, 388);
            this.label_keithley_output_time.Name = "label_keithley_output_time";
            this.label_keithley_output_time.Size = new System.Drawing.Size(45, 13);
            this.label_keithley_output_time.TabIndex = 3;
            this.label_keithley_output_time.Text = "time, ms";
            // 
            // label_keithley_output_current
            // 
            this.label_keithley_output_current.AutoSize = true;
            this.label_keithley_output_current.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label_keithley_output_current.Location = new System.Drawing.Point(102, 388);
            this.label_keithley_output_current.Name = "label_keithley_output_current";
            this.label_keithley_output_current.Size = new System.Drawing.Size(54, 13);
            this.label_keithley_output_current.TabIndex = 4;
            this.label_keithley_output_current.Text = "Current, A";
            // 
            // label_keithley_output_voltage
            // 
            this.label_keithley_output_voltage.AutoSize = true;
            this.label_keithley_output_voltage.Location = new System.Drawing.Point(168, 388);
            this.label_keithley_output_voltage.Name = "label_keithley_output_voltage";
            this.label_keithley_output_voltage.Size = new System.Drawing.Size(94, 13);
            this.label_keithley_output_voltage.TabIndex = 5;
            this.label_keithley_output_voltage.Text = "Applied Voltage, V";
            // 
            // label_agilent_output_voltage
            // 
            this.label_agilent_output_voltage.AutoSize = true;
            this.label_agilent_output_voltage.Location = new System.Drawing.Point(616, 388);
            this.label_agilent_output_voltage.Name = "label_agilent_output_voltage";
            this.label_agilent_output_voltage.Size = new System.Drawing.Size(59, 13);
            this.label_agilent_output_voltage.TabIndex = 15;
            this.label_agilent_output_voltage.Text = "Voltage (V)";
            // 
            // label_agilent_output_current
            // 
            this.label_agilent_output_current.AutoSize = true;
            this.label_agilent_output_current.Location = new System.Drawing.Point(718, 388);
            this.label_agilent_output_current.Name = "label_agilent_output_current";
            this.label_agilent_output_current.Size = new System.Drawing.Size(57, 13);
            this.label_agilent_output_current.TabIndex = 16;
            this.label_agilent_output_current.Text = "Current (A)";
            // 
            // numb
            // 
            this.numb.HeaderText = "#";
            this.numb.Name = "numb";
            this.numb.Width = 30;
            // 
            // Start
            // 
            this.Start.HeaderText = "Start (V)";
            this.Start.Name = "Start";
            this.Start.Width = 70;
            // 
            // Stop
            // 
            this.Stop.HeaderText = "Stop (V)";
            this.Stop.Name = "Stop";
            this.Stop.Width = 70;
            // 
            // Step_agilent
            // 
            this.Step_agilent.HeaderText = "Step ΔV (V)";
            this.Step_agilent.Name = "Step_agilent";
            this.Step_agilent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Step_agilent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Step_agilent.Width = 80;
            // 
            // Increment
            // 
            this.Increment.HeaderText = "Step Δt(s)";
            this.Increment.Name = "Increment";
            this.Increment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Increment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Increment.Width = 80;
            // 
            // NPLC_agilent
            // 
            this.NPLC_agilent.HeaderText = "NPLC";
            this.NPLC_agilent.Items.AddRange(new object[] {
            "0,01",
            "0,1",
            "1",
            "5"});
            this.NPLC_agilent.Name = "NPLC_agilent";
            this.NPLC_agilent.Width = 70;
            // 
            // Range_agilent
            // 
            this.Range_agilent.HeaderText = "Range";
            this.Range_agilent.Items.AddRange(new object[] {
            "2 nA",
            "20 nA",
            "200 nA",
            "2 uA",
            "20 uA",
            "200 uA",
            "2 mA",
            "20 mA"});
            this.Range_agilent.Name = "Range_agilent";
            this.Range_agilent.Width = 70;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 723);
            this.Controls.Add(this.label_agilent_output_current);
            this.Controls.Add(this.label_agilent_output_voltage);
            this.Controls.Add(this.label_keithley_output_voltage);
            this.Controls.Add(this.label_keithley_output_current);
            this.Controls.Add(this.label_keithley_output_time);
            this.Controls.Add(this.button_agilent_save);
            this.Controls.Add(this.button_keithley_save);
            this.Controls.Add(this.text_box_agilent_output);
            this.Controls.Add(this.text_box_keithley_output);
            this.Controls.Add(this.button_agilent_autoscale);
            this.Controls.Add(this.button_keithley_autoscale);
            this.Controls.Add(this.button_meas_agilent_clear);
            this.Controls.Add(this.data_grid_view_agilent);
            this.Controls.Add(this.button_meas_keithley_clear);
            this.Controls.Add(this.data_grid_view_keithley);
            this.Controls.Add(this.button_stop_vac);
            this.Controls.Add(this.button_start_vac);
            this.Controls.Add(this.label_meas_keithley_plan);
            this.Controls.Add(this.button_stop_transient);
            this.Controls.Add(this.button_start_transient);
            this.Controls.Add(this.label_meas_plan);
            this.Controls.Add(this.ZedGraph_I_V);
            this.Controls.Add(this.menu_strip);
            this.Controls.Add(this.ZedGraph_I_t);
            this.Name = "Main";
            this.Text = "Measurement";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_keithley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_agilent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem strip_item_file;
        private System.Windows.Forms.ToolStripMenuItem strip_item_options;
        private System.Windows.Forms.ToolStripMenuItem strip_item_settings;
        private ZedGraph.ZedGraphControl ZedGraph_I_t;
        private ZedGraph.ZedGraphControl ZedGraph_I_V;
        private System.Windows.Forms.Label label_meas_plan;
        private System.Windows.Forms.Button button_start_transient;
        private System.Windows.Forms.Button button_stop_transient;
        private System.Windows.Forms.Button button_stop_vac;
        private System.Windows.Forms.Button button_start_vac;
        private System.Windows.Forms.Label label_meas_keithley_plan;
        private System.Windows.Forms.ToolStripMenuItem strip_item_exit;
        private System.Windows.Forms.DataGridView data_grid_view_keithley;
        private System.Windows.Forms.Button button_meas_keithley_clear;
        private System.Windows.Forms.DataGridView data_grid_view_agilent;
        private System.Windows.Forms.Button button_meas_agilent_clear;
        private System.Windows.Forms.Button button_keithley_autoscale;
        private System.Windows.Forms.Button button_agilent_autoscale;
        private System.Windows.Forms.TextBox text_box_keithley_output;
        private System.Windows.Forms.TextBox text_box_agilent_output;
        private System.Windows.Forms.Button button_keithley_save;
        private System.Windows.Forms.Button button_agilent_save;
        private System.Windows.Forms.Label label_keithley_output_time;
        private System.Windows.Forms.Label label_keithley_output_current;
        private System.Windows.Forms.Label label_keithley_output_voltage;
        private System.Windows.Forms.Label label_agilent_output_voltage;
        private System.Windows.Forms.Label label_agilent_output_current;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step_keithley;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewComboBoxColumn NPLC;
        private System.Windows.Forms.DataGridViewComboBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step_agilent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Increment;
        private System.Windows.Forms.DataGridViewComboBoxColumn NPLC_agilent;
        private System.Windows.Forms.DataGridViewComboBoxColumn Range_agilent;
    }
}

