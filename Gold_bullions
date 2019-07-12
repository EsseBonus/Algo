class Program
{
    // Нужно унести как можно больше золотых слитков по весу, т.е. дан набор разных по весу слитков,
    // но стоимость за одну единицу веса у них одинакова
    static void Main(string[] args)
    {
        // Даны золотые слитки весом 3, 5, 7, 10
        int[] bullions = { 3, 5, 7, 10 };

        // Дан рюкзак вместимостью 14
        int bagCapacity = 14;

        // Массив размеров рюкзаков от 0 до bagCapacity
        int[] bags = new int[bagCapacity + 1];
        bags[0] = 1; // т.к. рюкзак вместимостью 0 можно заполнить одним способом - не взяв ни одного слитка

        // Вспомогательный массив для восстановления ответа с помощью сохранения предка
        int[] previous = new int[bagCapacity + 1];
        for (int i = 0; i < previous.Length; i++)
        {
            previous[i] = -1;
        }

        for (int bullionIndex = 0; bullionIndex < bullions.Length; bullionIndex++)
        {
            // Размеры рюкзаков перебираем с конца, это важно! 
            // Если перебирать от начала, то получится, что слитка каждого веса неограниченное кол-во
            for (int currentBagCapacity = bagCapacity; currentBagCapacity >= bullions[bullionIndex]; currentBagCapacity--)
            {
                if (bags[currentBagCapacity - bullions[bullionIndex]] == 1)
                {
                    bags[currentBagCapacity] = 1;

                    // Эта строка нужна для восстановления ответа с помощью сохранения предка
                    previous[currentBagCapacity] = bullions[bullionIndex];
                }
            }
        }

        // Получаем максимальный вес слитков, который мы можем унести в рюкзаке размером bagCapacity
        int resultSum = bagCapacity;
        while (bags[resultSum] == 0)
        {
            resultSum--;
        }

        Console.WriteLine(resultSum);

        // Восстановление ответа
        int currentSum = resultSum;
        while (currentSum > 0)
        {
            Console.WriteLine(previous[currentSum]);
            currentSum -= previous[currentSum];
        }
    }
}
