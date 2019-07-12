// Задача отсюда: https://app.codility.com/programmers/task/number_of_disc_intersections/
class Program
{
    static void Main(string[] args)
    {
        int[] A = new int[6];

        A[0] = 1;
        A[1] = 5;
        A[2] = 2;
        A[3] = 1;
        A[4] = 4;
        A[5] = 0;

        int ans = Solution(A);

        Console.WriteLine(ans);
    }

    static int Solution(int[] A)
    {
        // представим окружности в виде отрезков

        // создадим 2 массива для хранения левой и правой координаты каждого отрезка
        // O(1)
        int[] leftCoordinate = new int[A.Length + 2];
        int[] rightCoordinate = new int[A.Length + 2];

        // заполняем массив
        // O(n)
        for (int i = 0; i < A.Length; i++)
        {
            leftCoordinate[i + 1] = i - A[i];
            rightCoordinate[i + 1] = A[i] + i;
        }

        // "заглушки" по краям
        // O(1)
        leftCoordinate[0] = int.MinValue;
        rightCoordinate[0] = int.MinValue;
        leftCoordinate[leftCoordinate.Length - 1] = int.MaxValue;
        rightCoordinate[rightCoordinate.Length - 1] = int.MaxValue;

        // Сортировка массивов (предполагается, что она выполняется за O(n * log n)
        // O(n * log n)
        Array.Sort(leftCoordinate, rightCoordinate);

        int sum = 0;

        // O(n)
        // перебираем отрезки
        for (int i = 1; i < leftCoordinate.Length - 1; i++)
        {
            if (sum > 10000000)
            {
                return -1;
            }

            // двоичный поиск в отсортированном массиве
            // O(log n)
            sum += GetClosestNumber(leftCoordinate, rightCoordinate, rightCoordinate[i], i + 1) - i;
        }

        return sum;
    }

    // Итого: O(1) + O(n) + O(1) + O(n * log n) + O(n * log n) = O(n * log n)

    static int GetClosestNumber(int[] leftCoordinate, int[] rightCoordinate, int target, int i)
    {
        int first = i;
        int last = leftCoordinate.Length - 1;

        return _GetClosestNumber(leftCoordinate, rightCoordinate, target, first, last);
    }

    static int _GetClosestNumber(int[] leftCoordinate, int[] rightCoordinate, int target, int first, int last)
    {
        int middle = (last + first) / 2;

        if (first > last)
        {
            return last;
        }

        if (leftCoordinate[middle - 1] == int.MinValue)
        {
            return 0;
        }

        if (leftCoordinate[middle] >= target)
        {
            if (leftCoordinate[middle - 1] < target)
            {
                return middle - 1;
            }

            return _GetClosestNumber(leftCoordinate, rightCoordinate, target, first, middle - 1);
        }
        else
        {
            return _GetClosestNumber(leftCoordinate, rightCoordinate, target, middle + 1, last);
        }
    }
}
