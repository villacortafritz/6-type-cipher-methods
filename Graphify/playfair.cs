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
    public partial class playfair : UserControl
    {

        char[,] table = new char[5, 5];
        Point[] positions = new Point[26];

        public playfair()
        {
            InitializeComponent();
        }

        private void createTable(String key, bool changeIJ)
        {
            String s = prepareText(key + "ABCDEFGHIJKLMNOPQRSTUVWXYZ", changeIJ);
            int len = s.Length;

            for(int i = 0, k=0; i<len; i++)
            {
                char c = s[i];
                if (positions[c - 'A'] == null)
                {
                    table[k / 5, k % 5] = c;
                    positions[c - 'A'] = new Point(k % 5, k / 5);
                    k++;
                }
            }
        }

        private String prepareText(String s, bool changeIJ)
        {
            s = s.ToUpper().Replace("[^A-Z]", "");
            return changeIJ ? s.Replace("J", "I") : s.Replace("Q", "");
        }

        private String translator(StringBuilder text, int direction)
        {
            int len = text.Length;
            int i;
            for(i=0; i< len; i++)
            {
                char a = text[i];
                char b = text[i + 1];

                int row1 = positions[a - 'A'].Y;
                int row2 = positions[b - 'A'].Y;
                int col1 = positions[a - 'A'].X;
                int col2 = positions[b - 'A'].X;

                if(row1 == row2)
                {
                    col1 = (col1 + direction) % 5;
                    col2 = (col2 + direction) % 5;
                }
                else if(col1 == col2)
                {
                    row1 = (row1 + direction) % 5;
                    row2 = (row2 + direction) % 5;
                }
                else
                {
                    int tmp = col1;
                    col1 = col2;
                    col2 = col1;
                }

                //text.setCharAt
            }

            return "s";
        }
        

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDecrypt.Clear();
            txtEncrypt.Clear();
            txtOriginal.Clear();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            String s = txtDecrypt.Text;
        }

        private void formatText(String s, Boolean replace)
        {

            String formatted_text = s.ToUpper();
        }
        private void btnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
