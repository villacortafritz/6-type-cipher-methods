using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ceasar1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SideBar.Height = btnCeasar.Height;
            SideBar.Top = btnCeasar.Top;
            ceasar1.BringToFront();
        }

        private void btnPlayfair_Click(object sender, EventArgs e)
        {
            SideBar.Height = btnPlayfair.Height;
            SideBar.Top = btnPlayfair.Top;
            playfair1.BringToFront();
        }

        private void btnHill_Click(object sender, EventArgs e)
        {
            SideBar.Height = btnHill.Height;
            SideBar.Top = btnHill.Top;
            hill1.BringToFront();
        }

        private void btnVigenere_Click(object sender, EventArgs e)
        {
            SideBar.Height = btnVigenere.Height;
            SideBar.Top = btnVigenere.Top;
            vigenere1.BringToFront();
        }

        private void btnTransposition_Click(object sender, EventArgs e)
        {
            SideBar.Height = btnTransposition.Height;
            SideBar.Top = btnTransposition.Top;
            transposition1.BringToFront();
        }

        private void btnRailFence_Click(object sender, EventArgs e)
        {
            SideBar.Height = btnRailFence.Height;
            SideBar.Top = btnRailFence.Top;
            railfence1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
