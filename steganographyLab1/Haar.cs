// Вейвлет Хаара by Мухен.
// Юзайте на здоровье.
// Для двумерного массива необходимо преобразовать каждую строчку (TransformRow) исходного массива,
// а затем - каждый столбец (TransformColumn) получившегося.
// При восстановлении - то же самое.


using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace HaarFramework2
{
    class Haar
    {
        /// <summary>
        /// Преобразование Хаара
        /// Выполняется указанное количество раз
        /// </summary>
        public void HaarTransform(ref float[] array, int level)
        {
            int SIZE = array.GetLength(0);    // Количество элементов
            float[] avg = new float[SIZE];    // Суммы
            float[] diff = new float[SIZE];   // Разности

            // count - количество повторов
            for (int count = SIZE; count > array.Length / (2 * level); count /= 2)
            {
                // Рассчитать полусуммы и разности, занести во временные массивы сумм и разностей
                for (int i = 0; i < count / 2; i++)
                {
                    avg[i] = (array[2 * i] + array[2 * i + 1]) / 2;
                    diff[i] = array[2 * i] - avg[i];
                }

                // Перенести суммы и разности в итоговый массив
                for (int i = 0; i < count / 2; i++)
                {
                    array[i] = avg[i]; // В первую половину
                    array[i + count / 2] = diff[i]; // Во вторую половину
                }
            }
        }

        /// <summary>
        /// Трансформация указанной строки указанного массива
        /// </summary>
        public void TransformRow(ref float[,] data, int row, int level)
        {
            int SIZE = data.GetLength(0);

            // Временный массив для строки
            float[] rowdata = new float[SIZE];
            int i;

            // Считать элементы строки двумерного массива и занести их во временный
            for (i = 0; i < SIZE; i++)
                rowdata[i] = data[row, i];

            HaarTransform(ref rowdata, level);

            // Записать строку в указанный двумерный массив
            for (i = 0; i < SIZE; i++)
                data[row, i] = rowdata[i];
        }

        /// <summary>
        /// Трансформация указанного столбца указанного массива
        /// </summary>
        public void TransformColumn(ref float[,] data, int col, int level)
        {
            int SIZE = data.GetLength(0);

            // Временный массив для столбца
            float[] coldata = new float[SIZE];
            int i;

            // Считать элементы столбца двумерного массива и занести их во временный
            for (i = 0; i < SIZE; i++)
                coldata[i] = data[i, col];

            HaarTransform(ref coldata, level);

            // Записать столбец в указанный двумерный массив
            for (i = 0; i < SIZE; i++)
                data[i, col] = coldata[i];
        }

        // То же самое, но для int
        public void HaarTransformInt16(ref Int16[] array, int level)
        {
            int SIZE = array.GetLength(0);      // Количество элементов
            Int16[] avg = new Int16[SIZE];    // Суммы
            Int16[] diff = new Int16[SIZE];   // Разности

            // count - количество повторов
            for (int count = SIZE; count > array.Length / (2 * level); count /= 2)
            {
                // Рассчитать полусуммы и разности, занести во временные массивы сумм и разностей
                for (int i = 0; i < count / 2; i++)
                {
                    avg[i] = (Int16)((array[2 * i] + array[2 * i + 1]) / 2);
                    diff[i] = (Int16)(array[2 * i] - avg[i]);
                }

                // Перенести суммы и разности в итоговый массив
                for (int i = 0; i < count / 2; i++)
                {
                    array[i] = avg[i]; // В первую половину
                    array[i + count / 2] = diff[i]; // Во вторую половину
                }
            }
        }
        //public void HaarTransformInt16(ref Int16[] array, int level)
        //{
        //    int SIZE = array.GetLength(0);      // Количество элементов
        //    Int16[] avg = new Int16[SIZE];    // Суммы
        //    Int16[] diff = new Int16[SIZE];   // Разности

        //    int count = SIZE;

        //    for (int x = 0; x < level - 1; x++)
        //    {
        //        // Рассчитать полусуммы и разности, занести во временные массивы сумм и разностей
        //        for (int i = 0; i < count / 2; i++)
        //        {
        //            avg[i] = (Int16)((array[2 * i] + array[2 * i + 1]) / 2);
        //            diff[i] = (Int16)(array[2 * i] - avg[i]);
        //        }

        //        // Перенести суммы и разности в итоговый массив
        //        for (int i = 0; i < count / 2; i++)
        //        {
        //            array[i] = avg[i];               // В первую половину
        //            array[i + count / 2] = diff[i];  // Во вторую половину
        //        }

        //        count /= 2;
        //    }
        //}

        /// <summary>
        /// Трансформация указанной строки указанного массива
        /// </summary>
        /// 

        public void TransformRowInt16(ref Int16[,] data, int row, int level)
        {
            int SIZE = data.GetLength(0);

            // Временный массив для строки
            Int16[] rowdata = new Int16[SIZE];
            int i;

            // Считать элементы строки двумерного массива и занести их во временный
            for (i = 0; i < SIZE; i++)
                rowdata[i] = data[row, i];

            HaarTransformInt16(ref rowdata, level);

            // Записать строку в указанный двумерный массив
            for (i = 0; i < SIZE; i++)
                data[row, i] = rowdata[i];
        }

        /// <summary>
        /// Трансформация указанного столбца указанного массива
        /// </summary>
        public void TransformColumnInt16(ref Int16[,] data, int col, int level)
        {
            int SIZE = data.GetLength(0);

            // Временный массив для столбца
            Int16[] coldata = new Int16[SIZE];
            int i;

            // Считать элементы столбца двумерного массива и занести их во временный
            for (i = 0; i < SIZE; i++)
                coldata[i] = data[i, col];

            HaarTransformInt16(ref coldata, level);

            // Записать столбец в указанный двумерный массив
            for (i = 0; i < SIZE; i++)
                data[i, col] = coldata[i];
        }




























        //static void HaarTransformInverse(ref float[] array)
        //{
        //    int SIZE = array.GetLength(0);

        //    float[] tmp = new float[SIZE];
        //    int i, count;

        //    for (count = 2; count <= SIZE; count *= 2)
        //    {
        //        for (i = 0; i < count / 2; i++)
        //        {
        //            tmp[2 * i] = array[i] + array[i + count / 2];
        //            tmp[2 * i + 1] = array[i] - array[i + count / 2];
        //        }

        //        for (i = 0; i < count; i++) array[i] = tmp[i];
        //    }
        //}
        public void HaarTransformInverse(ref float[] array, int level)
        {
            int SIZE = array.GetLength(0);

            float[] tmp = new float[SIZE];
            int i;
            int count = 2;

            for (int x = 0; x < level - 1; x++)
            {
                for (i = 0; i < count / 2; i++)
                {
                    tmp[2 * i] = (float)(array[i] + array[i + count / 2]);
                    tmp[2 * i + 1] = (float)(array[i] - array[i + count / 2]);

                }

                for (i = 0; i < count; i++)
                    array[i] = tmp[i];

                count *= 2;
            }
        }

        public void TransformColumnInverse(ref float[,] data, int col, int level)
        {
            int SIZE = data.GetLength(0);

            float[] coldata = new float[SIZE];
            int i;

            for (i = 0; i < SIZE; i++)
                coldata[i] = data[i, col];

            HaarTransformInverse(ref coldata, level);

            for (i = 0; i < SIZE; i++)
                data[i, col] = coldata[i];
        }

        public void TransformRowInverse(ref float[,] data, int row, int level)
        {
            int SIZE = data.GetLength(0);

            float[] rowdata = new float[SIZE];
            int i;

            for (i = 0; i < SIZE; i++)
                rowdata[i] = data[row, i];

            HaarTransformInverse(ref rowdata, level);

            for (i = 0; i < SIZE; i++)
                data[row, i] = rowdata[i];
        }
    }
}
