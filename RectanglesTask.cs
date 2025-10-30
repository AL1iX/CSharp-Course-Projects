using System;

namespace Rectangles;

public static class RectanglesTask
{
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        bool intersectX = r1.Left <= r2.Right && r2.Left <= r1.Right;
        bool intersectY = r1.Top <= r2.Bottom && r2.Top <= r1.Bottom;

        return intersectX && intersectY;
    }

    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (!AreIntersected(r1, r2))
            return 0;

        var left = Math.Max(r1.Left, r2.Left);
        var right = Math.Min(r1.Right, r2.Right);

        var top = Math.Max(r1.Top, r2.Top);
        var bottom = Math.Min(r1.Bottom, r2.Bottom);

        var width = right - left;
        var height = bottom - top;

        return width * height;
    }

    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        bool r1InR2 = r1.Left >= r2.Left &&
                      r1.Right <= r2.Right &&
                      r1.Top >= r2.Top &&
                      r1.Bottom <= r2.Bottom;

        bool r2InR1 = r2.Left >= r1.Left &&
                      r2.Right <= r1.Right &&
                      r2.Top >= r1.Top &&
                      r2.Bottom <= r1.Bottom;

        if (r1InR2)
            return 0;
        else if (r2InR1)
            return 1;
        else
            return -1;
    }
}