public class Word
{
    private string _text;
    private bool _visible;
    public Word(string text)
    {
        _text = text;
        _visible = true;

    }
    public string Hide()
    {
        string hideWord = new string('_', _text.Length);
        _text = hideWord;
        return hideWord;
    }
    public void SetVisibleFalse()
    {
        _visible = false;

    }
    public bool GetVisibility()
    {

        return _visible;
    }
    public string GetWord()
    {
        return _text;
    }
}