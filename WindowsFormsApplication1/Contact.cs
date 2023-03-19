using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{        
    class Contact
    {
        public Cylinder[] Cylinders = new Cylinder[3];
        public double delta; // натяг
        public double w;  // угловая частота вращения          
        private double K1, K2, K3, K4, K5, K6; // коэффициэнты для расчета посадки
        private double[] parametrs = new double[10]; // параметры для центробежного
        private double a, b, c, d;//основные размеры
        public double Pb_press, Pc_press; // давление контактов от посадки
        public double[,] Matrix;
        public double[] CentrResult = new double[10];
        public double[] CentrFree = new double[10];
        public Contact(Cylinder sCylinder1, Cylinder sCylinder2, Cylinder sCylinder3, double del, double n)// конструктор класса
        {
            Cylinders[0] = sCylinder1;
            Cylinders[1] = sCylinder2;
            Cylinders[2] = sCylinder3;
            delta = del;
            w = 2 * Math.PI * n;

            a = Cylinders[0].a;
            b = Cylinders[1].a;
            c = Cylinders[2].a;
            d = Cylinders[2].b;

            K1 = Cylinders[0].GetK1();
            K2 = Cylinders[1].GetK2();
            K3 = Cylinders[1].GetK3();
            K4 = Cylinders[1].GetK4();
            K5 = Cylinders[1].GetK1();
            K6 = Cylinders[2].GetK2();

            Pb_press = delta * 1E-9 * K3 / ((K6 - K4) * K3 - (K1 - K2) * K5);
            Pc_press = delta * 1E-9 * (K1 - K2) / ((K6 - K4) * K3 - (K1 - K2) * K5);
            this.CalcParametrs();
        }
        private double[,] GetNumbers(int N_Cylinder, radCyl i)// вычисляет свободней члены для цилиндра
        {
            double[,] result = new double[2, 3];
            material m = Cylinders[N_Cylinder].M;
            double r;
            if (i == radCyl.inside) r = Cylinders[N_Cylinder].a;
            else r = Cylinders[N_Cylinder].b;
            r *= 1E-3;// переводим в миллиметры
            result[0, 1] = m.E / (1 - m.my);
            result[0, 2] = -m.E / (r * r * (1 + m.my));
            result[0, 0] = (3 + m.my) * m.q * Math.Pow(w * r, 2)/8;

            result[1, 1] = r;
            result[1, 2] = 1 / r;
            result[1, 0] = (1 - Math.Pow(m.my, 2)) * m.q * Math.Pow(w, 2) * Math.Pow(r, 3) / (8*m.E);

            return result;
        }
        private void CalcParametrs()
        {

            double[,] Eq = GetNumbers(0, radCyl.inside); // первый целиндр внутрениий радиус
            // первыя строчка напряжение a
            EquationsSystem mySystem = new EquationsSystem(10);
            mySystem.myMatrix[0, (int)members.C1] = Eq[(int)StressType.Press, 1];
            mySystem.myMatrix[0, (int)members.C2] = Eq[(int)StressType.Press, 2];
            mySystem.freeNumbers[0] = Eq[(int)StressType.Press, 0];
            // вторая строчка напряжение b
            Eq = GetNumbers(0, radCyl.outside); // первый цилиндр внешний радиус
            mySystem.myMatrix[1, (int)members.C1] = Eq[(int)StressType.Press, 1];
            mySystem.myMatrix[1, (int)members.C2] = Eq[(int)StressType.Press, 2];
            mySystem.myMatrix[1,(int)members.Pb] = -1;
            mySystem.freeNumbers[1] = Eq[(int)StressType.Press, 0];
            // третья строчка перемещение b
             mySystem.myMatrix[2, (int)members.C1] = Eq[(int)StressType.Rotation, 1];
             mySystem.myMatrix[2, (int)members.C2] = Eq[(int)StressType.Rotation, 2];
             mySystem.myMatrix[2, (int)members.Ub] = -1;
             mySystem.freeNumbers[2] = Eq[(int)StressType.Rotation, 0];
             // четвертая строчка напряжение b
             Eq = GetNumbers(1, radCyl.inside); // второй цилиндр внутренний радиус
             mySystem.myMatrix[3, (int)members.C3] = Eq[(int)StressType.Press, 1];
             mySystem.myMatrix[3, (int)members.C4] = Eq[(int)StressType.Press, 2];
             mySystem.myMatrix[3, (int)members.Pb] = -1;
             mySystem.freeNumbers[3] = Eq[(int)StressType.Press, 0];
             // пятая строчка перемещение b
             mySystem.myMatrix[4, (int)members.C3] = Eq[(int)StressType.Rotation, 1];
             mySystem.myMatrix[4, (int)members.C4] = Eq[(int)StressType.Rotation, 2];
             mySystem.myMatrix[4, (int)members.Ub] = -1;
             mySystem.freeNumbers[4] = Eq[(int)StressType.Rotation, 0];
             // шестая строчка напряжение c
             Eq = GetNumbers(1, radCyl.outside);
             mySystem.myMatrix[5, (int)members.C3] = Eq[(int)StressType.Press, 1];
             mySystem.myMatrix[5, (int)members.C4] = Eq[(int)StressType.Press, 2];
             mySystem.myMatrix[5, (int)members.Pc] = -1;
             mySystem.freeNumbers[5] = Eq[(int)StressType.Press, 0];
             // седьмая строчка перемещение c
             mySystem.myMatrix[6, (int)members.C3] = Eq[(int)StressType.Rotation, 1];
             mySystem.myMatrix[6, (int)members.C4] = Eq[(int)StressType.Rotation, 2];
             mySystem.myMatrix[6, (int)members.Uc] = -1;
             mySystem.freeNumbers[6] = Eq[(int)StressType.Rotation, 0];
             // восьмая строчка напряжение с
             Eq = GetNumbers(2, radCyl.inside);
             mySystem.myMatrix[7, (int)members.C5] = Eq[(int)StressType.Press, 1];
             mySystem.myMatrix[7, (int)members.C6] = Eq[(int)StressType.Press, 2];
             mySystem.myMatrix[7, (int)members.Pc] = -1;
             mySystem.freeNumbers[7] = Eq[(int)StressType.Press, 0];
             // девятая строчка перемещение с
             mySystem.myMatrix[8, (int)members.C5] = Eq[(int)StressType.Rotation, 1];
             mySystem.myMatrix[8, (int)members.C6] = Eq[(int)StressType.Rotation, 2];
             mySystem.myMatrix[8, (int)members.Uc] = -1;
             mySystem.freeNumbers[8] = Eq[(int)StressType.Rotation, 0];
             // десятая строчка напряжение d
             Eq = GetNumbers(2, radCyl.outside);
             mySystem.myMatrix[9, (int)members.C5] = Eq[(int)StressType.Press, 1];
             mySystem.myMatrix[9, (int)members.C6] = Eq[(int)StressType.Press, 2];
             mySystem.freeNumbers[9] = Eq[(int)StressType.Press, 0];

            Matrix = (double[,])mySystem.myMatrix.Clone();

            double[] result = mySystem.CalcSystem();
            Cylinders[0].C1 = result[(int)members.C1];
            Cylinders[0].C2 = result[(int)members.C2];

            Cylinders[1].C1 = result[(int)members.C3];
            Cylinders[1].C2 = result[(int)members.C4];

            Cylinders[2].C1 = result[(int)members.C5];
            Cylinders[2].C2 = result[(int)members.C6];
            CentrResult = result;
            CentrFree = (double[])mySystem.freeNumbers.Clone();
        }
        /*
        public Series GetSeriesCentrob(int i, ParametrType paramType)
        {
            if (paramType == ParametrType.radialTensor)
                return Cylinders[i].GetSeriesCentrob_R(w, 0.1);
            if (paramType == ParametrType.tangentialTensor)
                return Cylinders[i].GetSeriesCentrob_T(w, 0.1);
            else return null;
        }
        public Series GetSeriesPress(int i, ParametrType paramType)
        {
            if (i == 0)
            {
                if (paramType == ParametrType.radialTensor)
                    return Cylinders[i].GetSeriesPress_R(0, Pb_press, 0.1);
                if (paramType == ParametrType.tangentialTensor)
                    return Cylinders[i].GetSeriesPress_T(0, Pb_press, 0.1);
                else return null;
            }
            if (i == 1)
            {
                if (paramType == ParametrType.radialTensor)
                    return Cylinders[i].GetSeriesPress_R(Pb_press, Pc_press, 0.1);
                if (paramType == ParametrType.tangentialTensor)
                    return Cylinders[i].GetSeriesPress_T(Pb_press, Pc_press, 0.1);
                else return null;
            }
            if (i == 2)
            {
                if (paramType == ParametrType.radialTensor)
                    return Cylinders[i].GetSeriesPress_R(Pc_press, 0, 0.1);
                if (paramType == ParametrType.tangentialTensor)
                    return Cylinders[i].GetSeriesPress_T(Pc_press, 0, 0.1);
                else return null;
            }
            else return null;
        }
        public Series GetSeriesAbs(int i, ParametrType paramType)
        {
            if (i == 0)
            {
                if (paramType == ParametrType.radialTensor)
                    return Cylinders[i].GetSeries_R(0, Pb_press, w, 0.1);
                if (paramType == ParametrType.tangentialTensor)
                    return Cylinders[i].GetSeries_T(0, Pb_press, w, 0.1);
                else return null;
            }
            if (i == 1)
            {
                if (paramType == ParametrType.radialTensor)
                    return Cylinders[i].GetSeries_R(Pb_press, Pc_press, w, 0.1);
                if (paramType == ParametrType.tangentialTensor)
                    return Cylinders[i].GetSeries_T(Pb_press, Pc_press, w, 0.1);
                else return null;
            }
            if (i == 2)
            {
                if (paramType == ParametrType.radialTensor)
                    return Cylinders[i].GetSeries_R(Pc_press, 0, w, 0.1);
                if (paramType == ParametrType.tangentialTensor)
                    return Cylinders[i].GetSeries_T(Pc_press, 0, w, 0.1);
                else return null;
            }
            else return null;

        }
        */
        /// <summary>
        /// Универсальная функция вывода графиков
        /// </summary>
        /// <param name="nomberCylinder"></param>
        /// <param name="s_StressType"></param>
        /// <param name="s_ParamTypse"></param>
        /// <returns></returns>
        public Series GetSeries(int nomberCylinder, StressType s_StressType, ParametrType s_ParamTypse)
        {
            string nCylinder = ""; // номер цилиндра
            string stress = ""; // нагрузка
            string param = ""; // параметр
            switch(s_StressType)
            {
                case StressType.Press:
                    stress = "от натяга";
                    break;
                case StressType.Rotation:
                    stress = "от вращения";
                    break;
                case StressType.Summ:
                    stress = "результ.";
                    break;
            }
            switch(s_ParamTypse)
            {
                case ParametrType.radialTensor:
                    param = "рад. напр.";
                    break;
                case ParametrType.tangentialTensor:
                    param = "окр. напр.";
                    break;
                case ParametrType.equivalentTensor:
                    param = "экв. напр.";
                    break;
                case ParametrType.safeK:
                    param = "К запаса";
                    break;
            }
            Series mySeries = new Series();
            switch(nomberCylinder)
            {
                case 0:
                    mySeries = Cylinders[0].GetSeries(s_StressType, s_ParamTypse, 0, Pb_press, w, 0.1);
                    nCylinder = "Сердечник";
                    break;
                case 1:
                    mySeries = Cylinders[1].GetSeries(s_StressType, s_ParamTypse, Pb_press, Pc_press, w, 0.1);
                    nCylinder = "Магнит";
                    break;
                case 2:
                    mySeries = Cylinders[2].GetSeries(s_StressType, s_ParamTypse, Pc_press, 0 , w, 0.1);
                    nCylinder = "Бандаж";
                    break;              
            }
            mySeries.LegendText = nCylinder + ". " + param + " " + stress;
            return mySeries;
        }
    }
}
