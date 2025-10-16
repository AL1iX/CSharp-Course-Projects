using System;

namespace DistanceTask;

public static class DistanceTask
{
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by,
    double x, double y)
    {
        if (IsDegenerateSegment(ax, ay, bx, by))
            return CalculateDistance(ax, ay, x, y);

        var (ABx, ABy) = (bx - ax, by - ay);
        var (APx, APy) = (x - ax, y - ay);
        var (BPx, BPy) = (x - bx, y - by);

        if (IsProjectionBeforeA(ABx, ABy, APx, APy))
            return CalculateDistance(0, 0, APx, APy);

        if (IsProjectionAfterB(ABx, ABy, BPx, BPy))
            return CalculateDistance(0, 0, BPx, BPy);

        return CalculateDistanceToLine(ABx, ABy, APx, APy);
    }

    private static bool IsDegenerateSegment(double ax, double ay, double bx, double by)
    {
        return ax == bx && ay == by;
    }

    private static bool IsProjectionBeforeA(double ABx, double ABy, double APx, double APy)
    {
        return ABx * APx + ABy * APy <= 0;
    }

    private static bool IsProjectionAfterB(double ABx, double ABy, double BPx, double BPy)
    {
        return (-ABx) * BPx + (-ABy) * BPy <= 0;
    }

    private static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }

    private static double CalculateDistanceToLine(double ABx, double ABy, double APx, double APy)
    {
        return Math.Abs(ABx * APy - ABy * APx) / CalculateDistance(0, 0, ABx, ABy);
    }
}