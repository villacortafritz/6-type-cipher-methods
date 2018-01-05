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

        }

        private void createTable(String key, Boolean replace)
        {
            

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
