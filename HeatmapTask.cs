namespace Names;

internal static class HeatmapTask
{
    public static string[] DaysList()
    {
        var days = new string[30];
        for (int i = 0; i < days.Length; i++)
            days[i] = (i + 2).ToString();
        return days;
    }
    
    public static string[] MonthsList()
    {
        var months = new string[12];
        for (int i = 0; i < months.Length; i++)
            months[i] = (i + 1).ToString();
        return months;
    }

    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var heatmap = new double[30, 12];

        foreach (var person in names)
        {
            var birthday = person.BirthDate.Day;
            var monthOfBirth = person.BirthDate.Month;
            if (birthday > 1 && birthday <= 31 && monthOfBirth >= 1 && monthOfBirth <= 12)
                heatmap[birthday - 2, monthOfBirth - 1]++;
        }

        return new HeatmapData(
            "Пример карты интенсивностей",
            heatmap,
            DaysList(),
            MonthsList());
    }
}