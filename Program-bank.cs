using System;
using System.Globalization;

namespace BankPercent
{
    public static class Solution
    {
        public static double Calculate(string userInput)
        {
            var inputParts = userInput.Split(' ');

            var initialAmount = double.Parse(inputParts[0]);
            var annualInterestRate = double.Parse(inputParts[1]);
            var months = int.Parse(inputParts[2]);

            var monthlyInterestRate = annualInterestRate / 1200;

            return initialAmount * Math.Pow(1 + monthlyInterestRate, months);
        }

        //var pieces = userInput.Split(' ');
        //return double.Parse(pieces[0]) * Math.Pow(double.Parse(pieces[1]) / 1200 + 1, int.Parse(pieces[2]));
        // Math.Pow() - Возведение месячной процентной ставки в степень равную количеству месяцев


        //public static double Calculate(string userInput)
        //{
        //    var pieces = userInput.Split(' ');
        //    var sum = double.Parse(pieces[0], CultureInfo.InvariantCulture);
        //    var percentMonth = double.Parse(pieces[1], CultureInfo.InvariantCulture) / 1200;
        //    var months = int.Parse(pieces[2]);
        //    return sum * Math.Pow(percentMonth + 1, months);
        //    // Math.Pow() - Возведение месячной процентной ставки в степень равную количеству месяцев 
        //}


        //public static double Calculate(string userInput)
        //{
        //    string[] pieces = userInput.Split(' ');
        //    var sum = double.Parse(pieces[0], CultureInfo.InvariantCulture);
        //    var percentYear = double.Parse(pieces[1], CultureInfo.InvariantCulture);
        //    var months = int.Parse(pieces[2]);

        //    var percentMonth = percentYear / 100 / 12;

        //    var finalSum = sum * Math.Pow(percentMonth + 1, months);
        //    // Math.Pow() - Возведение месячной процентной ставки в степень равную количеству месяцев 

        //    return Math.Round(finalSum);
        //}

        public static void Main()
        {
            string info = Console.ReadLine();
            Console.WriteLine(Calculate(info));
        }
    }
}