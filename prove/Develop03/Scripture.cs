
public class Scripture
{
    private string _reference;
    private List<Verse> _verses;

    public Scripture(string reference, List<string> verses)
    {
        _reference = reference;
        _verses = new List<Verse>();
        foreach (string verse in verses)
        {
            _verses.Add(new Verse(verse));
        }
    }
    public bool HideWordInVerses()
    {

        var versesWithVisibleWords = _verses.Where(v => !v.CheckVisibility()).ToList();
        if (versesWithVisibleWords.Count == 0)
        {
            return false; // All are fully hidden
        }

        Random random = new Random();
        int index = random.Next(0, versesWithVisibleWords.Count);
        versesWithVisibleWords[index].HideWord();
        return true;

    }
    public List<Verse> GetVerses()
    {
        return _verses;
    }
    public void DisplayReference()
    {
        Console.WriteLine(_reference);
    }
}
