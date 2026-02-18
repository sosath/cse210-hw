using System;
using System.Collections.Generic;
// Showing creativity and exceeding requirements:
// Implement a dynamic date format using DateTime, advanced use of polymorphism when calculating indirect values,
// and formatting strings with decimal precision (0.0) for professional reports.
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run = new Running("03 Nov 2022", 30, 4.8);
        Cycling bike = new Cycling("04 Nov 2022", 45, 20.0);
        Swimming swim = new Swimming("05 Nov 2022", 20, 40);

        activities.Add(run);
        activities.Add(bike);
        activities.Add(swim);

        Console.WriteLine("------------ Exercise Tracking Summary ------------\n");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine("\n---------------------------------------------------");
    }
}