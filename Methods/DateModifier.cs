using System;

public class DateModifier
{
    public TimeSpan timespan;
    public DateTime firstDate;
    public DateTime secondDate;

    public DateModifier(int year1, int month1, int day1, int year2, int month2, int day2)
    {
        this.firstDate = new DateTime(year1, month1, day1);
        this.secondDate= new DateTime(year2, month2, day2);
    }

    public static TimeSpan CalculateTimeSpan(DateTime firstDate, DateTime secoDate)
    {
        TimeSpan timeSpan = new TimeSpan();
        timeSpan = secoDate.Subtract(firstDate);
        return timeSpan;
    }
}
class Program
{
    static void Main(string[] args)
    {
        string[] dateInfoSplit1 = Console.ReadLine().Split();
        string[] dateInfoSplit2 = Console.ReadLine().Split();

        int year1 = int.Parse(dateInfoSplit1[0]);
        int month1 = int.Parse(dateInfoSplit1[1].TrimStart('0'));
        int day1 = int.Parse(dateInfoSplit1[2].TrimStart('0'));

        int year2 = int.Parse(dateInfoSplit2[0]);
        int month2 = int.Parse(dateInfoSplit2[1].TrimStart('0'));
        int day2 = int.Parse(dateInfoSplit2[2].TrimStart('0'));

        DateModifier date = new DateModifier(year1, month1, day1, year2, month2, day2);
        TimeSpan result = DateModifier.CalculateTimeSpan(date.firstDate, date.secondDate);
        Console.WriteLine(Math.Abs(result.Days));
    }
}
