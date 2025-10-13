namespace HelloWorld;

internal static class Program
{
    public static void Main()
    {
        Console.Write("Введите N (1 <= N <= 27): ");
        var n = int.Parse(Console.ReadLine());
        var count = 0;
        for (int num = 100; num < 1000; num++)
        {
            var stringNum = num.ToString();
            int sumDigits = 0;
            for (int i = 0; i < stringNum.Length; i++)
            {
                sumDigits += int.Parse(stringNum[i].ToString());
            }
            if (sumDigits == n)
                count += 1;
        }
        Console.WriteLine(count);
    }
}