using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class EquationsSystem
    {
        // версия 2.0
        public double[,] myMatrix; // основаная матрица
        public double[] freeNumbers; // свободные члены
        int mySize; // размер матрицы
        double determinant; // определитель
        

        public EquationsSystem(int size)// конструктор
        {
            mySize = size;
            myMatrix = new double[size, size];
            freeNumbers = new double[size];
        }
                

         double[,] GetMinorMatrix(double[,] matrix, int row)// возвращает минорную матрицу
        {
            double[,] result = new double[matrix.GetLength(0) - 1,matrix.GetLength(1)-1];
            int ResultRow = 0;
            for (int i = 0; i<matrix.GetLength(0) ;i++)
            {
                if (i!=row)
                {
                    for(int j=1; j<matrix.GetLength(1);j++)
                    {
                        result[ResultRow, j - 1] = matrix[i, j];
                    }
                    ResultRow++;                  
                }
            }
            return result;
            
        }
         double GetDeterminant(double[,] matrix)// возвращает определитель матрицы
        {
            if (matrix.GetLength(0) == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double Det = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, 0] != 0)
                    {
                        Det += Math.Pow(-1, i) * matrix[i, 0] * GetDeterminant(GetMinorMatrix(matrix, i));
                    }
                }
                return Det;
            }
        }
        /// <summary>
        /// Заменяет столбец основной матрицы на collumn
        /// </summary>
        /// <param name="collumn"></param>
        /// <param name="position"></param>
        /// <returns></returns>
         double[,] AddCollumn(double[] collumn, int position) //заменяет с матрице одну колонку на заданную
        {
            double[,] result = (double[,]) myMatrix.Clone();
            
            if (collumn.GetLength(0) <= myMatrix.GetLength(0) && position < myMatrix.GetLength(1))
            {
                for (int i = 0; i < collumn.GetLength(0); i++)
                {
                    result[i, position] = collumn[i];
                }
            }
            return result;
        }
        public double[] CalcSystem() // Решить систему уравнений
        {
            determinant = GetDeterminant(myMatrix);
            double[] result = new double[mySize];
            for (int i=0; i<mySize; i++)
            {               
                result[i] = GetDeterminant(AddCollumn(freeNumbers, i)) / determinant;
            }
            return result;
        }


    }
}
