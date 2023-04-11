namespace Serial_Communication
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_close = new System.Windows.Forms.Button();
            this.comboBox_baud = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.button_open = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox_Console = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_L = new System.Windows.Forms.Button();
            this.button_K = new System.Windows.Forms.Button();
            this.checkBox_Car_Controller_Actiavte = new System.Windows.Forms.CheckBox();
            this.button_J = new System.Windows.Forms.Button();
            this.button_H = new System.Windows.Forms.Button();
            this.button_X = new System.Windows.Forms.Button();
            this.button_D = new System.Windows.Forms.Button();
            this.button_S = new System.Windows.Forms.Button();
            this.button_A = new System.Windows.Forms.Button();
            this.button_W = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_M = new System.Windows.Forms.Button();
            this.button_N = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label_m = new System.Windows.Forms.Label();
            this.trackBar_m = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label_m4 = new System.Windows.Forms.Label();
            this.trackBar_m4 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label_m3 = new System.Windows.Forms.Label();
            this.trackBar_m3 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label_m2 = new System.Windows.Forms.Label();
            this.trackBar_m2 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label_m1 = new System.Windows.Forms.Label();
            this.checkBox_Power_Controller_Activate = new System.Windows.Forms.CheckBox();
            this.trackBar_m1 = new System.Windows.Forms.TrackBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_close);
            this.groupBox1.Controls.Add(this.comboBox_baud);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_com);
            this.groupBox1.Controls.Add(this.button_open);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(127, 107);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 5;
            this.button_close.Text = "CLOSE";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // comboBox_baud
            // 
            this.comboBox_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_baud.FormattingEnabled = true;
            this.comboBox_baud.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.comboBox_baud.Location = new System.Drawing.Point(87, 65);
            this.comboBox_baud.Name = "comboBox_baud";
            this.comboBox_baud.Size = new System.Drawing.Size(115, 20);
            this.comboBox_baud.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(27, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(174, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "BAUD";
            // 
            // comboBox_com
            // 
            this.comboBox_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(87, 28);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(113, 20);
            this.comboBox_com.TabIndex = 2;
            this.comboBox_com.Click += new System.EventHandler(this.comboBox_com_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(29, 106);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 100;
            this.button_open.Text = "OPEN";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox_Console);
            this.groupBox2.Location = new System.Drawing.Point(273, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 187);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // richTextBox_Console
            // 
            this.richTextBox_Console.Location = new System.Drawing.Point(20, 20);
            this.richTextBox_Console.Name = "richTextBox_Console";
            this.richTextBox_Console.ReadOnly = true;
            this.richTextBox_Console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox_Console.Size = new System.Drawing.Size(213, 152);
            this.richTextBox_Console.TabIndex = 4;
            this.richTextBox_Console.Text = "";
            this.richTextBox_Console.TextChanged += new System.EventHandler(this.richTextBox_Console_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_L);
            this.groupBox3.Controls.Add(this.button_K);
            this.groupBox3.Controls.Add(this.checkBox_Car_Controller_Actiavte);
            this.groupBox3.Controls.Add(this.button_J);
            this.groupBox3.Controls.Add(this.button_H);
            this.groupBox3.Controls.Add(this.button_X);
            this.groupBox3.Controls.Add(this.button_D);
            this.groupBox3.Controls.Add(this.button_S);
            this.groupBox3.Controls.Add(this.button_A);
            this.groupBox3.Controls.Add(this.button_W);
            this.groupBox3.Location = new System.Drawing.Point(12, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 220);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Car Controller";
            // 
            // button_L
            // 
            this.button_L.Location = new System.Drawing.Point(189, 168);
            this.button_L.Name = "button_L";
            this.button_L.Size = new System.Drawing.Size(35, 35);
            this.button_L.TabIndex = 14;
            this.button_L.Text = "L";
            this.button_L.UseVisualStyleBackColor = true;
            // 
            // button_K
            // 
            this.button_K.Location = new System.Drawing.Point(134, 168);
            this.button_K.Name = "button_K";
            this.button_K.Size = new System.Drawing.Size(35, 35);
            this.button_K.TabIndex = 13;
            this.button_K.Text = "K";
            this.button_K.UseVisualStyleBackColor = true;
            // 
            // checkBox_Car_Controller_Actiavte
            // 
            this.checkBox_Car_Controller_Actiavte.AutoSize = true;
            this.checkBox_Car_Controller_Actiavte.Location = new System.Drawing.Point(8, 20);
            this.checkBox_Car_Controller_Actiavte.Name = "checkBox_Car_Controller_Actiavte";
            this.checkBox_Car_Controller_Actiavte.Size = new System.Drawing.Size(68, 16);
            this.checkBox_Car_Controller_Actiavte.TabIndex = 3;
            this.checkBox_Car_Controller_Actiavte.Text = "Activate";
            this.checkBox_Car_Controller_Actiavte.UseVisualStyleBackColor = true;
            this.checkBox_Car_Controller_Actiavte.CheckedChanged += new System.EventHandler(this.checkBox_Car_Controller_Actiavte_CheckedChanged);
            // 
            // button_J
            // 
            this.button_J.Location = new System.Drawing.Point(75, 168);
            this.button_J.Name = "button_J";
            this.button_J.Size = new System.Drawing.Size(35, 35);
            this.button_J.TabIndex = 12;
            this.button_J.Text = "J";
            this.button_J.UseVisualStyleBackColor = true;
            // 
            // button_H
            // 
            this.button_H.Location = new System.Drawing.Point(21, 168);
            this.button_H.Name = "button_H";
            this.button_H.Size = new System.Drawing.Size(35, 35);
            this.button_H.TabIndex = 11;
            this.button_H.Text = "H";
            this.button_H.UseVisualStyleBackColor = true;
            // 
            // button_X
            // 
            this.button_X.Location = new System.Drawing.Point(108, 122);
            this.button_X.Name = "button_X";
            this.button_X.Size = new System.Drawing.Size(35, 35);
            this.button_X.TabIndex = 10;
            this.button_X.Text = "X";
            this.button_X.UseVisualStyleBackColor = true;
            // 
            // button_D
            // 
            this.button_D.Location = new System.Drawing.Point(159, 75);
            this.button_D.Name = "button_D";
            this.button_D.Size = new System.Drawing.Size(35, 35);
            this.button_D.TabIndex = 9;
            this.button_D.Text = "D";
            this.button_D.UseVisualStyleBackColor = true;
            // 
            // button_S
            // 
            this.button_S.Location = new System.Drawing.Point(108, 75);
            this.button_S.Name = "button_S";
            this.button_S.Size = new System.Drawing.Size(35, 35);
            this.button_S.TabIndex = 8;
            this.button_S.Text = "S";
            this.button_S.UseVisualStyleBackColor = true;
            // 
            // button_A
            // 
            this.button_A.Location = new System.Drawing.Point(57, 75);
            this.button_A.Name = "button_A";
            this.button_A.Size = new System.Drawing.Size(35, 35);
            this.button_A.TabIndex = 7;
            this.button_A.Text = "A";
            this.button_A.UseVisualStyleBackColor = true;
            // 
            // button_W
            // 
            this.button_W.Location = new System.Drawing.Point(108, 26);
            this.button_W.Name = "button_W";
            this.button_W.Size = new System.Drawing.Size(35, 35);
            this.button_W.TabIndex = 6;
            this.button_W.Text = "W";
            this.button_W.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_M);
            this.groupBox4.Controls.Add(this.button_N);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label_m);
            this.groupBox4.Controls.Add(this.trackBar_m);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label_m4);
            this.groupBox4.Controls.Add(this.trackBar_m4);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label_m3);
            this.groupBox4.Controls.Add(this.trackBar_m3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label_m2);
            this.groupBox4.Controls.Add(this.trackBar_m2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label_m1);
            this.groupBox4.Controls.Add(this.checkBox_Power_Controller_Activate);
            this.groupBox4.Controls.Add(this.trackBar_m1);
            this.groupBox4.Location = new System.Drawing.Point(273, 218);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 220);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Power Controller";
            // 
            // button_M
            // 
            this.button_M.Enabled = false;
            this.button_M.Location = new System.Drawing.Point(166, 20);
            this.button_M.Name = "button_M";
            this.button_M.Size = new System.Drawing.Size(35, 35);
            this.button_M.TabIndex = 19;
            this.button_M.Text = "M";
            this.button_M.UseVisualStyleBackColor = true;
            // 
            // button_N
            // 
            this.button_N.Enabled = false;
            this.button_N.Location = new System.Drawing.Point(108, 20);
            this.button_N.Name = "button_N";
            this.button_N.Size = new System.Drawing.Size(35, 35);
            this.button_N.TabIndex = 15;
            this.button_N.Text = "N";
            this.button_N.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "M";
            // 
            // label_m
            // 
            this.label_m.AutoSize = true;
            this.label_m.Location = new System.Drawing.Point(190, 74);
            this.label_m.Name = "label_m";
            this.label_m.Size = new System.Drawing.Size(11, 12);
            this.label_m.TabIndex = 17;
            this.label_m.Text = "0";
            // 
            // trackBar_m
            // 
            this.trackBar_m.Enabled = false;
            this.trackBar_m.LargeChange = 1;
            this.trackBar_m.Location = new System.Drawing.Point(188, 86);
            this.trackBar_m.Name = "trackBar_m";
            this.trackBar_m.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_m.Size = new System.Drawing.Size(45, 104);
            this.trackBar_m.TabIndex = 16;
            this.trackBar_m.Scroll += new System.EventHandler(this.trackBar_m_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "M4";
            // 
            // label_m4
            // 
            this.label_m4.AutoSize = true;
            this.label_m4.Location = new System.Drawing.Point(143, 74);
            this.label_m4.Name = "label_m4";
            this.label_m4.Size = new System.Drawing.Size(11, 12);
            this.label_m4.TabIndex = 14;
            this.label_m4.Text = "0";
            // 
            // trackBar_m4
            // 
            this.trackBar_m4.Enabled = false;
            this.trackBar_m4.LargeChange = 1;
            this.trackBar_m4.Location = new System.Drawing.Point(141, 86);
            this.trackBar_m4.Name = "trackBar_m4";
            this.trackBar_m4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_m4.Size = new System.Drawing.Size(45, 104);
            this.trackBar_m4.TabIndex = 13;
            this.trackBar_m4.Scroll += new System.EventHandler(this.trackBar_m4_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "M3";
            // 
            // label_m3
            // 
            this.label_m3.AutoSize = true;
            this.label_m3.Location = new System.Drawing.Point(100, 74);
            this.label_m3.Name = "label_m3";
            this.label_m3.Size = new System.Drawing.Size(11, 12);
            this.label_m3.TabIndex = 11;
            this.label_m3.Text = "0";
            // 
            // trackBar_m3
            // 
            this.trackBar_m3.Enabled = false;
            this.trackBar_m3.LargeChange = 1;
            this.trackBar_m3.Location = new System.Drawing.Point(98, 86);
            this.trackBar_m3.Name = "trackBar_m3";
            this.trackBar_m3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_m3.Size = new System.Drawing.Size(45, 104);
            this.trackBar_m3.TabIndex = 10;
            this.trackBar_m3.Scroll += new System.EventHandler(this.trackBar_m3_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "M2";
            // 
            // label_m2
            // 
            this.label_m2.AutoSize = true;
            this.label_m2.Location = new System.Drawing.Point(59, 74);
            this.label_m2.Name = "label_m2";
            this.label_m2.Size = new System.Drawing.Size(11, 12);
            this.label_m2.TabIndex = 8;
            this.label_m2.Text = "0";
            // 
            // trackBar_m2
            // 
            this.trackBar_m2.Enabled = false;
            this.trackBar_m2.LargeChange = 1;
            this.trackBar_m2.Location = new System.Drawing.Point(57, 86);
            this.trackBar_m2.Name = "trackBar_m2";
            this.trackBar_m2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_m2.Size = new System.Drawing.Size(45, 104);
            this.trackBar_m2.TabIndex = 7;
            this.trackBar_m2.Scroll += new System.EventHandler(this.trackBar_m2_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "M1";
            // 
            // label_m1
            // 
            this.label_m1.AutoSize = true;
            this.label_m1.Location = new System.Drawing.Point(17, 74);
            this.label_m1.Name = "label_m1";
            this.label_m1.Size = new System.Drawing.Size(11, 12);
            this.label_m1.TabIndex = 5;
            this.label_m1.Text = "0";
            // 
            // checkBox_Power_Controller_Activate
            // 
            this.checkBox_Power_Controller_Activate.AutoSize = true;
            this.checkBox_Power_Controller_Activate.Location = new System.Drawing.Point(10, 20);
            this.checkBox_Power_Controller_Activate.Name = "checkBox_Power_Controller_Activate";
            this.checkBox_Power_Controller_Activate.Size = new System.Drawing.Size(68, 16);
            this.checkBox_Power_Controller_Activate.TabIndex = 4;
            this.checkBox_Power_Controller_Activate.Text = "Activate";
            this.checkBox_Power_Controller_Activate.UseVisualStyleBackColor = true;
            this.checkBox_Power_Controller_Activate.CheckedChanged += new System.EventHandler(this.checkBox_Power_Controller_Activate_CheckedChanged);
            // 
            // trackBar_m1
            // 
            this.trackBar_m1.Enabled = false;
            this.trackBar_m1.LargeChange = 1;
            this.trackBar_m1.Location = new System.Drawing.Point(15, 86);
            this.trackBar_m1.Name = "trackBar_m1";
            this.trackBar_m1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_m1.Size = new System.Drawing.Size(45, 104);
            this.trackBar_m1.TabIndex = 2;
            this.trackBar_m1.Scroll += new System.EventHandler(this.trackBar_m1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_m1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ComboBox comboBox_baud;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_com;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox_Console;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_L;
        private System.Windows.Forms.Button button_K;
        private System.Windows.Forms.CheckBox checkBox_Car_Controller_Actiavte;
        private System.Windows.Forms.Button button_J;
        private System.Windows.Forms.Button button_H;
        private System.Windows.Forms.Button button_X;
        private System.Windows.Forms.Button button_D;
        private System.Windows.Forms.Button button_S;
        private System.Windows.Forms.Button button_A;
        private System.Windows.Forms.Button button_W;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trackBar_m1;
        private System.Windows.Forms.CheckBox checkBox_Power_Controller_Activate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_m;
        private System.Windows.Forms.TrackBar trackBar_m;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_m4;
        private System.Windows.Forms.TrackBar trackBar_m4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_m3;
        private System.Windows.Forms.TrackBar trackBar_m3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_m2;
        private System.Windows.Forms.TrackBar trackBar_m2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_m1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_M;
        private System.Windows.Forms.Button button_N;
    }
}

