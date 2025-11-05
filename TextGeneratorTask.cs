namespace TextAnalysis;

static class TextGeneratorTask
{
    public static string ContinuePhrase(
        Dictionary<string, string> nextWords,
        string phraseBeginning,
        int wordsCount)
    {
        if (wordsCount <= 0 || nextWords == null || nextWords.Count == 0)
            return phraseBeginning;
        var words = phraseBeginning.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        for (var  i = 0; i < wordsCount; i++)
        {
            var nextWord = GetNextWord(nextWords, words);
            if (string.IsNullOrEmpty(nextWord))
                break;
            phraseBeginning += " " + nextWord;
            words.Add(nextWord);
        }
        return phraseBeginning;
    }

    public static string GetNextWord(Dictionary<string, string> nextW, List<string> words)
    {
        if (words.Count == 0)
            return null;
        if (words.Count >= 2)
        {
            var last2Words = $"{words[words.Count - 2]} {words[words.Count - 1]}";
            if (nextW.ContainsKey(last2Words))
                return nextW[last2Words];
        }
        var lastWord = words[words.Count - 1];
        if (nextW.ContainsKey(lastWord))
            return nextW[lastWord];
        return null;
    }
}