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
    public partial class hill : UserControl
    {
        public hill()
        {
            InitializeComponent();
        }

        public string key;
        public string resultCipher;
        public int[,] keymatrix;
        public int[] linematrix;
        public int[] resultmatrix;

        public void divide(String temp, int s)
        {
            while (temp.Length > s)
            { 
                String sub = temp.Substring(0, s);
                temp = temp.Substring(s, temp.Length);
                perform(sub);
            }
            if(temp.Length == s)
            {
                perform(temp);
            }
            else if (temp.Length < s)
            {
                for(int i = temp.Length; i<s; i++)
                {
                    temp = temp + 'x';
                }
                perform(temp);
            }
        }

        public void perform(String line)
        {
            linetomatrix(line);
            linemultiplykey(line.Length);
            result(line.Length);
        }

        public void keytomatrix(String key, int len)
        {
            keymatrix = new int[len, len];
            int c = 0;
            for(int i=0; i<len; i++)
            {
                for(int j=0; j< len; j++)
                {
                    keymatrix[i, j] = ((int)key[c]) - 97;
                    c++;
                }
            }
        }

        public void linetomatrix(String line)
        {
            linematrix = new int[line.Length];
            for(int i=0; i<line.Length; i++)
            {
                linematrix[i] = ((int)line[i]) - 97;
            }
        }

        public void linemultiplykey(int len)
        {
            resultmatrix = new int[len];
            for (int i = 0; i < len; i++)
            {
                for(int j=0; j<len; j++)
                {
                    resultmatrix[i] += keymatrix[i, j] * linematrix[j];
                }
                resultmatrix[i] %= 26;
            }
        }

        public String result(int len)
        {
            String result = "";
            for(int i =0; i<len; i++)
            {
                result += (char)(resultmatrix[i] + 97);
            }
            resultCipher = result;
            return result; // encrypted
        }

        public Boolean check(String key, int len)
        {
            keytomatrix(key, len);
            int d = determinant(keymatrix, len);
            d = d % 26;
            if (d == 0)
            {
                MessageBox.Show("Invalid Key. Key is not invertible because determinant=0.");
                return false;
            }
            else if(d%2==0 || d%13 == 0)
            {
                MessageBox.Show("Invalid Key. Key is not invertible because determinant has a common factor with 26.");
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public int determinant(int[,] A, int N)
        {
            int det = 0;
            int res;
            if (N == 1)
            {
                res = A[0, 0];
            }
            else if (N == 2)
            {
                res = A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
            }
            else
            {
                res = 0;
                for(int j1 =0; j1<N;j1++)
                {
                    int[,] m = new int[N - 1, N - 1];
                    for(int i=1; i<N; i++)
                    {
                        int j2 = 0;
                        for(int j =0;j<N; j++)
                        {
                            if (j == j1)
                            {
                                continue;
                            }
                            m[i - 1, j2] = A[i, j];
                            j2++;
                        }
                    }
                    res += Convert.ToInt32(Math.Pow(-1.0, 1.0 + j1 + 1.0) * A[0, j1] * determinant(m, N - 1));
                }
            }
            return res;
        }

        public void cofact(int[,] num, int f)
        {
            int[,] b = new int[f,f];
            int[,] fac = new int[f, f];
            int p, q, m, n, i, j;
            for(q=0; q<f; q++)
            {
                for(p=0; p<f; p++)
                {
                    m = 0;
                    n = 0;
                    for (i=0; i<f; i++)
                    {
                        for(j=0; j<f; j++)
                        {
                            b[i, j] = 0;
                            if(i!=q && j != p)
                            {
                                b[m, n] = num[i, j];
                                if (n < (f - 2))
                                {
                                    n++;
                                }
                                else
                                {
                                    n = 0;
                                    m++;
                                }
                            }
                        }
                    }
                    fac[q, p] = (int)Math.Pow(-1, q + p) * determinant(b, f - 1);
                }
            }
            trans(fac, f);
        }

        void trans(int[,] fac, int r)
        {
            int i, j;
            int[,] b = new int[r,r];
            int[,] inv = new int[r,r];
            int d = determinant(keymatrix, r);
            int mid = mi(d % 26);
            mid %= 26;
            if (mid < 0)
            {
                mid += 26;
            }
            for(i=0; i<r; i++)
            {
                for(j =0; j<r; j++)
                {
                    b[i, j] = fac[j, i];
                }
            }
            for(i=0; i<r; i++)
            {
                for(j=0; j<r; j++)
                {
                    inv[i, j] = b[i, j] % 26;
                    if(inv[i,j] < 0)
                    {
                        inv[i, j] += 26;
                    }
                    inv[i, j] *= mid;
                    inv[i, j] %= 26;
                }
            }
            string s = matrixtoinvkey(inv, r); //Inverse key
            key = s;
        }

        public String matrixtoinvkey(int[,] inv, int n)
        {
            String invkey = "";
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    invkey += (char)(inv[i, j] + 97);
                }
            }
            return invkey;
        }

        public int mi(int d)
        {
            int q, r1, r2, r, t1, t2, t;
            r1 = 26;
            r2 = d;
            t1 = 0;
            t2 = 1;
            while (r1 != 1 && r2 != 0)
            {
                q = r1 / r2;
                r = r1 % r2;
                t = t1 - (t2 * q);
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            return (t1 + t2);
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

        

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string line = txtDecrypt.Text;
            double sq = Math.Sqrt(key.Length);
            int s = (int)sq;
            if (check(key, s))
            {
                divide(line, s);

                cofact(keymatrix, s);
                txtOriginal.Text = resultCipher;
            }
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string line = txtEncrypt.Text;
            key = txtKey.Text;
            if (key.All(char.IsLetter) == false)
            {
                MessageBox.Show("Key must be composed of letters!");
                txtKey.Clear();
                txtEncrypt.Clear();
                return;
            }
            double sq = Math.Sqrt(key.Length);
            if (sq != (long)sq)
            {
                MessageBox.Show("Invalid key length. Does not form a square matrix");
                txtKey.Clear();
                txtEncrypt.Clear();
                return;
            }
            else
            {
                int s = (int)sq;
                if (check(key, s))
                {
                    divide(line, s);
                    txtDecrypt.Text = resultCipher;
                    cofact(keymatrix, s);
                }
            }
        }

        /*
		System.out.println("Enter the line: ");
		String line=in.readLine();
		System.out.println("Enter the key: ");
		String key=in.readLine();
		double sq=java.lang.Math.sqrt(key.length());
		if(sq!=(long)sq)
			System.out.println("Invalid key length!!! Does not form a square matrix...");
		else
		{
			int s=(int)sq;
			if(obj.check(key,s))
			{
				System.out.println("Result:");
				obj.divide(line,s);
				obj.cofact(obj.keymatrix,s);
			}
		}*/
    }
}
