using System;
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main(string[] args)
    {
        // Creativity Note:
        // To show creativity I made it so there is a menu section and you can pick the scripture you want 
        bool keepGoing = true;

        while (keepGoing)
        {
            Console.Clear();
            Console.WriteLine("1. Helaman 5:12-13");
            Console.WriteLine("2. Alma 7:10");
            Console.WriteLine("3. John 3:17");
            Console.Write("Which scripture do you want to memorize? ");
            string choice = Console.ReadLine();

            Scripture selectedScripture;

            if (choice == "1")
            {
                selectedScripture = new Scripture("Helaman 5:12-13", new List<string>()
                {
                    "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation⁠; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.",
                    "And it came to pass that these were the words which Helaman taught to his sons; yea, he did teach them many things which are not written, and also many things which are written."
                });
            }
            else if (choice == "2")
            {
                selectedScripture = new Scripture("Alma 7:10", new List<string>()
                {
                    "And behold, he shall be born of Mary, at Jerusalem which is the land of our forefathers, she being a virgin⁠, a precious and chosen vessel, who shall be overshadowed and conceive by the power of the Holy Ghost, and bring forth a son, yea, even the Son of God."
                });
            }
            else if (choice == "3")
            {
                selectedScripture = new Scripture("John 3:17", new List<string>()
                {
                    "For God sent not his Son into the world to condemn the world; but that the world through him might be saved⁠."
                });        
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again...");
                Console.ReadLine();
                continue;
            }

            // Memorization loop
            string response = "";
            while (response != "quit")
            {
                Console.Clear();
                selectedScripture.DisplayReference();
                foreach (var verse in selectedScripture.GetVerses()) // This gets the verse from Scripture class
                {
                    verse.Display();
                    Console.WriteLine();
                }

                if (!selectedScripture.HideWordInVerses()) // This calls the method to hide the words in the scripture class
                {
                    Console.WriteLine("\n Congrats! All words are Memorized!");
                    break;
                }

                Console.WriteLine("\nPress Enter to continue or type 'quit' to stop.");
                response = Console.ReadLine()?.ToLower();
            }

            Console.Write("\nDo you want to memorize another scripture? (yes/no): ");
            string again = Console.ReadLine()?.ToLower();
            if (again != "yes")
            {
                keepGoing = false;
            }
        }

        Console.WriteLine("\nThanks for using Scripture Memorizer!");
    }
}
