using System;
// Swowing creativity and exceding requirements: 1. A system for controlling random prompts was implemented in ReflectingActivity and ListingActivity
// to ensure that questions are not repeated until all have been used in the session.
// 2. The animations in BreathingActivity were improved to provide a smoother and more consistent visual guide to the suggested breathing rhythm.
class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity ba = new BreathingActivity();
                ba.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity ra = new ReflectingActivity();
                ra.Run();
            }
            else if (choice == "3")
            {
                ListingActivity la = new ListingActivity();
                la.Run();
            }
        }
    }
}