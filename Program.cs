using System;

public class NumberToWordsConverter
{
    private static readonly string[] UnitsMap =
    {
        "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
        "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    };
    private static readonly string[] TensMap =
    {
        "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    };

    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "Minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            if (number < 20)
                words += UnitsMap[number];
            else
            {
                words += TensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + UnitsMap[number % 10];
            }
        }

        return words;
    }
}

public class Program
{
    public static void Main()
    {
        // Ejemplos de uso:
        Console.WriteLine(NumberToWordsConverter.NumberToWords(12)); // "Twelve"
        Console.WriteLine(NumberToWordsConverter.NumberToWords(45)); // "Forty-Five"
        Console.WriteLine(NumberToWordsConverter.NumberToWords(634)); // "Six Hundred and Thirty-Four"
        Console.WriteLine(NumberToWordsConverter.NumberToWords(-1987)); // "Minus One Thousand Nine Hundred and Eighty-Seven"
    }
}

