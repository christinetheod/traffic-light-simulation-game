using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    public partial class TrafficLight : Form
    {
        public TrafficLight()
        {
            InitializeComponent();
            //Light1
            redLight1.Visible = true;
            yellowLight1.Visible = false;
            greenLight1.Visible = false;
            //Light2
            redLight2.Visible = true;
            yellowLight2.Visible = false;
            greenLight2.Visible = false;
        }

        private void ChangeLight1(){
            timerCarLeft.Enabled = true;
            if (redLight1.Visible == true)
            {
                redLight1.Visible = false;
                yellowLight1.Visible = false;
                greenLight1.Visible = true;
            }
            else if (yellowLight1.Visible == true)
            {
                redLight1.Visible = true;
                yellowLight1.Visible = false;
                greenLight1.Visible = false;
            }
            else if (greenLight1.Visible == true)
            {
                redLight1.Visible = false;
                yellowLight1.Visible = true;
                greenLight1.Visible = false;
            }
        }

        private void ChangeLight2()
        {
            timerCarTop.Enabled = true;
            if (redLight2.Visible == true)
            {
                redLight2.Visible = false;
                yellowLight2.Visible = false;
                greenLight2.Visible = true;
            }
            else if (yellowLight2.Visible == true)
            {
                redLight2.Visible = true;
                yellowLight2.Visible = false;
                greenLight2.Visible = false;
            }
            else if (greenLight2.Visible == true)
            {
                redLight2.Visible = false;
                yellowLight2.Visible = true;
                greenLight2.Visible = false;
            }
        }
            //BUTTON CHANGE1
            private void buttonChange1_Click(object sender, EventArgs e)
        {
            ChangeLight1();
        }

        //BUTTON CHANGE2
        private void buttonChange2_Click(object sender, EventArgs e)
        {
            ChangeLight2();
        }

        //BUTTON AUTO
        private void buttonAuto_Click(object sender, EventArgs e)
        {
            if (((textBoxRed1.Text.Length != 0) && (textBoxYellow1.Text.Length != 0) && (textBoxGreen1.Text.Length != 0) && (textBoxGreen2.Text.Length != 0) && (textBoxRed2.Text.Length != 0) && (textBoxYellow2.Text.Length != 0)) && ((int.Parse(textBoxRed1.Text) > 0) && (int.Parse(textBoxYellow1.Text) > 0) && (int.Parse(textBoxGreen1.Text) > 0) && (int.Parse(textBoxGreen2.Text) > 0) && (int.Parse(textBoxRed2.Text) > 0) && (int.Parse(textBoxYellow2.Text) > 0)))
            {
                timerLight.Enabled = true;
                timerCarLeft.Enabled = true;

                timerLight2.Enabled = true;
                timerCarTop.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please complete the empty cells!");
            }
        }

        //BUTTON STOP
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerLight.Enabled = false;
            timerLight2.Enabled = false;
            timerCarLeft.Enabled = false;
            timerCarTop.Enabled = false;
        }


        //TIMER LIGHT
        private int secR1;
        private int secY1;
        private int secG1;
        private void timerLight_Tick(object sender, EventArgs e)
        {
            
                secR1 = 1000 * int.Parse(textBoxRed1.Text);
                secY1 = 1000 * int.Parse(textBoxYellow1.Text);
                secG1 = 1000 * int.Parse(textBoxGreen1.Text);
                if (redLight1.Visible == true)
                {

                     if(redLight2.Visible == true)
                    {
                        timerLight.Interval = secG1;
                        redLight1.Visible = false;
                        yellowLight1.Visible = false;
                        greenLight1.Visible = true;
                    }
                    /*if (greenLight2.Visible == true)
                    {
                        redLight1.Visible = true;
                        yellowLight1.Visible = false;
                        greenLight1.Visible = false;
                        timerLight.Interval = secG2;
                    }
                    else
                    {
                        timerLight.Interval = secG1;
                        redLight1.Visible = false;
                        yellowLight1.Visible = false;
                        greenLight1.Visible = true;

                    }*/

                }
                else if (greenLight1.Visible == true)
                {
                        timerLight.Interval = secY1;
                        redLight1.Visible = false;
                        yellowLight1.Visible = true;
                        greenLight1.Visible = false;
                       
                }
                else if (yellowLight1.Visible == true)
                {
                    timerLight.Interval = secR1;
                    redLight1.Visible = true;
                    yellowLight1.Visible = false;
                    greenLight1.Visible = false;
                }
            
            
            
            


        }


        //TIMER LIGHT2
        private int secR2;
        private int secY2;
        private int secG2;

        private void timerLight2_Tick(object sender, EventArgs e)
        {
                secR2 = 1000 * int.Parse(textBoxRed2.Text);
                secY2 = 1000 * int.Parse(textBoxYellow2.Text);
                secG2 = 1000 * int.Parse(textBoxGreen2.Text);

                if (redLight2.Visible == true)
                {
                    if(redLight1.Visible == true)
                    {
                        redLight2.Visible = false;
                        yellowLight2.Visible = false;
                        greenLight2.Visible = true;
                        timerLight2.Interval = secG2;
                    }
                    /*if (greenLight1.Visible == true)
                    {
                        redLight2.Visible = true;
                        yellowLight2.Visible = false;
                        greenLight2.Visible = false;
                        timerLight2.Interval = secG1;
                    }
                    else
                    {
                        redLight2.Visible = false;
                        yellowLight2.Visible = false;
                        greenLight2.Visible = true;
                        timerLight2.Interval = secG2;

                    }*/
                }
                else if (greenLight2.Visible == true)
                {
                    redLight2.Visible = false;
                    yellowLight2.Visible = true;
                    greenLight2.Visible = false;
                    timerLight2.Interval = secY2;
                }
                else if (yellowLight2.Visible == true)
                {
                    redLight2.Visible = true;
                    yellowLight2.Visible = false;
                    greenLight2.Visible = false;
                    timerLight2.Interval = secR2;
                }
           
        }

        //TIMER CAR_LEFT
        private void timerCarLeft_Tick(object sender, EventArgs e)
        {
            //CAR2
            int c2 = car2.Location.X;
            if (c2 < 200)
            {
                car2.Left += 40;
            }
            else if (c2 == 200)
            {
                if (greenLight1.Visible == true)
                {
                    car2.Left += 40;
                }
            }
            else if (c2 > 200)
            {
                car2.Left += 40;
            }

            //CAR4
            int c4 = car4.Location.X;
            if (c4 < 200)
            {
                car4.Left += 20;
            }
            else if (c4 == 200)
            {
                if(greenLight1.Visible == true)
                {
                    car4.Left += 20;
                }
            }
            else if(c4 > 200) 
            {
                car4.Left += 20;
            }

        }

        //TIMER CAR_TOP
        private void timerCarTop_Tick(object sender, EventArgs e)
        {
            //CAR1
            int c1 = car1.Location.Y;
            if (c1 < 120)
            {
                car1.Top += 60;
            }
            else if (c1 == 120)
            {
                if (greenLight2.Visible == true)
                {
                    car1.Top += 60;
                }
            }
            else if (c1 > 120)
            {
                car1.Top += 60;
            }

            //CAR5
            int c5 = car5.Location.Y;
            if (c5 < 120)
            {
                car5.Top += 20;
            }
            else if (c5 == 120)
            {
                if (greenLight2.Visible == true)
                {
                    car5.Top += 20;
                }
            }
            else if (c5 > 120)
            {
                car5.Top += 20;
            }

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For Auto mode:\n 1.Fill in the cells\n 2.Press the Auto button\n" +
                "Or you can simply change the colour of the traffic light by pressing the Change button for each traffic light ");
        }

        private void ExittoolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
