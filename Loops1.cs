namespace HelloWorld;

internal static class Program
{
    public static void Main()
    {
        Console.Write("Введите целое неотрицательное число: ");
        var num = int.Parse(Console.ReadLine());

        var reversedNum = NumReverse(num);

        Console.WriteLine($"Перевернутое число: {reversedNum}");
    }

    public static int NumReverse(int num)
    {
        var sol = 0;

        while (num > 0)
        {
            var lastDigit = num % 10;
            num /= 10;
            sol = sol * 10 + lastDigit;
        }
        return sol;
    }
}