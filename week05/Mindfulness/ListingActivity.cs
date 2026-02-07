public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("List as many items as you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userItems = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            userItems.Add(Console.ReadLine());
        }

        _count = userItems.Count;
        Console.WriteLine($"You listed {_count} items!");
        
        DisplayEndingMessage();
    }

    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
}