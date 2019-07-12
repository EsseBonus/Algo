class Program
{
    // Классическая задача о рюкзаке с повторениями, но на примере стержня
    static void Main(string[] args)
    {
        // 0  1  2  3
        int[] lengths = { 1, 2, 3, 4 };
        int[] price = { 1, 5, 8, 9 };

        // Дан стержень, длиной 4
        int rodLength = 4;

        int[] rodLengths = new int[rodLength + 1];

        // промежуточный массив для хранения индексов длин, из которых была составлена текущая длина
        int[] tempLengthsIndexes = new int[rodLength + 1];

        for (int currentLength = 1; currentLength < rodLengths.Length; currentLength++)
        {
            for (int itemIndex = 0; itemIndex < lengths.Length; itemIndex++)
            {
                if (lengths[itemIndex] <= currentLength)
                {
                    int a = rodLengths[currentLength];
                    int b = rodLengths[currentLength - lengths[itemIndex]] + price[itemIndex];

                    rodLengths[currentLength] = Math.Max(a, b);

                    // нужно для восстановления решения
                    if (a < b)
                        tempLengthsIndexes[currentLength] = itemIndex;
                }
            }
        }

        // выведем получившийся массив, последняя ячейка которого - это как раз максимальная цена, 
        // которую мы можем получить
        for (int i = 0; i < rodLengths.Length; i++)
        {
            Console.Write(rodLengths[i] + " ");
        }

        Console.WriteLine();

        Console.WriteLine("Режем стержень на куски длиной:");
        // восстановление ответа
        int temp = 0;
        for (int index = tempLengthsIndexes.Length - 1; index > 0; index -= lengths[temp])
        {
            temp = tempLengthsIndexes[index];
            Console.Write(lengths[temp] + " ");
        }
    }
}
