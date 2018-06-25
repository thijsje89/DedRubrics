﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Write("6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("4");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Write("5");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            serialPort1.Write("7");
        }
    }
}
