using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTocXOGame
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        int w, h;
        bool player1Turn = true; 
        int numTurns = 0;        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.BackColor = Color.FromArgb(73, 32, 97);
            w = pictureBox1.Width;
            h = pictureBox1.Height;
            bmp = new Bitmap(w, h);
            g = Graphics.FromImage(bmp);
            pictureBox1.BackColor = Color.FromArgb(73, 32, 97);
            int xp = w / 2, yp = h / 2;
            g.DrawLine(Pens.White, xp - 50, 0, xp - 50, 300);
            g.DrawLine(Pens.White, xp + 50, 0, xp + 50, 300);
            g.DrawLine(Pens.White, 0, yp - 50, 325, yp - 50);
            g.DrawLine(Pens.White, 0, yp + 50, 325, yp + 50);
            pictureBox1.Image = bmp;
            
        }
        ﻿


        bool CheckVictory()
        {
            bool row1 = (label1.Text == "X" && label2.Text == "X" && label3.Text == "X") || (label1.Text == "O" && label2.Text == "O" && label3.Text == "O");
            bool row2 = (label4.Text == "X" && label5.Text == "X" && label6.Text == "X") || (label4.Text == "O" && label5.Text == "O" && label6.Text == "O");
            bool row3 = (label7.Text == "X" && label8.Text == "X" && label9.Text == "X") || (label7.Text == "O" && label8.Text == "O" && label9.Text == "O");
            bool col1 = (label1.Text == "X" && label4.Text == "X" && label7.Text == "X") || (label1.Text == "O" && label4.Text == "O" && label7.Text == "O");
            bool col2 = (label2.Text == "X" && label5.Text == "X" && label8.Text == "X") || (label2.Text == "O" && label5.Text == "O" && label8.Text == "O");
            bool col3 = (label3.Text == "X" && label6.Text == "X" && label9.Text == "X") || (label3.Text == "O" && label6.Text == "O" && label9.Text == "O");
            bool diagDown = (label1.Text == "X" && label5.Text == "X" && label9.Text == "X") || (label1.Text == "O" && label5.Text == "O" && label9.Text == "O");
            bool diagUp = (label3.Text == "X" && label5.Text == "X" && label7.Text == "X") || (label3.Text == "O" && label5.Text == "O" && label7.Text == "O");
            return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
        }

        void UpdateLabel(Label label)
        {
            label.Text = player1Turn ? "X" : "O";
            label.Visible = true;
            numTurns++;

            if (CheckVictory())
            {
                label11.Text = label.Text == "X" ? "Player 1 Wins" : "Player 2 Wins";
                MessageBox.Show("You Win !");
            }
            else if (numTurns == 9)
            {

                label11.Text = "Tie!";
                MessageBox.Show("Tie!");
            }

            player1Turn = !player1Turn;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X >= 0 && e.X <= 100 && e.Y >= 0 && e.Y <= 100) && !label1.Visible)
            {
                UpdateLabel(label1);
            }
            else if ((e.X > 100 && e.X <= 200 && e.Y > 0 && e.Y <= 100) && !label2.Visible)
            {
                UpdateLabel(label2);
            }
            else if ((e.X > 200 && e.X <= 300 && e.Y > 0 && e.Y <= 100) && !label3.Visible)
            {
                UpdateLabel(label3);
            }
            else if ((e.X >= 0 && e.X <= 100 && e.Y > 100 && e.Y <= 200) && !label4.Visible)
            {
                UpdateLabel(label4);
            }
            else if ((e.X > 100 && e.X <= 200 && e.Y > 100 && e.Y <= 200) && !label5.Visible)
            {
                UpdateLabel(label5);
            }
            else if ((e.X > 200 && e.X <= 300 && e.Y > 100 && e.Y <= 200) && !label6.Visible)
            {
                UpdateLabel(label6);
            }
            else if ((e.X >= 0 && e.X <= 100 && e.Y > 200 && e.Y <= 300) && !label7.Visible)
            {
                UpdateLabel(label7);
            }
            else if ((e.X > 100 && e.X <= 200 && e.Y > 200 && e.Y <= 300) && !label8.Visible)
            {
                UpdateLabel(label8);
            }
            else if ((e.X > 200 && e.X <= 300 && e.Y > 200 && e.Y <= 300) && !label9.Visible)
            {
                UpdateLabel(label9);
            }



        }

        

        
        

        

    }
}
