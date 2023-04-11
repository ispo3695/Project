using System;
using System.IO.Ports;
using System.Windows.Forms;



/*
 * 
 * 
 * 제작자 : OH SUN CHUL
 * 컴파일러 : Visual Studio
 * 사용언어 : C#
 * 
 * RC카 제어용 PC 콘솔 프로그램입니다.
 * 
 * 
 * 
 * 
 *
 *
 */



namespace Serial_Communication
{







    }; 
    public partial class Form1 : Form
    {





        class Key  {







       }; 

        /*
         * 
         * 
         * 
         */

        const int low = 0;
        const int off = 0;
        const int OFF = 0;
        const int LOW = 0;

        const int HIGH = 1;
        const int high = 1;
        const int on = 1;
        const int ON = 1;

      

        string M1_Scroll_Value;
        string M2_Scroll_Value;
        string M3_Scroll_Value;
        string M4_Scroll_Value;

        char[] TxBuffer = new char[10];
        int temp_keycode;
        char[] TEMP_KEYCODE = new char[10];
        bool caps_lock_flag;

        
        /* w,a,s,d,x버튼의 상태
         * off는 기본적으로 키를 누르지 않은 상태를 의미
         */

        int w_key_flag = OFF;
        int a_key_flag = OFF;
        int s_key_flag = OFF;
        int d_key_flag = OFF;
        int x_key_flag = OFF;



        int trans_key_w_state = OFF;
        int trans_key_x_state = OFF;
        int trans_key_s_state = OFF;
        int trans_key_q_state = OFF;
        int trans_key_e_state = OFF;
        int trans_key_z_state = OFF;
        int trans_key_c_state = OFF;

        /* 최종적으로 송출할 Key에 대한 데이터를 담는 변수 */
        string trans_key_data = "";



        int m1_flag = OFF;
        int m2_flag = OFF;
        int m3_flag = OFF;
        int m4_flag = OFF;

        int Dial_Flag = ON;

      

        

        

       
        string Tx_Trackbar_Buf1;
        string Tx_Trackbar_Buf2;
        string Tx_Trackbar_Buf3;
        string Tx_Trackbar_Buf4;
        string Tx_Trackbar_Buf5;






        private static DateTime Delay(int MS)
        {
        
            /* 내장 Delay함수는 Delay동안 아무런 동작을 하지 않으므로 대체 */
            
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {



            string[] PORT_NAME = SerialPort.GetPortNames();
            comboBox_com.Items.AddRange(PORT_NAME);


        }
        private void comboBox_com_Click(object sender, EventArgs e)
        {


            comboBox_com.Items.Clear();
            string[] PORT_NAME = SerialPort.GetPortNames();

            comboBox_com.Items.AddRange(PORT_NAME);


        }
        private void button_open_Click(object sender, EventArgs e)
        {


            try
            {

                serialPort1.PortName = comboBox_com.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_baud.Text);
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)1;
                serialPort1.Parity = (Parity)0;


                serialPort1.Open();
                progressBar1.Value = 100;
                richTextBox_Console.Text += "Serial Port is Open...!!!\n";

            }
            catch (Exception err)
            {


                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }


        }

        private void button_close_Click(object sender, EventArgs e)
        {



            if (serialPort1.IsOpen)
            {

                serialPort1.Close();
                progressBar1.Value = 0;
                comboBox_com.Items.Clear();
                comboBox_baud.Items.Clear();
                this.comboBox_baud.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
                richTextBox_Console.Text += "Serial Port is Close...!!!\n";


            }


        }

        private void richTextBox_Console_TextChanged(object sender, EventArgs e)
        {

            richTextBox_Console.SelectionStart = richTextBox_Console.TextLength;
            richTextBox_Console.ScrollToCaret();

        }

        private void checkBox_Car_Controller_Actiavte_CheckedChanged(object sender, EventArgs e)
        {


            /* Key Mode : Board가 키보드의 W,A,S,D,X 그리고 H,J,K,L버튼에 응답하도록 활성화하는 기능 */

            if (checkBox_Car_Controller_Actiavte.Checked)
            {




                richTextBox_Console.Text += "Car Controller : ON\n";

              

                if (serialPort1.IsOpen)
                {

                    serialPort1.Write("Key Mode = ON\n");


                }


            }

            else if (!checkBox_Car_Controller_Actiavte.Checked)
            {


                richTextBox_Console.Text += "Car Controller : OFF\n";
               
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("Key Mode = OFF\n");


                }


            }

        }



        private void checkBox_Power_Controller_Activate_CheckedChanged(object sender, EventArgs e)
        {


            /* Dial Mode : 스크롤 바로 모터의 속도 제어 기능에 응답하도록 하는 기능 */
            if (checkBox_Power_Controller_Activate.Checked)
            {


                richTextBox_Console.Text += "--- Dial Mode : OFF ---\n";
            

                trackBar_m.Enabled = true;
                trackBar_m1.Enabled = true;
                trackBar_m2.Enabled = true;
                trackBar_m3.Enabled = true;
                trackBar_m4.Enabled = true;
                button_N.Enabled = true;
                button_M.Enabled = true;

                if (serialPort1.IsOpen)
                {

                    serialPort1.Write("Dial Mode = OFF\n");

                }

            }
            else if (!checkBox_Power_Controller_Activate.Checked)
            {

                richTextBox_Console.Text += "--- Dial Mode : ON ---\n";

                trackBar_m.Enabled = false;
                trackBar_m1.Enabled = false;
                trackBar_m2.Enabled = false;
                trackBar_m3.Enabled = false;
                trackBar_m4.Enabled = false;
                button_N.Enabled = false;
                button_M.Enabled = false;


                if (serialPort1.IsOpen)
                {

                    serialPort1.Write("Dial Mode = ON\n");


                }


            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            /* 타이머에 설정된 주기에 따라 Seiral Data를 송출한다 */
            /* 타이머를 사용하는 이유는 w,a,s,d,x등 방향키를 누르자마자 PC에서 Board로 바로 송출하면 인터럽트가 너무 많이 걸려서 */


            if (trans_key_data != "") 
            {

                if (trans_key_data == "W")
                {

                    if (trans_key_w_state == OFF)
                    {


                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Forward " + "\n";

                        trans_key_w_state = ON; // W키를 송신했다는 것을 의미함. 
                        trans_key_x_state = OFF;
                        trans_key_s_state = OFF;
                        trans_key_q_state = OFF;
                        trans_key_e_state = OFF;
                        trans_key_z_state = OFF;
                        trans_key_c_state = OFF;



                    }


                }
                else if (trans_key_data == "S")
                {


                    if (trans_key_s_state == OFF)
                    {

                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Hold" + "\n";


                        trans_key_w_state = OFF;
                        trans_key_x_state = OFF;
                        trans_key_s_state = ON;
                        trans_key_q_state = OFF;
                        trans_key_e_state = OFF;
                        trans_key_z_state = OFF;
                        trans_key_c_state = OFF;


                    }



                }
                else if (trans_key_data == "X")
                {

                    if (trans_key_x_state == OFF)
                    {

                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Backward" + "\n";

                        trans_key_w_state = OFF;
                        trans_key_x_state = ON;
                        trans_key_s_state = OFF;
                        trans_key_q_state = OFF;
                        trans_key_e_state = OFF;
                        trans_key_z_state = OFF;
                        trans_key_c_state = OFF;

                    }




                }
                else if (trans_key_data == "Q")
                {

                    if (trans_key_q_state == OFF)
                    {

                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Forward & Left" + "\n";


                        trans_key_w_state = OFF;
                        trans_key_x_state = OFF;
                        trans_key_s_state = OFF;
                        trans_key_q_state = ON;
                        trans_key_e_state = OFF;
                        trans_key_z_state = OFF;
                        trans_key_c_state = OFF;


                    }




                }
                else if (trans_key_data == "E")
                {

                    if (trans_key_e_state == OFF)
                    {

                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Forward & Right" + "\n";


                        trans_key_w_state = OFF;
                        trans_key_x_state = OFF;
                        trans_key_s_state = OFF;
                        trans_key_q_state = OFF;
                        trans_key_e_state = ON;
                        trans_key_z_state = OFF;
                        trans_key_c_state = OFF;


                    }



                }
                else if (trans_key_data == "Z")
                {

                    if (trans_key_z_state == OFF)
                    {

                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Forward & Left" + "\n";


                        trans_key_w_state = OFF;
                        trans_key_x_state = OFF;
                        trans_key_s_state = OFF;
                        trans_key_q_state = OFF;
                        trans_key_e_state = OFF;
                        trans_key_z_state = ON;
                        trans_key_c_state = OFF;


                    }



                }
                else if (trans_key_data == "C")
                {

                    if (trans_key_c_state == OFF)
                    {

                        if (serialPort1.IsOpen) serialPort1.WriteLine(trans_key_data);

                        richTextBox_Console.Text += "Car Direction : Backward & Right" + "\n";


                        trans_key_w_state = OFF;
                        trans_key_x_state = OFF;
                        trans_key_s_state = OFF;
                        trans_key_q_state = OFF;
                        trans_key_e_state = OFF;
                        trans_key_z_state = OFF;
                        trans_key_c_state = ON;


                    }



                }


            }

        }

   
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


            if (checkBox_Car_Controller_Actiavte.Checked)
            {


                /* Direction Key가 Pushed 될경우 */
                if (e.KeyCode == Keys.W)
                {

                    w_key_flag = ON; // W키가 Pushed 되었다 !!

                    if (w_key_flag == ON && a_key_flag == OFF &&

                        s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF) // W키 외에 다른 키가 눌러진 적이 없으면 W(전진)을 송신용 버퍼에 담는다. 
                    {

                        trans_key_data = "W"; // Serial통신에 송출할 꺼야 ^^

                    }


                    if (w_key_flag == ON && a_key_flag == ON &&

                       s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF) // W키 외에 A키가 눌러진 적이 있으므로 Q(좌진)을 송신용 버퍼에 담는다. 
                    {


                        trans_key_data = "Q";


                    }

                    if (w_key_flag == ON && a_key_flag == OFF &&

                   s_key_flag == OFF && d_key_flag == ON && x_key_flag == OFF) 
                    {


                        trans_key_data = "E";


                    }

                    if (w_key_flag == ON && a_key_flag == OFF &&

                  s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                    {

                        trans_key_data = "S";

                    }

                    button_W.Enabled = false;

                }

                else if (e.KeyCode == Keys.A)
                {


                    a_key_flag = ON; // A키가 눌러졌다는 것을 의미한다. 

                    if (w_key_flag == ON && a_key_flag == ON &&

                           s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF) // A키 외에 이전에 W키가 눌러젔으니깐 Q(좌진)을 송신용 버퍼에 담는다. 
                    {

                        trans_key_data = "Q";

                    }

                    if (w_key_flag == OFF && a_key_flag == ON &&

                       s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                    {


                        trans_key_data = "Z";

                    }

                    if (w_key_flag == OFF && a_key_flag == ON &&

                     s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF) // A키 외에 다른 키가 이전에 눌러진 적이 없으니깐 자동차가 정지하도록 송신용 버퍼에 S(정지)를 담는다. 
                    {


                        trans_key_data = "S";

                    }

                    button_A.Enabled = false;

                }

                else if (e.KeyCode == Keys.S)
                {

                    s_key_flag = ON;

                    trans_key_data = "S";

                    button_S.Enabled = false;

                }

                else if (e.KeyCode == Keys.D)
                {

                    d_key_flag = ON;

                    if (w_key_flag == ON && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == ON && x_key_flag == OFF)
                    {

                        trans_key_data = "E";


                    }

                    if (w_key_flag == OFF && a_key_flag == OFF &&

                       s_key_flag == OFF && d_key_flag == ON && x_key_flag == ON)
                    {

                        trans_key_data = "C";

                    }
                    if (w_key_flag == OFF && a_key_flag == OFF &&

                    s_key_flag == OFF && d_key_flag == ON && x_key_flag == OFF)
                    {

                        trans_key_data = "S";

                    }

                    button_D.Enabled = false;


                }
                else if (e.KeyCode == Keys.X)
                {

                    x_key_flag = ON;

                    if (w_key_flag == OFF && a_key_flag == OFF &&

                        s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                    {

                        trans_key_data = "X";

                    }

                    if (w_key_flag == OFF && a_key_flag == ON &&

                               s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                    {

                        trans_key_data = "Z";


                    }
                    if (w_key_flag == OFF && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == ON && x_key_flag == ON)
                    {


                        trans_key_data = "C";

                    }

                    if (w_key_flag == ON && a_key_flag == OFF &&

                      s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                    {

                        trans_key_data = "S";

                    }
                    button_X.Enabled = false;


                }

                /* LED KEY BUTTON */
                else if (e.KeyCode == Keys.H)
                {

                    richTextBox_Console.Text += "LD1 : Toggle\n"; // H를 눌렀을 때 LD1이 토글되었음을 표시한다. 
                    button_H.Enabled = false;

                    if (serialPort1.IsOpen)
                    {

                        serialPort1.Write("LD1\n");

                    }

                }
                else if (e.KeyCode == Keys.J)
                {

                    richTextBox_Console.Text += "LD2 : Toggle\n";
                    button_J.Enabled = false;

                    if (serialPort1.IsOpen)
                    {

                        serialPort1.Write("LD2\n");

                    }

                }

                else if (e.KeyCode == Keys.K)
                {

                    richTextBox_Console.Text += "LD3 : Toggle\n";
                    button_K.Enabled = false;

                    if (serialPort1.IsOpen)
                    {

                        serialPort1.Write("LD3\n");

                    }

                }

                else if (e.KeyCode == Keys.L)
                {

                    richTextBox_Console.Text += "LD4 : Toggle\n";
                    button_L.Enabled = false;

                    if (serialPort1.IsOpen)
                    {

                        serialPort1.Write("LD4\n");

                    }

                }

            }

            /* 모터 파워 조절  */
            if(checkBox_Power_Controller_Activate.Checked) 
            { 
                           
                        if ( e.KeyCode == Keys.N) 
                        {


                            button_N.Enabled = false;

                            if (trackBar_m.Value > trackBar_m.Minimum) trackBar_m.Value--; // 최소값 보다 클 때만 줄여야하니깐. 


                            Delay(100);

                            Tx_Trackbar_Buf5 = Convert.ToString(trackBar_m.Value);
                            label_m.Text = Tx_Trackbar_Buf5;


                            trackBar_m1.Value = trackBar_m.Value;
                            label_m1.Text = Tx_Trackbar_Buf5;

                            trackBar_m2.Value = trackBar_m.Value;
                            label_m2.Text = Tx_Trackbar_Buf5;

                            trackBar_m3.Value = trackBar_m.Value;
                            label_m3.Text = Tx_Trackbar_Buf5;

                            trackBar_m4.Value = trackBar_m.Value;
                            label_m4.Text = Tx_Trackbar_Buf5;


                            if (serialPort1.IsOpen)
                            {

                                Tx_Trackbar_Buf5 = "5:" + Tx_Trackbar_Buf5 + "\n";

                                serialPort1.Write( Tx_Trackbar_Buf5);



                            }
                            Delay(100);

                        }

                        else if (e.KeyCode == Keys.M ) // Motor Power Increase.
                        {


                            button_M.Enabled = false;

                            if(trackBar_m.Value < trackBar_m.Maximum) trackBar_m.Value++; // 트랙바의 허용 최고치보다 작을 때만 증가해야지 ?

                            Delay(100);
                            Tx_Trackbar_Buf5 = Convert.ToString(trackBar_m.Value);
                            label_m.Text = Tx_Trackbar_Buf5;


                            trackBar_m1.Value = trackBar_m.Value;
                            label_m1.Text = Tx_Trackbar_Buf5;
                            trackBar_m2.Value = trackBar_m.Value;
                            label_m2.Text = Tx_Trackbar_Buf5;
                            trackBar_m3.Value = trackBar_m.Value;
                            label_m3.Text = Tx_Trackbar_Buf5;
                            trackBar_m4.Value = trackBar_m.Value;
                            label_m4.Text = Tx_Trackbar_Buf5;


                            if (serialPort1.IsOpen)
                            {

                        Tx_Trackbar_Buf5 = "5:" + Tx_Trackbar_Buf5 + "\n";

                                serialPort1.Write(Tx_Trackbar_Buf5);


                            }
                            Delay(100);


                        }

            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {




                    if (checkBox_Car_Controller_Actiavte.Checked)
                    {
                        if (e.KeyCode == Keys.W)
                        {

                            w_key_flag = OFF; // W키가 눌러지지 않았음을 의미. 

                            if (w_key_flag == OFF && a_key_flag == OFF &&

                             s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF) // 나머지 키들도 다 뗴어졌으니깐 
                            {


                                trans_key_data = "S"; // S(스탑!) 
                                //  textBox_KeyDir.Text = trans_key_data;

                            }

                            if (w_key_flag == OFF && a_key_flag == ON &&

                              s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF)
                            {


                                trans_key_data = "S";
                                //   textBox_KeyDir.Text = trans_key_data;

                            }

                            if (w_key_flag == OFF && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == ON && x_key_flag == OFF)
                            {

                                trans_key_data = "S";

                            }

                            button_W.Enabled = true;

                        }

                        else if (e.KeyCode == Keys.A) 
                        {

                            a_key_flag = OFF; // A키가 뗴어졋네 ? 


                            if (w_key_flag == ON && a_key_flag == OFF &&

                                       s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF) // 근데 W키는 눌러져있네 ?
                            {

                                trans_key_data = "W"; // 전진. 

                            }

                            if (w_key_flag == OFF && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                            {

                                trans_key_data = "X";

                            }

                            button_A.Enabled = true;

                        }
                        else if (e.KeyCode == Keys.S)
                        {

                            s_key_flag = OFF;

                            button_S.Enabled = true;


                        }
                        else if (e.KeyCode == Keys.D)
                        {

                            d_key_flag = OFF;

                            if (w_key_flag == ON && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF)
                            {

                                trans_key_data = "W";

                            }

                            if (w_key_flag == OFF && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == OFF && x_key_flag == ON)
                            {

                                trans_key_data = "X";

                            }

                            button_D.Enabled = true;

                        }
                        else if (e.KeyCode == Keys.X)
                        {

                            x_key_flag = OFF;

                            if (w_key_flag == OFF && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF)
                            {

                                trans_key_data = "S";

                            }

                            if (w_key_flag == OFF && a_key_flag == ON &&

                          s_key_flag == OFF && d_key_flag == OFF && x_key_flag == OFF)
                            {


                                trans_key_data = "S";
                                //    textBox_KeyDir.Text = trans_key_data;

                            }

                            if (w_key_flag == OFF && a_key_flag == OFF &&

                          s_key_flag == OFF && d_key_flag == ON && x_key_flag == OFF)
                            {

                                trans_key_data = "S";
                                //   textBox_KeyDir.Text = trans_key_data;

                            }

                            button_X.Enabled = true;

                        }

                        /* LED BUTTON */
                        else if (e.KeyCode == Keys.H)
                        {

                            button_H.Enabled = true;


                        }

                        else if (e.KeyCode == Keys.J)
                        {

                            button_J.Enabled = true;

                        }

                        else if (e.KeyCode == Keys.K)
                        {

                            button_K.Enabled = true;

                        }

                        else if (e.KeyCode == Keys.L)
                        {

                            button_L.Enabled = true;

                        }
                       

                    }

                    if (checkBox_Power_Controller_Activate.Checked)
                    {
                            if (e.KeyCode == Keys.N)
                            {


                                button_N.Enabled = true;


                            }
                            else if (e.KeyCode == Keys.M)
                            {

                                button_M.Enabled = true;



                            }
                    }

        }


        

       

        private void trackBar_m1_Scroll(object sender, EventArgs e)
        {

            Delay(100);

            Tx_Trackbar_Buf1 = Convert.ToString(trackBar_m1.Value);
             label_m1.Text = Tx_Trackbar_Buf1;

            if (serialPort1.IsOpen)
            {

                Tx_Trackbar_Buf1 = "1:" + Tx_Trackbar_Buf1 + "\n";
                serialPort1.Write(Tx_Trackbar_Buf1);

            }
            Delay(100);

        }

        private void trackBar_m2_Scroll(object sender, EventArgs e)
        {

            Delay(100);
            Tx_Trackbar_Buf2 = Convert.ToString(trackBar_m2.Value);
            label_m2.Text = Tx_Trackbar_Buf2;

            if (serialPort1.IsOpen)
            {

                Tx_Trackbar_Buf2 = "2:" + Tx_Trackbar_Buf2 + "\n";
                serialPort1.Write(Tx_Trackbar_Buf2);


            }
            Delay(100);


        }

        private void trackBar_m3_Scroll(object sender, EventArgs e)
        {
            Delay(100);
            Tx_Trackbar_Buf3 = Convert.ToString(trackBar_m3.Value);
            label_m3.Text = Tx_Trackbar_Buf3;


            if (serialPort1.IsOpen)
            {

                Tx_Trackbar_Buf3 = "3:" + Tx_Trackbar_Buf3 + "\n";
         
                serialPort1.Write(Tx_Trackbar_Buf3);



            }
            Delay(100);


        }

        private void trackBar_m4_Scroll(object sender, EventArgs e)
        {
            Delay(100);

            Tx_Trackbar_Buf4 = Convert.ToString(trackBar_m4.Value);
            label_m4.Text = Tx_Trackbar_Buf4;


     
            if (serialPort1.IsOpen)
            {

                Tx_Trackbar_Buf4 = "4:" + Tx_Trackbar_Buf4 + "\n";
            
                serialPort1.Write(Tx_Trackbar_Buf4);



            }
            Delay(100);


        }

        private void trackBar_m_Scroll(object sender, EventArgs e)
        {
           
            
            Delay(100);
            Tx_Trackbar_Buf5 = Convert.ToString(trackBar_m.Value);
            label_m.Text = Tx_Trackbar_Buf5;


            trackBar_m1.Value = trackBar_m.Value;
            label_m1.Text = Tx_Trackbar_Buf5;
            trackBar_m2.Value = trackBar_m.Value;
            label_m2.Text = Tx_Trackbar_Buf5;
            trackBar_m3.Value = trackBar_m.Value;
            label_m3.Text = Tx_Trackbar_Buf5;
            trackBar_m4.Value = trackBar_m.Value;
            label_m4.Text = Tx_Trackbar_Buf5;


            if (serialPort1.IsOpen)
            {

                Tx_Trackbar_Buf5 = "5:" + Tx_Trackbar_Buf5 + "\n";
                serialPort1.Write(Tx_Trackbar_Buf5);


            }
            Delay(100);


        }

 
    }
}
