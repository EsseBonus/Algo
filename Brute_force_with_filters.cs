//здесь из последовательности в 5 элементов, генерируются все возможные комбинации из 3-х элементов, т.е.:
//дана последовательность - { 1, 2, 3, 4, 5 }
//вот все возможные комбинации из 3-х элементов:
// 1 2 3 
// 1 2 4
// 1 2 5
// 1 3 4
// 1 3 5
// 1 4 5
// 2 3 4
// 2 3 5
// 2 4 5
// 3 4 5
// итого 10 комбинаций, формула - C = 5!/3!(5-3)! = 10
class Program
{
    static void Main(string[] args)
    {
        GenerateSequence(5, 3);
    }

    static void GenerateSequence(int n, int k, string prefix = "")
    {
        if (n == 0)
        {
            //if (k == 0) // эта строка не нужна в случае, если проверяется такое условие "if (n > k)"
            Console.WriteLine(prefix);
        }
        else
        {
            if (n > k)
                GenerateSequence(n - 1, k, prefix + "0");

            if (k > 0)
                GenerateSequence(n - 1, k - 1, prefix + "1");
        }
    }

    //Просто еще один менее эффективный вариант того же метода
    //static void GenerateSequence(int n, int k, string prefix = "")
    //{
    //    if (n == 0)
    //    {
    //        if (prefix.Count(c => c == '1') == 3)
    //        {
    //            Console.WriteLine(prefix);
    //        }
    //    }
    //    else
    //    {
    //        GenerateSequence(n - 1, k, prefix + "0");
    //        GenerateSequence(n - 1, k, prefix + "1");
    //    }
    //}
}
