class Program
{
    static int[] massesOfBullions = { 49, 90, 34, 96, 12, 65, 34 };
    static int bagCapacity = 200;
    static int bestWeigth = 0;

    static void Main(string[] args)
    {
        GenerateSequence(massesOfBullions.Length);
        Console.WriteLine(bestWeigth);
    }

    static void GenerateSequence(int n, string prefix = "")
    {
        if (n == 0)
        {
            Process(prefix);
        }
        else
        {
            GenerateSequence(n - 1, prefix + "0");
            GenerateSequence(n - 1, prefix + "1");
        }
    }

    static void Process(string prefix)
    {
        int tempMass = 0;

        for (int i = 0; i < prefix.Length; i++)
        {
            if (prefix[i] == '1')
            {
                tempMass += massesOfBullions[i];
            }
        }

        if (tempMass > bestWeigth && tempMass <= bagCapacity)
        {
            bestWeigth = tempMass;
        }
    }
}
