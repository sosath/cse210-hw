public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectingActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
    private string GetRandomQuestion() => _questions[new Random().Next(_questions.Count)];
}