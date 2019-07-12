// Требуется выдать некоторую сумму минимальным кол-вом купюр
class Program
{
    static void Main(string[] args)
    {
        // Номиналы банкнот, их кол-во неограничено
        //int[] Banknotes = { 50, 100, 500, 1000, 5000 };
        int[] Banknotes = { 1, 3, 5 };


        // Сумма, которую нужно выдать
        //int TotalSum = 18750;
        int TotalSum = 7;

        // Заглушка с большим значением
        int inf = 1000000;

        // Массив сумм размерностью 18751
        int[] arrayOfSums = new int[TotalSum + 1];
        arrayOfSums[0] = 0;
        for (int i = 1; i < arrayOfSums.Length; i++)
        {
            // arrayOfSums[0] = 0, т.к. выдать сумму 0 можно нулем купюр,
            // arrayOfSums[1], arrayOfSums[2], arrayOfSums[3] .. arrayOfSums[18751] = inf
            arrayOfSums[i] = inf;
        }

        // Вспомогательный массив для восстановления ответа с помощью сохранения предка
        int[] previuos = new int[TotalSum + 1];
        for (int i = 0; i < previuos.Length; i++)
        {
            previuos[i] = -1;
        }

        // Подставляем суммы от 1 до 18750
        for (int currentSum = 1; currentSum < arrayOfSums.Length; currentSum++)
        {
            // Перебираем номиналы, т.е. пытаемся подставленную выше сумму набрать каждой из купюр
            // Banknotes[0] = 50, Banknotes[1] = 100, Banknotes[2] = 500, 
            // Banknotes[3] = 1000, Banknotes[0] = 5000 по очереди
            for (int banknoteIndex = 0; banknoteIndex < Banknotes.Length; banknoteIndex++)
            {
                int currentBanknoteValue = Banknotes[banknoteIndex];

                if (currentSum - currentBanknoteValue >= 0 &&
                    arrayOfSums[currentSum - currentBanknoteValue] < arrayOfSums[currentSum])
                {
                    arrayOfSums[currentSum] = arrayOfSums[currentSum - currentBanknoteValue];

                    // Эта строка нужна для восстановления ответа с помощью сохранения предка 
                    previuos[currentSum] = Banknotes[banknoteIndex];
                }
            }

            arrayOfSums[currentSum]++;

            //if (arrayOfSums[currentSum] != inf)
            //{
            //    Console.Write("Сумма = {0}, \tмин. кол-во купюр = {1}\n", currentSum, arrayOfSums[currentSum]);
            //}
        }

        // Восстановление ответа "обратным ходом"
        // Для восстановления ответа создаем новый массив размером равным кол-ву купюр в TotalSum
        int tempSum = TotalSum;
        while (tempSum > 0)
        {
            for (int banknoteIndex = 0; banknoteIndex < Banknotes.Length; banknoteIndex++)
            {
                if (tempSum - Banknotes[banknoteIndex] >= 0 &&
                    arrayOfSums[tempSum] == arrayOfSums[tempSum - Banknotes[banknoteIndex]] + 1)
                {
                    Console.Write(Banknotes[banknoteIndex] + " "); // 1 3 3 
                    tempSum -= Banknotes[banknoteIndex];
                }
            }
        }

        // Восстановление ответа с помощью сохранения предка
        // Обрати внимание, что вывод ответа полученного "обратным ходом" отличается от ответа, 
        // полученного с помощью сохранения предка
        tempSum = TotalSum;
        while (tempSum > 0)
        {
            Console.Write(previuos[tempSum] + " "); // 1 1 5  
            tempSum -= previuos[tempSum];
        }
    }
}
