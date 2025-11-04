using System.Text;

namespace TextAnalysis;

internal static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();
        if (string.IsNullOrEmpty(text))
            return sentencesList;
        var sentSep = new[] { '.', '!', '?', ';', ':', '(', ')' };
        var sentences = text.Split(sentSep, StringSplitOptions.RemoveEmptyEntries);
        foreach (var sent in sentences)
        {
            var words = new List<string>();
            var curWord = new StringBuilder();

            foreach (char l in sent)
            {
                if (char.IsLetter(l) || l == '\'')
                    curWord.Append(char.ToLower(l));
                else if (curWord.Length > 0)
                { words.Add(curWord.ToString()); curWord.Clear(); }
            }
            if (curWord.Length > 0)
                words.Add(curWord.ToString());
            if (words.Count > 0)
                sentencesList.Add(words);
        }
        return sentencesList;
    }
}