
public class Verse
{
    private List<Word> _words = new(); //This creates the brackets like in python

    public Verse(string text)
    {
        // split the text of the verse into individual words also handles the 2 verses
        string[] parts = text.Split();
        //Create a list
        foreach (string part in parts)
        {
            _words.Add(new Word(part));

        }
    }

    public bool HideWord()
    {
        var visibleWords = _words.Where(w => w.GetVisibility()).ToList();
        if (visibleWords.Count == 0)
            return false; // Nothing to hide
        int wordsToHide = Math.Min(3, visibleWords.Count);
        Random random = new Random();

        for (int i = 0; i < wordsToHide; i++) // i ++ makes it to one makes it to two and so on
        {
            Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
            wordToHide.SetVisibleFalse();
            visibleWords.Remove(wordToHide); // Prevent duplicate hiding in same round
        }

        return true;
    }

    public bool CheckVisibility()
    {
        bool AllHidden = true;
        foreach (Word word in _words)
        {
            bool IsVisible = word.GetVisibility();
            if (IsVisible == true)
            {
                AllHidden = false;
                break;
            }

        }
        return AllHidden;
    }
    public void Display()
    {
        foreach (Word word in _words)
        {

            Console.Write($"{word.GetWord()} ");


        }
    }

}
// 