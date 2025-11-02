namespace TextAnalysis;

internal static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        if (text == null || text.Count == 0)
            return new Dictionary<string, string>();
        var (bigramFreq, trigramFreq) = CollectAllFrequencies(text);
        var result = BuildResultDictionary(bigramFreq, trigramFreq);
        return result;
    }

    public static (
        Dictionary<string, Dictionary<string, int>> bigramFreq,
        Dictionary<string, Dictionary<string, int>> trigramFreq
        ) CollectAllFrequencies(List<List<string>> text)
    {
        var bigramFreq = new Dictionary<string, Dictionary<string, int>>();
        var trigramFreq = new Dictionary<string, Dictionary<string, int>>();
        foreach (var sent in text)
        {
            CollectBigramFreqFromSentence(sent, bigramFreq);
            CollectTrigramFreqFromSentence(sent, trigramFreq);
        }
        return (bigramFreq, trigramFreq);
    }

    public static void CollectBigramFreqFromSentence(
        List<string> sentence,
        Dictionary<string, Dictionary<string, int>> bigramFreq)
    {
        if (sentence.Count < 2) return;
        for (var i = 0; i < sentence.Count - 1; i++)
        {
            var current = sentence[i];
            var next = sentence[i + 1];
            AddFreq(bigramFreq, current, next);
        }
    }

    public static void CollectTrigramFreqFromSentence(
        List<string> sentence,
        Dictionary<string, Dictionary<string, int>> trigramFreq)
    {
        if (sentence.Count < 3) return;
        for (var i = 0; i < sentence.Count - 2; i++)
        {
            var current = $"{sentence[i]} {sentence[i + 1]}";
            var next = sentence[i + 2];
            AddFreq(trigramFreq, current, next);
        }
    }

    public static void AddFreq(Dictionary<string, Dictionary<string, int>> freq,
        string current, string next)
    {
        if (!freq.ContainsKey(current))
            freq[current] = new Dictionary<string, int>();
        if (!freq[current].ContainsKey(next))
            freq[current][next] = 0;
        freq[current][next]++;
    }

    public static Dictionary<string, string> BuildResultDictionary(
        Dictionary<string, Dictionary<string, int>> bigramFreq,
        Dictionary<string, Dictionary<string, int>> trigramFreq)
    {
        var result = new Dictionary<string, string>();
        AddMostFreqWordsToResult(bigramFreq, result);
        AddMostFreqWordsToResult(trigramFreq, result);
        return result;
    }

    public static void AddMostFreqWordsToResult(
        Dictionary<string, Dictionary<string, int>> freq,
        Dictionary<string, string> result)
    {
        foreach (var pair in freq)
        {
            var mostFreqNext = GetMostFreqNextWord(pair.Value);
            result[pair.Key] = mostFreqNext;
        }
    }

    public static string GetMostFreqNextWord(Dictionary<string, int> nextWords)
    {
        string bestCandidate = "";
        var maxFreq = -1;
        foreach (var pair in nextWords)
        {
            if (BetterCandidate(pair.Key, pair.Value, bestCandidate, maxFreq))
            {
                bestCandidate = pair.Key;
                maxFreq = pair.Value;
            }
        }
        return bestCandidate;
    }

    public static bool BetterCandidate(string candidate, int candidFreq, string currentBest, int currentMaxFreq)
    {
        if (candidFreq > currentMaxFreq)
            return true;
        if (candidFreq == currentMaxFreq && currentBest != null)
            return string.CompareOrdinal(candidate, currentBest) < 0;
        return false;
    }
}