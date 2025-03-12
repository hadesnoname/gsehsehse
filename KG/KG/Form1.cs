using System.IO;
using System.Text;
namespace KG
{
    public partial class Form1 : Form
    {
        const int MaxN = 10; // ����������� ���������� ����������� ������� 
        int n = 3;  // ������� ����������� �������
        TextBox[,] MatrText = null; // ������� ��������� ���� TextBox
        double[,] Matr1 = new double[MaxN, MaxN]; // ������� 1 ����� � ��������� ������
        double[,] Matr2 = new double[MaxN, MaxN]; // ������� 2 ����� � ��������� ������
        double[,] Matr3 = new double[MaxN, MaxN]; // ������� �����������
        bool f1;  // ������, ������� ��������� � ����� ������ � ������� Matr1
        bool f2;  // ������, ������� ��������� � ����� ������ � ������� Matr2
        int dx = 40, dy = 20; // ������ � ������ ������ � MatrText[,] 
        Form2
        form2 = null; // ��������� (������) ������ ����� Form2
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ������������� ��������� ���������� � ���������� ���������� 
            textBox1.Text = "";
            f1 = f2 = false;
            label2.Text = "false";
            label3.Text = "false";
            // ��������� ������ � ��������� MatrText 
            int i, j;
            // 1. ��������� ������ ��� ����� Form2 
            form2 = new Form2();
            // 2. ��������� ������ ��� ����� ������� 
            MatrText = new TextBox[MaxN, MaxN];
            // 3. ��������� ������ ��� ������ ������ ������� � �� ���������
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i *
                    dx, 10 + j * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    MatrText[i, j].Visible = false;
                    form2.Controls.Add(MatrText[i, j]);
                }
        }
        private void Clear_MatrText()
        {
            // ��������� ����� MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. ������ ����������� �������
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            // 2. ��������� ������ MatrText
            Clear_MatrText();
            // 3. ��������� ������� ����� ������� MatrText
            // � ��������� � �������� n � ����� Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ������� ������ �������
                    MatrText[i, j].Visible = true;
                }
            // 4. ������������� �������� �����
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;
            // 5. ������������� ������� � �������� ������ �� ����� Form2
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;
            // 6. ����� ����� Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. ������� ����� �� ����� Form2 � ������� Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // 8. ������ � ������� Matr1 �������
                f1 = true;
                label2.Text = "true";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. ������ ����������� �������
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            // 2. �������� ������ MatrText Clear_MatrText();
            // 3. ��������� ������� ����� ������� MatrText
            // � ��������� � �������� n � ����� Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ������� ������ �������
                    MatrText[i, j].Visible = true;
                }
            // 4. ������������� �������� �����
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;
            // 5. ������������� ������� � �������� ������ �� ����� Form2
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;
            // 6. ����� ����� Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. ������� ����� �� ����� Form2 � ������� Matr2
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);
                // 8. ������� Matr2 ������������
                f2 = true;
                label3.Text = "true";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);
            if (nn != n)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((f1 == true) && (f2 == true))) return;
            // 2. ���������� ������������ ������. ��������� � Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                }
            // 3. �������� ������ � MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ��������� ����� � ������
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. ����� �����
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // �������� ������
                                   // 1. ������� ���� ��� ������ fw = new FileStream("Res_Matr.txt",           FileMode.Create);
                                   // 2. ������ ������� ���������� � ����

            // 2.1. ������� �������� ����� ��������� ������� Matr3
            msg = n.ToString() + "\r\n";
            // ������� ������ msg � �������� ������ msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // ������ ������� msgByte � ����
            fw.Write(msgByte, 0, msgByte.Length);
            // 2.2. ������ �������� ���� �������
            msg = "";
            for (int i = 0; i < n; i++)
            {
                // ��������� ������ msg �� ��������� �������
                for (int j = 0; j < n; j++)
                    msg = msg + Matr3[i, j].ToString() + " ";
                msg = msg + "\r\n";
                // �������� ������� ������
            }
            // 3. ������� ������ msg � �������� ������ msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // 4. ������ ����� ������� � ����
            fw.Write(msgByte, 0, msgByte.Length);
            // 5. ������� ����
            if (fw != null) fw.Close();
        }

        /// <summary>
        /// �������� ������
        /// </summary>
       private void AddMatrices()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] + Matr2[i, j];
                }
            }
        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        private void SubtractMatrices()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] - Matr2[i, j];
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((f1 == true) && (f2 == true))) return;

            // 2. ���������� �������� ������
            AddMatrices();

            // 3. �������� ������ � MatrText
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            }
            // 4. ����� �����
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((f1 == true) && (f2 == true))) return;

            // 2. ���������� ��������� ������
            SubtractMatrices();

            // 3. �������� ������ � MatrText
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            }

            // 4. ����� �����
            form2.ShowDialog();
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            // 1. ������ ����������� �������
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. �������� ����� ��� ����� �������
            Form3 form3 = new Form3(n);

            // 3. ����� ����� Form3
            if (form3.ShowDialog() == DialogResult.OK)
            {
                // 4. ������� ������ �� ����� Form3 � ������ Vector
                double[] Vector = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Vector[i] = Double.Parse(form3.VectorText[i].Text);
                }

                // 5. ��������� ������� Matr1 �� ������ Vector
                double[] ResultVector = new double[n];
                for (int i = 0; i < n; i++)
                {
                    ResultVector[i] = 0;
                    for (int j = 0; j < n; j++)
                    {
                        ResultVector[i] += Matr1[i, j] * Vector[j];
                    }
                }

                // 6. ������� ����� Form2 ����� ����������� ����� ���������
                form2.Controls.Clear();

                // 7. �������� TextBox ��� ����������� ���������� (�������)
                TextBox[] ResultText = new TextBox[n];
                for (int i = 0; i < n; i++)
                {
                    ResultText[i] = new TextBox();
                    ResultText[i].Text = ResultVector[i].ToString();
                    ResultText[i].Location = new System.Drawing.Point(10, 10 + i * 30);
                    ResultText[i].Size = new System.Drawing.Size(100, 20);
                    ResultText[i].ReadOnly = true; // ��������� ��������������
                    form2.Controls.Add(ResultText[i]);
                }

                // 8. ��������� ����� Form2 ��� ����������� ����������
                form2.Width = 150;
                form2.Height = 50 + n * 30;

                // 9. ����� ����� Form2
                form2.ShowDialog();
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ������� Matr1
            if (!f1)
            {
                MessageBox.Show("������� Matr1 �� ���������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. �������� ����������� ���� ��� ����� �����
            Form inputForm = new Form();
            inputForm.Text = "������� �����";
            inputForm.Width = 400;
            inputForm.Height = 250;

            Label label = new Label();
            label.Text = "������� �����:";
            label.Location = new System.Drawing.Point(10, 20);
            label.AutoSize = true;

            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(10, 50);
            textBox.Width = 200;

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new System.Drawing.Point(10, 80);
            okButton.DialogResult = DialogResult.OK;

            inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(okButton);

            // 3. ����������� ����������� ���� � ��������� ����������
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                // 4. ��������� ���������� �����
                if (double.TryParse(textBox.Text, out double number))
                {
                    // 5. ��������� ������� Matr1 �� �����
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Matr3[i, j] = Matr1[i, j] * number;
                        }
                    }

                    // 6. �������� ������ � MatrText
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            MatrText[i, j].Text = Matr3[i, j].ToString();
                        }
                    }

                    // 7. ����� ����� Form2
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("������� ������������ �����!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// ������ �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������ �� ����������� �������
            if (textBox1.Text == "")
            {
                MessageBox.Show("������� ������� ����������� �������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. ������ ����������� �������
            int n = int.Parse(textBox1.Text);

            // 3. �������� ����� ��� ����� �������
            Form vectorInputForm = new Form();
            vectorInputForm.Text = "������� ������";
            vectorInputForm.Width = 300;
            vectorInputForm.Height = 50 + n * 30;

            // 4. �������� ��������� ����� ��� ����� �������
            TextBox[] vectorTextBoxes = new TextBox[n];
            for (int i = 0; i < n; i++)
            {
                vectorTextBoxes[i] = new TextBox();
                vectorTextBoxes[i].Location = new System.Drawing.Point(10, 10 + i * 30);
                vectorTextBoxes[i].Width = 200;
                vectorTextBoxes[i].Text = "0"; // �� ��������� ��������� ������
                vectorInputForm.Controls.Add(vectorTextBoxes[i]);
            }

            // 5. �������� ������ "OK"
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new System.Drawing.Point(10, 10 + n * 30);
            okButton.DialogResult = DialogResult.OK;
            vectorInputForm.Controls.Add(okButton);

            // 6. ����������� ����� � ��������� ����������
            if (vectorInputForm.ShowDialog() == DialogResult.OK)
            {
                // 7. ������ ������� �� ��������� �����
                double[] vector = new double[n];
                bool isValid = true;

                for (int i = 0; i < n; i++)
                {
                    if (!double.TryParse(vectorTextBoxes[i].Text, out vector[i]))
                    {
                        isValid = false;
                        break;
                    }
                }

                // 8. �������� ������������ �����
                if (!isValid)
                {
                    MessageBox.Show("������������ ���� �������! ����������, ������� �����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 9. ���������� ������ �������
                double modulus = 0;
                for (int i = 0; i < n; i++)
                {
                    modulus += vector[i] * vector[i];
                }
                modulus = Math.Sqrt(modulus);

                // 10. ����������� ����������
                MessageBox.Show($"������ �������: {modulus:F2}", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// ��������� ������������ ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
             // 1. ��������, ������ �� ����������� �������
            if (textBox1.Text == "")
            {
                MessageBox.Show("������� ������� ����������� �������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. ������ ����������� �������
            int n = int.Parse(textBox1.Text);

            // 3. ��������, ��� ����������� ����� 3 (��������� ������������ ���������� ������ ��� 3D ��������)
            if (n != 3)
            {
                MessageBox.Show("��������� ������������ ���������� ������ ��� ���������� �������� (n = 3)!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. �������� ����� ��� ����� ������� �������
            double[] vector1 = InputVector("������� ������ ������");
            if (vector1 == null) return; // ���� ���� ������� ��� �����������

            // 5. �������� ����� ��� ����� ������� �������
            double[] vector2 = InputVector("������� ������ ������");
            if (vector2 == null) return; // ���� ���� ������� ��� �����������

            // 6. ���������� ���������� ������������
            double[] crossProduct = new double[3];
            crossProduct[0] = vector1[1] * vector2[2] - vector1[2] * vector2[1];
            crossProduct[1] = vector1[2] * vector2[0] - vector1[0] * vector2[2];
            crossProduct[2] = vector1[0] * vector2[1] - vector1[1] * vector2[0];

            // 7. ����������� ����������
            MessageBox.Show($"��������� ������������: [{crossProduct[0]:F2}, {crossProduct[1]:F2}, {crossProduct[2]:F2}]", "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ��������������� ����� ��� ����� �������
        private double[] InputVector(string title)
        {
            // 1. �������� ����� ��� ����� �������
            Form vectorInputForm = new Form();
            vectorInputForm.Text = title;
            vectorInputForm.Width = 300;
            vectorInputForm.Height = 150;

            // 2. �������� ��������� ����� ��� ����� �������
            TextBox[] vectorTextBoxes = new TextBox[3];
            for (int i = 0; i < 3; i++)
            {
                vectorTextBoxes[i] = new TextBox();
                vectorTextBoxes[i].Location = new System.Drawing.Point(10, 10 + i * 30);
                vectorTextBoxes[i].Width = 200;
                vectorTextBoxes[i].Text = "0"; // �� ��������� ��������� ������
                vectorInputForm.Controls.Add(vectorTextBoxes[i]);
            }

            // 3. �������� ������ "OK"
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new System.Drawing.Point(10, 100);
            okButton.DialogResult = DialogResult.OK;
            vectorInputForm.Controls.Add(okButton);

            // 4. ����������� ����� � ��������� ����������
            if (vectorInputForm.ShowDialog() == DialogResult.OK)
            {
                // 5. ������ ������� �� ��������� �����
                double[] vector = new double[3];
                bool isValid = true;

                for (int i = 0; i < 3; i++)
                {
                    if (!double.TryParse(vectorTextBoxes[i].Text, out vector[i]))
                    {
                        isValid = false;
                        break;
                    }
                }

                // 6. �������� ������������ �����
                if (!isValid)
                {
                    MessageBox.Show("������������ ���� �������! ����������, ������� �����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return vector;
            }

            return null;
        }
    }
}
