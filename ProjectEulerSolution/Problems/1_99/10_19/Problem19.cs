namespace ProjectEulerSolution.Problems._1_99._10_19;

// https://projecteuler.net/problem=19
// You are given the following information, but you may prefer to do some research for yourself.
// 1 Jan 1900 was a Monday.
// Thirty days has September, April, June and November.
// All the rest have thirty-one,
// Saving February alone,
// Which has twenty-eight, rain or shine.
// And on leap years, twenty-nine.
// A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
internal sealed class Problem19 : IProblem
{
    private const int OriginYear = 1900;
    private const int YearFrom = 1901;
    private const int YearTo = 2000;

    public void Solve()
    {
        int result = GetSundaysCount(YearFrom, YearTo);

        Console.WriteLine($"Sundays fell on the first of the month during ({YearFrom} to {YearTo}): {result}");
    }

    private int GetSundaysCount(int yearFrom, int yearTo)
    {
        if (yearTo <= yearFrom || yearFrom <= OriginYear)
            return -1;

        int result = 0;
        int origin = 366;

        for (int year = OriginYear; year < yearFrom - 1; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                origin += GetDaysCount(month, IsLeapYear(year));
            }
        }

        if (origin % 7 == 0)
        {
            result++;
        }

        for (int year = yearFrom; year <= yearTo; year++)
        {
            for (int month = 1; month <= 12; month++)
            {
                origin += GetDaysCount(month, IsLeapYear(year));

                if (origin % 7 == 0)
                {
                    result++;
                }
            }
        }

        return result;
    }

    private int GetDaysCount(int month, bool isLeapYear)
    {
        if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return 30;
        }

        if (month == 2)
        {
            return isLeapYear ? 29 : 28;
        }

        return 31;
    }

    private bool IsLeapYear(int year)
    {
        if (year % 100 == 0)
        {
            return year / 400 == 0;
        }

        return year / 4 == 0;
    }
}
