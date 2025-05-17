public class PromptGenerator{
    public string RandomPrompt()
    {
        string[] prompts ={
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I eat today?",
        "What made me laugh the hardest?",
        "What is something you learned today?",
        "Who did you help or serve today?",
        "What was one moment you felt peace or joy?",
        "What goal did you make progress on today?",
        "What would you tell your future self about today?"
            };

        Random rand = new Random();
        int index = rand.Next(prompts.Length); // It generates a random number and stores it in index and rand next returns 0-6 if there are 7
        string selectedPrompt = prompts[index];
        Console.WriteLine(selectedPrompt);
        return selectedPrompt;
    }
}