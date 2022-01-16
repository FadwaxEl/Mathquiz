using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Timed_Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomvals = new Random();
        int addend1, addend2;
        int minend1, minend2;
        int mulend1, mulend2;
        int divend1, divend2;
        int timeLeft;
        public Form1()
        {
            
            InitializeComponent();
        }
        public void fill_in_labels()
        {
            addend1 = randomvals.Next(51);
            addend2 = randomvals.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            minend1 = randomvals.Next(1, 101);
            minend2 = randomvals.Next(1, minend1);

            minusleft.Text = minend1.ToString();
            minusright.Text = minend2.ToString();

            difference.Value = 0;

            mulend1 = randomvals.Next(2,11);
            mulend2 = randomvals.Next(2, 11);
            timesleft.Text = mulend1.ToString();
            timesright.Text = mulend2.ToString();
            product.Value = 0;

            divend1 = randomvals.Next(2, 11);
            divend2 = randomvals.Next(2, divend1);
            dividedLeftlabel.Text = divend1.ToString();
            dividedRightLabel.Text = divend2.ToString();
            quotient.Value = 0;



            timeLeft = 30;
           
            timeLabel.Text = "30 seconds";
           

            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) 
                && (minend1-minend2 == difference.Value) 
                && (mulend1*mulend2 == product.Value) 
                && (divend1 / divend2 == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                
                timer1.Stop();
                sum.ForeColor = Color.Green;
                difference.ForeColor = Color.Green;
                 product.ForeColor = Color.Green;
                quotient.ForeColor = Color.Green;
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                
                StartButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "second";
                if (timeLeft < 10)
                {
                    timeLabel.ForeColor = Color.Red;
                }
            }
            
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!!";
               
                MessageBox.Show("You didn't finish in time.", "Sorry :)");
                
                sum.Value = addend1 + addend2;
                difference.Value = minend1 - minend2;
                product.Value = mulend1 * mulend2;
                quotient.Value = divend1 * divend2;
                
                StartButton.Enabled = true;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            
            fill_in_labels();
            StartButton.Enabled = false; 
            // pour eliminer de choisir le bouton pendant le quiz
        }
        
    }
}
