using System;

/* * EXCEEDING REQUIREMENTS:
 * 1. Logic for HideRandomWords was enhanced to only select from words that are 
 * not already hidden, ensuring the program progresses efficiently.
 * 2. Added a check to make sure the program hides exactly the requested number 
 * of words unless fewer remain.*/
 
namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            Scripture scripture = new Scripture(reference, text);

            string userInput = "";

            while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress enter to hide words or type 'quit' to finish:");
                
                userInput = Console.ReadLine();

                if (userInput.ToLower() != "quit")
                {
                    scripture.HideRandomWords(3);
                }
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Good job!");
        }
    }
}