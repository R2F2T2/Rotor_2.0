using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Cylinder cylinder1, cylinder2, cylinder3;
        Contact myContact;
        material Still_12X18N10T = new material(7800, 2.1E+11, 0.28,materialType.plastic,196,196);
        material Titan = new material(4500, 100E9, 0.28,materialType.plastic, 1030, 1030);
        material Magnetic = new material(8400, 1.1E11, 0.27, materialType.fragile,650,36);
        material Still_Still20 = new material(7800, 2.1E11, 0.28,materialType.plastic,250,250);
        //material Inconel
        double Acceleration; // угловое ускорение

        public Form1()
        {

            InitializeComponent();
            comboBox1.Items.Add("Сталь");
            comboBox1.Items.Add("Титан");
            comboBox1.SelectedIndex = 0;

            //chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            

        }
        /*
        private void AddGraphPress(Contact myContact, ParametrType tType)// вывод графика напряжений от натяга бандажа
        {
            string r = "";
            if (tType == ParametrType.radialTensor) r = "Радиальное";
            if (tType == ParametrType.tangentialTensor) r = "Тангенсальное";
            for (int i = 0; i <= 2; i++)
            {
                chart1.Series.Add(myContact.GetSeriesPress(i, tType));
                chart1.Series.Last().BorderWidth = 4;
                chart1.Series.Last().LegendText = "Напряжение от натяга " + i + "  " + r;
                chart1.Series.Last().Color = Color.Green;
            }

        }
        private void AddGraphCentrob(Contact myContact, ParametrType tType) // вывод графика напряжений от центробежных сил
        {
            string r = "";
            if (tType == ParametrType.radialTensor) r = "Радиальное";
            if (tType == ParametrType.tangentialTensor) r = "Тангенсальное";
            for (int i = 0; i <= 2; i++)
            {
                chart1.Series.Add(myContact.GetSeriesCentrob(i, tType));
                chart1.Series.Last().BorderWidth = 4;
                chart1.Series.Last().LegendText = "Напряжение от вращения " + i + "  " + r;
                chart1.Series.Last().Color = Color.Blue;
            }
        }
        private void AddGraphAbs(Contact myContact, ParametrType tType) // вывод графика результирующих сил
        {
            string r = "";
            if (tType == ParametrType.radialTensor) r = "Радиальное";
            if (tType == ParametrType.tangentialTensor) r = "Тангенсальное";
            for (int i = 0; i <= 2; i++)
            {
                chart1.Series.Add(myContact.GetSeriesAbs(i, tType));
                chart1.Series.Last().BorderWidth = 4;
                chart1.Series.Last().LegendText = "Результирующее напряжение " + i + "  " + r;
                chart1.Series.Last().Color = Color.Red;
            }
        }*/
        private void WriteTable(Contact myContact) // заполнить таблицу
        {
            //dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();
            //dataGridView1.ColumnCount = 2;

            //dataGridView1.Rows.Add("Напряжение 1", myContact.Pb_press.ToString());
            //dataGridView1.Rows.Add("Напряжение 2", myContact.Pc_press.ToString());
            //dataGridView1.Rows.Add("Момент от ускорения", myContact.Cylinders[1].GetMomentAccelertion(500));
            //dataGridView1.Rows.Add("Срыв Клея, МПа", myContact.Cylinders[1].GetRotationTensor(1000,700,500));
            
            dataGridView1.ColumnCount = 2;
            
            /*
            dataGridView1.ColumnCount = 11;
            dataGridView1.RowCount = 10;
            
            for (int i = 0; i < myContact.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < myContact.Matrix.GetLength(0); j++)
                {
                    dataGridView1[j, i].Value = myContact.Matrix[i, j].ToString();
                }
                dataGridView1[10, i].Value = myContact.CentrFree[i];
            }*/
            dataGridView1.Rows.Add("C1", myContact.CentrResult[(int)members.C1].ToString());
            dataGridView1.Rows.Add("C2", myContact.CentrResult[(int)members.C2].ToString());
            dataGridView1.Rows.Add("C3", myContact.CentrResult[(int)members.C3].ToString());
            dataGridView1.Rows.Add("C4", myContact.CentrResult[(int)members.C4].ToString());
            dataGridView1.Rows.Add("C5", myContact.CentrResult[(int)members.C5].ToString());
            dataGridView1.Rows.Add("C6", myContact.CentrResult[(int)members.C6].ToString());
            dataGridView1.Rows.Add("Pb", myContact.CentrResult[(int)members.Pb].ToString());
            dataGridView1.Rows.Add("Pc", myContact.CentrResult[(int)members.Pc].ToString());
            dataGridView1.Rows.Add("Ub", myContact.CentrResult[(int)members.Ub].ToString());
            dataGridView1.Rows.Add("Uc", myContact.CentrResult[(int)members.Uc].ToString());
            dataGridView1.Rows.Add("Срыв ", this.GetTensorRotation());
        }
        private void AddGraph(Contact myContact, StressType s_stressType, ParametrType s_ParametrType)
        {
            /*Color myColor = Color.Green;
            switch (s_stressType)
            {
                case StressType.Press:
                    myColor = Color.Green;
                    break;
                case StressType.Rotation:
                    myColor = Color.Blue;
                    break;
                case StressType.Summ:
                    myColor = Color.Red;
                    break;
            }*/
            for (int i = 0; i <= 2; i++)
            {                
                chart1.Series.Add(myContact.GetSeries(i, s_stressType, s_ParametrType));
                chart1.Series.Last().BorderWidth = 4;
                //chart1.Series.Last().Color = myColor;
            }
        }
        /// <summary>
        /// Считывает данные с полей
        /// </summary>
        private void readText() // считывание дааных
        {
            double b = Double.Parse(textBox1.Text);
            double c = Double.Parse(textBox2.Text);
            double t = Double.Parse(textBox3.Text);
            double a = Double.Parse(textBox5.Text);
            double delta = Double.Parse(textBox4.Text);
            double n = Double.Parse(textBox_Speed.Text);
             Acceleration = Double.Parse(textBox_Acceleration.Text);
            // первый слой         
            cylinder1 = new Cylinder(a, b, 14, Still_Still20);
            // второй слой 
            cylinder2 = new Cylinder(b, c, 14, Magnetic);
            cylinder3 = new Cylinder(c, c + t, 14, Titan);
            myContact = new Contact(cylinder1, cylinder2, cylinder3, delta, n);
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
        }

        private void checkedListBox_TensorType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index < 3)

            {
                //checkedListBox_TensorType.SetItemChecked(3, false);
                checkedListBox_TensorType.SetItemCheckState(3, CheckState.Unchecked);
            }
            if (e.Index == 3)
            {
                checkedListBox_TensorType.SetItemChecked(0, false);
                checkedListBox_TensorType.SetItemChecked(1, false);
                checkedListBox_TensorType.SetItemChecked(2, false);
            }
        }

        private void numericUpDown_MaxSize_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = (double)numericUpDown_MaxSize.Value;
        }

        private void numericUpDown_MinSize_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum = (double)numericUpDown_MinSize.Value;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string name = "Grap";
            name += "("+string.Join("-", textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text)+") ";
            List <string>  stress = new List<string>();
            List<string> param = new List<string>();
            for (int i=0; i<checkedListBox_PowerType.CheckedItems.Count;i++)
            {
                stress.Add(checkedListBox_PowerType.CheckedItems[i].ToString());
            }
            for(int i=0; i<checkedListBox_TensorType.Items.Count;i++)
            {
                if(checkedListBox_TensorType.GetItemChecked(i))
                {
                    switch (i)
                    {
                        case 0:
                            param.Add("Рад");
                            break;
                        case 1:
                            param.Add("Окр");
                            break;
                        case 2:
                            param.Add("Экв");
                            break;
                        case 3:
                            param.Add("Коэф");
                            break;
                    }
                }
            }
            name += "(" + string.Join("-", stress) + ") ";
            name += "(" + string.Join("-", param) + ") ";
            chart1.SaveImage("F:\\Ринат\\АГРЕГАТЫ\\Генератор Соната\\Рисунки от программы\\"+name + ".jpeg", ChartImageFormat.Jpeg);
        }

        private double GetTensorRotation() // ускорение
        {
            double result;
            Acceleration *= 2 * Math.PI;
            double Moment = myContact.Cylinders[1].MomentInertyia * myContact.Cylinders[2].MomentInertyia * Acceleration ;
            result = Moment * 1E-3 / (myContact.Cylinders[1].a * myContact.Cylinders[1].InsideSurfaceArea); 
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            readText();
            for (int i = 0; i < 3; i++)
            {
                if (checkedListBox_PowerType.GetItemChecked(i))
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (checkedListBox_TensorType.GetItemChecked(j))
                        {
                            AddGraph(myContact, (StressType)i, (ParametrType)j);
                        }
                    }
                } 
            }            
        }

    }
}
