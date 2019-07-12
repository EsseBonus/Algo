class Program
{
    // Классическая задача о рюкзаке без повторений
    static void Main(string[] args)
    {
        int[] mass = { 7, 3, 1, 5, 4 };
        int[] price = { 10, 4, 2, 6, 7 };

        // Дан рюкзак вместимостью 12
        int bagCapacity = 12;

        // вспомогательная матрица для хранения промежуточных вычислений [6, 13]
        // 0 0 0 0 0 0 0 0 0 0 0 0 0
        // 0 0 0 0 0 0 0 0 0 0 0 0 0
        // 0 0 0 0 0 0 0 0 0 0 0 0 0
        // 0 0 0 0 0 0 0 0 0 0 0 0 0
        // 0 0 0 0 0 0 0 0 0 0 0 0 0
        // 0 0 0 0 0 0 0 0 0 0 0 0 0
        // здесь строка и столбец с индексами [0] - должны иметь значение 0,
        // остальные ячейки могут иметь произвольное значение
        int[,] matrix = new int[mass.Length + 1, bagCapacity + 1];

        // перебор предметов от 1 до 5
        for (int itemIndex = 1; itemIndex < matrix.GetLength(0); itemIndex++) // arr.GetLength(0) = 6
        {
            //перебор вместимостей рюкзака от 1 до 12
            for (int currentCapacity = 1; currentCapacity < matrix.GetLength(1); currentCapacity++) // arr.GetLength(1) = 13
            {
                if (currentCapacity >= mass[itemIndex - 1])
                    matrix[itemIndex, currentCapacity] = Math.Max(
                        matrix[itemIndex - 1, currentCapacity],
                        matrix[itemIndex - 1, currentCapacity - mass[itemIndex - 1]] + price[itemIndex - 1]);
                else
                    matrix[itemIndex, currentCapacity] = matrix[itemIndex - 1, currentCapacity];
            }
        }

        // выведем получившуюся таблицу
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(string.Format("{0,4}", matrix[i, j]));
            }
            Console.WriteLine();
        }

        // в самой нижней правой ячейке матрица хранится максимальная стоимость, которую можно унести в рюкзаке
        // заданной вместимости
        Console.WriteLine(matrix[mass.Length, bagCapacity]);

        // восстановление ответа
        int tempBagCapacity = bagCapacity;
        for (int i = mass.Length; i >= 0; i--)
        {
            if (i - 1 >= 0 && matrix[i, tempBagCapacity] != matrix[i - 1, tempBagCapacity])
            {
                Console.WriteLine("масса " + mass[i - 1] + ", ценность " + price[i - 1]);
                tempBagCapacity -= mass[i - 1];
            }
        }
    }
}
