namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var days = new string[31];
        for (int i = 0; i < days.Length; i++)
            days[i] = (i + 1).ToString();

        var birthsInDay = new double[31];

        foreach (var person in names)
        {
            if (person.Name == name && person.BirthDate.Day != 1)
            {
                var birthday = person.BirthDate.Day;
                if (birthday > 1 && birthday <= 31)
                    birthsInDay[birthday - 1]++;
            }
        }

        return new HistogramData(
            $"Рождаемость людей с именем '{name}'", 
            days, 
            birthsInDay);
    }
}