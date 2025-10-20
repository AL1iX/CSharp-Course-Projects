using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        var x = 1.0;
        var y = 0.0;
        var gen = new Random(seed);
        var angle1 = Math.PI * 45 / 180;
        var angle2 = Math.PI * 135 / 180;

        for (int i = 0; i < iterationsCount; i++)
        {
            double x1, y1;
            var format = gen.Next(2);

            if (format == 0)
            {
                (x1, y1) = FirstAngleCalculation(angle1, x, y);
            }
            else
            {
                (x1, y1) = SecondAngleCalculation(angle2, x, y);
            }
            x = x1;
            y = y1;
            pixels.SetPixel(x, y);
        }
    }

    public static (double x1, double y1) FirstAngleCalculation(double angle, double x, double y)
    {
        return (((x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2)),
            ((x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2)));
    }

    public static (double x1, double y1) SecondAngleCalculation(double angle, double x, double y)
    {
        return (((x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2) + 1),
        ((x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2)));
    }
}