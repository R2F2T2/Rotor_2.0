﻿namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListBox_TensorType = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_PowerType = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Speed = new System.Windows.Forms.TextBox();
            this.textBox_Acceleration = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonClean = new System.Windows.Forms.Button();
            this.numericUpDown_MaxSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MinSize = new System.Windows.Forms.NumericUpDown();
            this.button_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinSize)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1756, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(34, 610);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(110, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 697);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "Расчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "8,9";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "12,5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Частота \r\nвращения, Гц";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Внешний радиус\r\nмагнита";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 224);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "0,8";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(270, 22);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1337, 798);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Толщина бандажа";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(131, 263);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "0,04";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Преднатяг";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(131, 92);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Внутренний радиус\r\nстали";
            // 
            // checkedListBox_TensorType
            // 
            this.checkedListBox_TensorType.FormattingEnabled = true;
            this.checkedListBox_TensorType.Items.AddRange(new object[] {
            "Радиальное напряжение",
            "Окружное напряжение",
            "Эквивалентное напряжение",
            "Коэффициент Запаса"});
            this.checkedListBox_TensorType.Location = new System.Drawing.Point(16, 612);
            this.checkedListBox_TensorType.Name = "checkedListBox_TensorType";
            this.checkedListBox_TensorType.Size = new System.Drawing.Size(205, 79);
            this.checkedListBox_TensorType.TabIndex = 7;
            this.checkedListBox_TensorType.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_TensorType_ItemCheck);
            // 
            // checkedListBox_PowerType
            // 
            this.checkedListBox_PowerType.FormattingEnabled = true;
            this.checkedListBox_PowerType.Items.AddRange(new object[] {
            "Натяг",
            "Вращение",
            "Совместная"});
            this.checkedListBox_PowerType.Location = new System.Drawing.Point(16, 497);
            this.checkedListBox_PowerType.Name = "checkedListBox_PowerType";
            this.checkedListBox_PowerType.Size = new System.Drawing.Size(205, 79);
            this.checkedListBox_PowerType.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 593);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Тип напряжения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 478);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Вид нагрузки";
            // 
            // textBox_Speed
            // 
            this.textBox_Speed.Location = new System.Drawing.Point(131, 302);
            this.textBox_Speed.Name = "textBox_Speed";
            this.textBox_Speed.Size = new System.Drawing.Size(100, 20);
            this.textBox_Speed.TabIndex = 4;
            this.textBox_Speed.Text = "1333";
            // 
            // textBox_Acceleration
            // 
            this.textBox_Acceleration.Location = new System.Drawing.Point(131, 337);
            this.textBox_Acceleration.Name = "textBox_Acceleration";
            this.textBox_Acceleration.Size = new System.Drawing.Size(100, 20);
            this.textBox_Acceleration.TabIndex = 4;
            this.textBox_Acceleration.Text = "500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 26);
            this.label8.TabIndex = 5;
            this.label8.Text = "Угловое  \r\nускорение, об/с^2\r\n";
            // 
            // buttonClean
            // 
            this.buttonClean.Location = new System.Drawing.Point(122, 697);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(86, 57);
            this.buttonClean.TabIndex = 10;
            this.buttonClean.Text = "Очистить";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // numericUpDown_MaxSize
            // 
            this.numericUpDown_MaxSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_MaxSize.Location = new System.Drawing.Point(1658, 38);
            this.numericUpDown_MaxSize.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDown_MaxSize.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numericUpDown_MaxSize.Name = "numericUpDown_MaxSize";
            this.numericUpDown_MaxSize.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_MaxSize.TabIndex = 11;
            this.numericUpDown_MaxSize.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown_MaxSize.ValueChanged += new System.EventHandler(this.numericUpDown_MaxSize_ValueChanged);
            // 
            // numericUpDown_MinSize
            // 
            this.numericUpDown_MinSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_MinSize.Location = new System.Drawing.Point(1658, 741);
            this.numericUpDown_MinSize.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_MinSize.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numericUpDown_MinSize.Name = "numericUpDown_MinSize";
            this.numericUpDown_MinSize.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_MinSize.TabIndex = 11;
            this.numericUpDown_MinSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_MinSize.ValueChanged += new System.EventHandler(this.numericUpDown_MinSize_ValueChanged);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(1658, 388);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 64);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 832);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.numericUpDown_MinSize);
            this.Controls.Add(this.numericUpDown_MaxSize);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkedListBox_PowerType);
            this.Controls.Add(this.checkedListBox_TensorType);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Acceleration);
            this.Controls.Add(this.textBox_Speed);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListBox_TensorType;
        private System.Windows.Forms.CheckedListBox checkedListBox_PowerType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Speed;
        private System.Windows.Forms.TextBox textBox_Acceleration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinSize;
        private System.Windows.Forms.Button button_Save;
    }
}

