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

        public int[,] key = new int[2, 2];

        public void encrypt(int k, string msg)
        {
            
            int n = key.ToString().Length;

            int a = k % 10;
            int b = (k % 100 - a) / 10;
            int d = (k % 100 - a);
            int c = (k % 1000 - (d + a)) / 100;
            int g = (k % 10000 - (a + d)) / 1000;

            key[0,0] = a;
            key[0, 1] = b;
            key[1, 0] = c;
            key[1, 1] = g;

            if (checkKeyOk(key, n))
            {
                MessageBox.Show("Key is Not suitable , Decryption May not be Possible , Try Again");
                return;
            }

            string temp1 = msg.ToString().Replace(" ", String.Empty).ToLower();
            msg = temp1;
            int len = msg.Length;

            int xtra = modFun(len, n);
            xtra = modFun(n - xtra, n);

            int[] asciArr = new int[len + xtra];
            for(int i=0; i<len; i++)
            {
                asciArr[i] = (int)msg[i] - 97;
            }
            while(xtra-- > 0)
            {
                asciArr[len++] = 23;
            }

            int[] encryMsg = encry(key, asciArr, n, len);
            string encryptedMessage = null;
            for(int i =0; i<len; i++)
            {
                encryMsg[i] = modFun(encryMsg[i], 26) +97;
                char temp = (char)encryMsg[i];
                encryptedMessage += temp;
            }
            txtDecrypt.Text = encryptedMessage;
        }

        public void decrypt(int k, string msg)
        {
            int n = key.ToString().Length;

            int a = k % 10;
            int b = (k % 100 - a) / 10;
            int d = (k % 100 - a);
            int c = (k % 1000 - (d + a)) / 100;
            int g = (k % 10000 - (a + d)) / 1000;

            key[0, 0] = a;
            key[0, 1] = b;
            key[1, 0] = c;
            key[1, 1] = g;

            if (checkKeyOk(key, n))
            {
                MessageBox.Show("Key is Not suitable , Decryption May not be Possible , Try Again");
                return;
            }

            string temp1 = msg.ToString().Replace(" ", String.Empty).ToLower();
            msg = temp1;
            int len = msg.Length;
            int det = deter(key, n);

            int[,] inKey = clearInverse(key, n);
            int[,] finalInKey = clearConvert(inKey, n, det);

            int xtra = modFun(len, n);
            xtra = modFun(n - xtra, n);

            int[] asciArr = new int[len];
            for (int i = 0; i < len; i++)
            {
                asciArr[i] = (int)msg[i] - 97;
            }
            while (xtra-- > 0)
            {
                asciArr[len++] = 23;
            }

            int[] decryMsg = decry(key, asciArr, n, len);
            string encryptedMessage = null;
            for (int i = 0; i < len; i++)
            {
                decryMsg[i] = modFun(decryMsg[i], 26) + 97;
                char temp = (char)decryMsg[i];
                encryptedMessage += temp;
            }
            txtOriginal.Text = encryptedMessage;
        }

        public int[] decry(int[,] a, int[] b, int n, int len)
        {
            int[] sol = new int[len];
            for (int x = 0; x < len; x += n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sol[x + i] += a[i,k] * b[x + k];
                    }
                }
            }
            return sol;
        }

        public int[,] clearConvert(int[,] inKey, int n, int det)
        {
            int[] check = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            int mulInv = 0;
            for (int i = 0; i < 12; i++)
            {
                if (modFun(det * check[i] - 1, 26) == 0)
                {
                    mulInv = check[i];
                    break;
                }
            }
            if (mulInv == 0)
            {
                return inKey;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inKey[i,j] = modFun((inKey[i,j] * mulInv), 26);
                }
            }
            return inKey;
        }

        public int[,] clearInverse(int[,] key, int n)
        {
            // Find Inverse
            int[,] a = new int[n,n];
		    double[,] invKey = new double[n,n];

		    for(int i=0 ; i<n ; i++) {
			    for(int j=0 ; j<n ; j++) {
				    invKey[i,j] = (double) key[i,j];
			    }
            }

            double det = (double)deter(key, n);
            invKey = invert(invKey);

            for (int i=0 ; i<n ; i++) {
                for(int j=0 ; j<n ; j++) {
                    double prt = invKey[i,j] * det;
                    double roundOff = Math.Round(prt * 100.0) / 100.0;
                    long man = (long)roundOff;
                    int wow = (int)man;
                    a[i,j] = wow;
                }
            }
            return a;
        }

        public double[,] invert(double[,] a)
        {
            int n = a.Length;
            double[,] x = new double[n,n];
            double[,] b = new double[n,n];
            int[] index = new int[n];
        
            for (int i=0; i<n; ++i)
                b[i,i] = 1;

            // Transform the matrix into an upper triangle
            gaussian(a, index);

            // Update the matrix b[i][j] with the ratios stored
            for (int i=0; i<n-1; ++i)
                for (int j=i+1; j<n; ++j)
                    for (int k=0; k<n; ++k)
                        b[index[j],k]-= a[index[j],i]*b[index[i],k];

            // Perform backward substitutions
            for (int i=0; i<n; ++i)
            {
                x[n - 1,i] = b[index[n - 1],i]/a[index[n - 1],n-1];
                for (int j=n-2; j>=0; --j)
                {
                    x[j,i] = b[index[j],i];
                    for (int k=j+1; k<n; ++k)
                    {
                        x[j,i] -= a[index[j],k]*x[k,i];
                    }
                    x[j,i] /= a[index[j],j];
                }
            }
            return x;
        }

        public void gaussian(double[,] a, int[] index)
        {
            int n = index.Length;
            double[] c = new double[n];

            // Initialize the index
            for (int i = 0; i < n; ++i)
                index[i] = i;

            // Find the rescaling factors, one from each row
            for (int i = 0; i < n; ++i)
            {
                double c1 = 0;
                for (int j = 0; j < n; ++j)
                {
                    double c0 = Math.Abs(a[i,j]);
                    if (c0 > c1) c1 = c0;
                }
                c[i] = c1;
            }
            // Search the pivoting element from each column
            int k = 0;
            for (int j = 0; j < n - 1; ++j)
            {
                double pi1 = 0;
                for (int i = j; i < n; ++i)
                {
                    double pi0 = Math.Abs(a[index[i],j]);
                    pi0 /= c[index[i]];
                    if (pi0 > pi1)
                    {
                        pi1 = pi0;
                        k = i;
                    }
                }

                // Interchange rows according to the pivoting order
                int itmp = index[j];
                index[j] = index[k];
                index[k] = itmp;
                for (int i = j + 1; i < n; ++i)
                {
                    double pj = a[index[i],j] / a[index[j],j];

                    // Record pivoting ratios below the diagonal
                    a[index[i],j] = pj;

                    // Modify other elements accordingly
                    for (int l = j + 1; l < n; ++l)
                        a[index[i],l] -= pj * a[index[j],l];
                }
            }
        }


        public int deter(int[,] A, int N)
        {
            int det = 0;
            if (N == 1)
            {
                det = A[0,0];
            }
            else if (N == 2)
            {
                det = A[0,0] * A[1,1] - A[1,0] * A[0,1];
            }
            else
            {
                det = 0;
                for (int j1 = 0; j1 < N; j1++)
                {
                    int[,] m = new int[N - 1,0];
                    for (int i = 1; i < N; i++)
                    {
                        int j2 = 0;
                        for (int j = 0; j < N; j++)
                        {
                            if (j == j1)
                                continue;
                            m[i - 1, j2] = A[i, j];
                            j2++;
                        }
                    }
                    det += Convert.ToInt32(Math.Pow(-1.0, 1.0 + j1 + 1.0) * A[0,j1] * deter(m, N - 1));
                }
            }
            return det;
        }

        public Boolean checkKeyOk(int[,] a, int n)
        {
            int[] check = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            for (int i = 0; i < 12; i++)
            {
                if (modFun(deter(a, n), 26) == check[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int modFun(int a, int n)
        {
            if (a > 0)
            {
                return a % n;
            }
            else
            {
                return ((a % n) + n) % n;
            }
        }

        public int[] encry(int[,] a, int[] b, int n, int len)
        {
            int[] sol = new int[len];
            for (int x = 0; x < len; x += n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sol[x + i] += a[i,k] * b[x + k];
                    }
                }
            }
            return sol;
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
            string n = txtKey.Text;
            string msg = txtDecrypt.Text;
            int k = Convert.ToInt32(n);
            decrypt(k, msg);
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string n = txtKey.Text;
            string msg = txtEncrypt.Text;
            int k = Convert.ToInt32(n);
            encrypt(k, msg);
        }

    }
}
