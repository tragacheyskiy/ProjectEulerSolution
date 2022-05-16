namespace ProjectEulerSolution.Problems._1_100._11_20;

// https://projecteuler.net/problem=17
// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
// NOTE: Do not count spaces or hyphens.
// For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
// The use of "and" when writing out numbers is in compliance with British usage.
internal sealed class Problem17 : IProblem
{
    public void Solve()
    {
        int totalCount = 0;

        for (int i = 1; i <= 1000; i++)
        {
            totalCount += GetNumberText(i).Length;
        }

        Console.WriteLine($"Total letters count = {totalCount}");
    }

    private string GetNumberText(int number)
    {
        if (number < 10)
            return GetDigitText(number);

        if (number < 20)
            return GetTwoDigitTextBefore20(number);

        if (number < 100)
            return GetTwoDigitText(number);

        if (number < 1000)
            return GetThreeDigitText(number);

        if (number == 1000)
            return "OneThousand";

        return string.Empty;
    }

    private string GetThreeDigitText(int number)
    {
        int firstDigit = (number / 100) % 100;
        int lastDigits = number % 100;

        string result = GetDigitText(firstDigit) + "Hundred";

        if (lastDigits == 0)
            return result;

        result += "And";

        if (lastDigits < 10)
        {
            return result + GetDigitText(lastDigits);
        }

        if (lastDigits < 20)
        {
            return result + GetTwoDigitTextBefore20(lastDigits);
        }

        return result + GetTwoDigitText(lastDigits);
    }

    private string GetTwoDigitText(int number)
    {
        int firstDigit = (number / 10) % 10;
        int secondDigit = number % 10;

        string result = GetDigitMultiple10Text(firstDigit)
            + (secondDigit == 0 ? string.Empty : GetDigitText(secondDigit));

        return result;
    }

    private string GetTwoDigitTextBefore20(int number) => number switch
    {
        10 => "Ten",
        11 => "Eleven",
        12 => "Twelve",
        13 => "Thirteen",
        14 => "Fourteen",
        15 => "Fifteen",
        16 => "Sixteen",
        17 => "Seventeen",
        18 => "Eighteen",
        19 => "Nineteen",
        _ => string.Empty
    };

    private string GetDigitMultiple10Text(int digit) => digit switch
    {
        2 => "Twenty",
        3 => "Thirty",
        4 => "Forty",
        5 => "Fifty",
        6 => "Sixty",
        7 => "Seventy",
        8 => "Eighty",
        9 => "Ninety",
        _ => string.Empty
    };

    private string GetDigitText(int digit) => digit switch
    {
        0 => "Zero",
        1 => "One",
        2 => "Two",
        3 => "Three",
        4 => "Four",
        5 => "Five",
        6 => "Six",
        7 => "Seven",
        8 => "Eight",
        9 => "Nine",
        _ => string.Empty
    };
}

