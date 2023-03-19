using System;
namespace WindowsFormsApplication1
{
    /// <summary>
    /// Параметр для матрицы
    /// </summary>
    public enum members
    {
        C1 = 0,
        C2 = 1,
        C3 = 2,
        C4 = 3,
        C5 = 4,
        C6 = 5,
        Pb = 6,
        Pc = 7,
        Ub = 8,
        Uc = 9
    }
    
    /// <summary>
    /// Внешний или внутренний радиус цилиндра
    /// </summary>
    public enum radCyl
    {
        inside = 0,
        outside = 1
    }
    
    /// <summary>
    /// тип параметра
    /// </summary>
    public enum ParametrType
    {
        radialTensor = 0,
        tangentialTensor = 1,
        equivalentTensor = 2,
        safeK = 3
    }
    /// <summary>
    /// вид нагрузки
    /// </summary>
    public enum StressType
    {
        Press = 0,
        Rotation = 1,
        Summ = 2
    }

    /// <summary>
    /// тип материала
    /// </summary>
    public enum materialType
    {
        fragile = 1,
        plastic = 0
    }
}