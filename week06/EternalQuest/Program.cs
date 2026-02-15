using System;
// Creativity and exceeding requirements:
// Level System: The user levels up every 1000 points and dynamic titles, the user receives a title according to their level (example, "Level 2: Warrior").
// Simple visual effects were added when earning points.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}