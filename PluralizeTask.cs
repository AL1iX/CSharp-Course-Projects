namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
        int lastDigit = count % 10;
        bool between11And20 = (count % 100 >= 11 && count % 100 < 20);

        if (between11And20 || lastDigit == 0 || lastDigit >= 5)
            return "рублей";
        else if (lastDigit >= 2 && lastDigit <= 4)
            return "рубля";
        else
            return "рубль";
    }
}