using System;
using System.Windows.Forms;

namespace Graphify
{
    public partial class ceasar : UserControl
    {
        int key = 3;

        public ceasar()
        {
            InitializeComponent();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDecrypt.Clear();
            txtEncrypt.Clear();
            txtOriginal.Clear();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            String message = txtDecrypt.Text;
            String decrypted;
            int length = message.Length;
            char[] decrypted_message = new char[length];
            char c;

            for(int i=0; i<length; i++)
            {
                c = message[i];
                c = (char)(c - key);

                if (!(Char.IsLetter(c)) && !(c.Equals(' ')))
                {
                    c = (char)(c + 26);
                }
                decrypted_message[i] = c;
            }

            decrypted = new String(decrypted_message);
            txtOriginal.Text = decrypted;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            
            String message = txtEncrypt.Text;
            String encrypted;
            int length = message.Length;
            char[] encrypted_message = new char[length];
            char c;
            Boolean flag = true;

            for (int i=0; i< length; i++)
            {
                c = message[i];

                if(c >= 'a' && c <= 'z')
                {
                    c = (char)(c + key);
                    if(c > 'z')
                    {
                        c = (char)(c - 'z' + 'a' - 1);
                    }

                    encrypted_message[i] = c;
                }
                else if(c >= 'A' && c <= 'Z')
                {
                    c = (char)(c + key);
                    if (c > 'Z')
                    {
                        c = (char)(c - 'Z' + 'A' - 1);
                    }

                    encrypted_message[i] = c;
                }
                else if(c == ' ')
                {
                    c = (char)(c + key);
                    encrypted_message[i] = c;
                }
                else
                {
                    MessageBox.Show("No numbers or symbols allowed!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEncrypt.Text = "";
                    flag = false;
                    break;
                }
            }

            if(flag == true)
            {
                encrypted = new String(encrypted_message);
                txtDecrypt.Text = encrypted;
            }
        }
    }
}
