using System;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        int n, m;
        int J, K;
        int[,] matrix;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitDataGridView(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();

            for (int i = 0; i < n; i++)
            {
                dataGridView.Columns.Add(i.ToString(), "");
                dataGridView.Columns[i].Width = 42;
            }

            for (int i = 0; i < m; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Height = 42;
            }

            dataGridView.AllowUserToAddRows = false;
        }

        void GenerateMatrix()
        {
            matrix = new int[m, n];
            Random rnd = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(-50, 51);
                }
            }
        }

        void PrintMatrix(DataGridView dataGridView)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        void GetSwappedMatrix()
        {
            int tmp;

            for (int i = 0; i < m; i++)
            {
                tmp = matrix[i, K];
                matrix[i, K] = matrix[i, J];
                matrix[i, J] = tmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out n);
            int.TryParse(textBox4.Text, out m);

            int.TryParse(textBox2.Text, out K);
            int.TryParse(textBox3.Text, out J);

            if (0 <= K && K < J && J < m)
            {
                InitDataGridView(dataGridView1);
                InitDataGridView(dataGridView2);

                GenerateMatrix();

                PrintMatrix(dataGridView1);

                GetSwappedMatrix();

                PrintMatrix(dataGridView2);
            }
            else
            {
                MessageBox.Show("Incorrect inputs. Insert the right ones and press the button again");
            }
        }
    }
}
