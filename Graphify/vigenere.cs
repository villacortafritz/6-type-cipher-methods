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
    public partial class vigenere : UserControl
    {

        public string key;

        public vigenere()
        {
            InitializeComponent();
        }

        private int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; // Error

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            txtDecrypt.Clear();
            txtEncrypt.Clear();
            txtOriginal.Clear();
            txtKey.Clear();
        }

        private void btnEncrypt_Click_1(object sender, EventArgs e)
        {
            string s = txtEncrypt.Text;
            key = txtKey.Text;
            if (key.All(char.IsLetter) == false)
            {
                MessageBox.Show("Key must be composed of letters!");
                txtKey.Clear();
                txtEncrypt.Clear();
                return;
            }
            txtDecrypt.Text = Cipher(s, key, true);
        }

        private void btnDecrypt_Click_1(object sender, EventArgs e)
        {
            string s = txtDecrypt.Text;
            txtOriginal.Text = Cipher(s, key, false);
        }
    }
}
