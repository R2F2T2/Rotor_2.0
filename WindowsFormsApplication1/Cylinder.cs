using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{

    public struct material
    {
        public double q;
        public double E; // модуль Юнга
        public double my; // 
        public materialType mType;
        public double maxT_Press, maxT_Stretch;
        public material(double sQ, double sE, double sMy,materialType sType, double maxTensPress, double maxTensStretch)
        {
            q = sQ;
            E = sE;
            my = sMy;
            mType = sType;
            maxT_Press = maxTensPress;
            maxT_Stretch = maxTensStretch;
        }
    };
    class Cylinder
    {
        public material M = new material();
        public double a, // внутр радиус 
                      b;  // внешний радиус 
        private double aM, // внутр радиус 
                      bM;  // внешний радиус            
                           // n; // частота вращения
        public double l, lM; // длина цилиндра 
        public double C1, C2;
        private double a2, b2;
        //-----cвойства-------------------------
        /// <summary>
        /// Момент инерции цилиндра
        /// </summary>
        double momentInetyia; //момент инерции
        /// <summary>
        /// Момент инерции цилиндра
        /// </summary>
        public double MomentInertyia
        {
            get { return momentInetyia; }

        }
        /// <summary>
        /// Площадь внутренней поверхности
        /// </summary>
        double insideSurfaseArea; // прощадь внутренней повехности повехности
        /// <summary>
        /// Площадь внутренней поверхности
        /// </summary>
        public double InsideSurfaceArea
        {
            get { return insideSurfaseArea;}
        }
        /// <summary>
        /// Площадь наружной поверхности
        /// </summary>
        double outsideSurfaceArea; // 
        /// <summary>
        /// Площадь наружной поверхности
        /// </summary>
        public double OutsideSurfaceArea
        {
            get { return OutsideSurfaceArea; }
        }
        //-------------------------------
        public Cylinder(double sA, double sB, double sl, material sMat)
        {
            a = sA;
            b = sB;
            l = sl;

            aM = sA * 1E-3;
            bM = sB * 1E-3;
            lM = sl * 1E-3;

            M = sMat;
            a2 = aM * aM;
            b2 = bM * bM;
            // вычисляем свойства
            momentInetyia = M.q * Math.PI * lM * (Math.Pow(bM, 4) - Math.Pow(aM, 4))/2;
            insideSurfaseArea = 2 * Math.PI * aM * lM;
            outsideSurfaceArea = 2 * Math.PI * bM * lM;
        }

        // центробежные силы ---------------------------------------------------------------
        private double TensorCentrob_R(double w, double r) // радиальное напряжение от центробежных сил МПа
        {
            double r2 = r * r * 1E-6;
            return  (
                    (M.E / (1 - M.my * M.my)) * (C1 * (1 + M.my) - C2 * (1 - M.my) / r2) - M.q * w * w * (3 + M.my) * r2 / 8
                    )*1E-6;
            //return M.q* w *w * (3.0 + M.my) * (b2 + a2 - (a2 * b2 / r2) - r2) / 8E6;                
        }
        private double TensorCentrob_T(double w, double r) // окружное напряжение от центробежных сил МПа
        {
            double r2 = r * r * 1E-6;
            return (
                (M.E / (1 - M.my * M.my)) * (C1 * (1 + M.my) + C2 * (1 - M.my) / r2) - M.q * w * w * (1 + 3 * M.my) * r2/8 
                )* 1E-6;
        }
        // давление ---------------------------------------------------------------------------------------
        private double TensorPress_R(double InsPress, double OutPress, double r) // радиальное напряжение от давления МПа
        {
            double r2 = r * r * 1E-6;
            return (InsPress * a2 - OutPress * b2) / (b2 - a2) - (a2 * b2 / r2) * (InsPress - OutPress) / (b2 - a2);
        }
        private double TensorPress_T(double InsPress, double OutPress, double r) // окружное напряжение от давления МПа
        {
            double r2 = r * r * 1E-6;
            return (InsPress * a2 - OutPress * b2) / (b2 - a2) + (a2 * b2 / r2) * (InsPress - OutPress) / (b2 - a2);
        }
        //Универсальые функция        
        public double GetTensorCentrob(double w, double r, ParametrType Param)
        {
            double r2 = r * r * 1E-6;
            switch (Param)
            {
                case ParametrType.radialTensor:
                    return TensorCentrob_R(w, r);
                case ParametrType.tangentialTensor:
                    return TensorCentrob_T(w, r);
                case ParametrType.equivalentTensor:
                    return EqTensor(TensorCentrob_R(w, r), TensorCentrob_T(w, r));
                case ParametrType.safeK:
                    return M.maxT_Stretch / EqTensor(TensorCentrob_R(w, r), TensorCentrob_T(w, r));
                default:
                    return 0;
            }
        }
        public double GetTensorPress(double InsPress, double OutPress, double r, ParametrType Param)
        {
            switch (Param)
            {
                case ParametrType.radialTensor:
                    return TensorPress_R(InsPress, OutPress, r);
                case ParametrType.tangentialTensor:
                    return TensorPress_T(InsPress, OutPress, r);
                case ParametrType.equivalentTensor:
                    return EqTensor(TensorPress_R(InsPress, OutPress, r), TensorPress_T(InsPress, OutPress, r));
                case ParametrType.safeK:
                    return M.maxT_Stretch / EqTensor(TensorPress_R(InsPress, OutPress, r), TensorPress_T(InsPress, OutPress, r));
                default:
                    return 0;
            }
        }
        
        // Обобщающая функция------------------------------
        public double GetTensor(StressType s_StressType, ParametrType s_ParamType, double InsPress, double OutPress, double w, double r, double t)
        {
            switch (s_StressType)
            {
                case StressType.Press:
                    return GetTensorPress(InsPress, OutPress, r, s_ParamType);
                case StressType.Rotation:
                    return GetTensorCentrob(w, r, s_ParamType);
                case StressType.Summ:
                    if(s_ParamType==ParametrType.equivalentTensor)
                    {
                        return EqTensor
                            (
                            GetTensorCentrob(w,r,ParametrType.radialTensor) + GetTensorPress(InsPress,OutPress,r,ParametrType.radialTensor),
                            GetTensorCentrob(w, r, ParametrType.tangentialTensor) + GetTensorPress(InsPress, OutPress, r, ParametrType.tangentialTensor)
                            );
                    }
                    if (s_ParamType == ParametrType.safeK)
                    {
                        return M.maxT_Stretch/EqTensor
                            (
                            GetTensorCentrob(w, r, ParametrType.radialTensor) + GetTensorPress(InsPress, OutPress, r, ParametrType.radialTensor),
                            GetTensorCentrob(w, r, ParametrType.tangentialTensor) + GetTensorPress(InsPress, OutPress, r, ParametrType.tangentialTensor)
                            );
                    }
                    return GetTensorPress(InsPress, OutPress, r, s_ParamType) + GetTensorCentrob(w, r, s_ParamType);
                default:
                    return 0;
            }
        }
        //Общие вычисления--------------------------------------------------------------------------------
        public double EqTensor (double Tensor1, double Tensor2) // Вычисляет эквиваленьтое напряжение
        {
            double Ten1, Ten2;
            double k = 1; 
            if(Math.Abs(Tensor1)< Math.Abs(Tensor2))
            {
                Ten1 = Tensor2;
                Ten2 = Tensor1;
            }
            else
            {
                Ten1 = Tensor1;
                Ten2 = Tensor2;
            }
            if (M.mType == materialType.fragile)
            {
                k = M.maxT_Stretch / M.maxT_Press;
            }
            //else k = 1;
            return Ten1 - Ten2 * k;
        }

        // вывод графиков -------------------------------------------------------------------------------      
        /*
        public Series GetSeriesCentrob_R(double w, double t) // график радиального напряжения  от центробежных сил
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, TensorCentrob_R(w, r));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        public Series GetSeriesCentrob_T(double w, double t)// график окружного напряжения  от центробежных сил
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, TensorCentrob_T(w, r));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        public Series GetSeriesPress_R(double InsPress, double OutPress, double t)// график радиального напряжения  от давления
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, TensorPress_R(InsPress, OutPress, r));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        public Series GetSeriesPress_T(double InsPress, double OutPress, double t)// график тангенсального напряжения  от давления
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, TensorPress_T(InsPress, OutPress, r));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        public Series GetSeries_R(double InsPress, double OutPress, double w, double t)// график абсолютного радиального напряжения
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, TensorPress_R(InsPress, OutPress, r) + TensorCentrob_R(w, r));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        public Series GetSeries_T(double InsPress, double OutPress, double w, double t)// график абсолютного окружного напряжения
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, TensorPress_T(InsPress, OutPress, r) + TensorCentrob_T(w, r));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        */
        //Универсальные функции
        public Series GetSeries(StressType s_StressType, ParametrType s_ParamType, double InsPress, double OutPress, double w, double t)
        {
            
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            for (double r = a; r <= b; r += t)
            {
                ser.Points.AddXY(r, GetTensor(s_StressType, s_ParamType, InsPress, OutPress, w, r, t));
            }
            ser.Points.First().Label = ser.Points.First().YValues[0].ToString();
            ser.Points.Last().Label = ser.Points.Last().YValues[0].ToString();
            return ser;
        }
        
        // Другие физические величины ----------------------------------

        public double GetK1()
        {
            return -((1 - M.my) * Math.Pow(bM, 3) + (1 + M.my) * a2 * bM) / (M.E * (b2 - a2));
        }
        public double GetK2()
        {
            return ((1 - M.my) * Math.Pow(aM, 3) + (1 + M.my) * b2 * aM) / (M.E * (b2 - a2));
        }
        public double GetK3()
        {
            return -(2 * b2 * aM) / (M.E * (b2 - a2));
        }
        public double GetK4()
        {
            return (2 * a2 * bM) / (M.E * (b2 - a2));
        }

    }
}
