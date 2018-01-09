using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphify
{
    public partial class railfence : UserControl
    {
        public railfence()
        {
            InitializeComponent();
        }

        public int key;

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string text = txtKey.Text;
            if(text.All(char.IsDigit) == false)
            {
                MessageBox.Show("Key must be composed of numbers!");
                txtKey.Clear();
                txtEncrypt.Clear();
                return;
            }
            Int32.TryParse(txtKey.Text, out key);
            
            string s = txtEncrypt.Text;
            txtDecrypt.Text = Encrypt(key, s);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string s = txtDecrypt.Text;
            txtOriginal.Text = Decrypt(key, s);
        }

        public static string Encrypt(int rail, string plainText)
        {
            List<string> railFence = new List<string>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add("");
            }

            int number = 0;
            int increment = 1;
            foreach (char c in plainText)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number] += c;
                number += increment;
            }

            string buffer = "";
            foreach (string s in railFence)
            {
                buffer += s;
            }
            return buffer;
        }

        public static string Decrypt(int rail, string cipherText)
        {
            int cipherLength = cipherText.Length;
            List<List<int>> railFence = new List<List<int>>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add(new List<int>());
            }

            int number = 0;
            int increment = 1;
            for (int i = 0; i < cipherLength; i++)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number].Add(i);
                number += increment;
            }

            int counter = 0;
            char[] buffer = new char[cipherLength];
            for (int i = 0; i < rail; i++)
            {
                for (int j = 0; j < railFence[i].Count; j++)
                {
                    buffer[railFence[i][j]] = cipherText[counter];
                    counter++;
                }
            }

            return new string(buffer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtDecrypt.Clear();
            txtEncrypt.Clear();
            txtOriginal.Clear();
            txtKey.Clear();
        }
    }
}
