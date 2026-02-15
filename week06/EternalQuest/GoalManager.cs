using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string input = "";
        while (input != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        string title = level switch {
            1 => "Novice",
            2 => "Warrior",
            3 => "Paladin",
            _ => "Eternal Hero"
        };
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n==================================================");
        Console.WriteLine($" >>> SCORE: {_score} | LEVEL: {level} ({title}) <<<");
        Console.WriteLine($"==================================================");
        Console.ResetColor();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int pts = int.Parse(Console.ReadLine());

        if (type == "1") _goals.Add(new SimpleGoal(name, desc, pts));
        else if (type == "2") _goals.Add(new EternalGoal(name, desc, pts));
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        if (_goals.Count == 0) return;

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count) return;

        Goal goal = _goals[index];

        if (goal.IsComplete())
        {
            Console.WriteLine("This goal is already finished!");
            return;
        }

        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n⭐ Congratulations! You earned {pointsEarned} points! ⭐");
        Console.ResetColor();
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal") 
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            else if (type == "EternalGoal") 
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            else if (type == "ChecklistGoal") 
                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
        }
    }
}