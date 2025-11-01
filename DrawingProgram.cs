using Avalonia.Media;
using RefactorMe.Common;
using System;

namespace RefactorMe
{
    internal class Drawer
    {
        private static float currentX;
        private static float currentY;
        private static IGraphics graphics;

        public static void Initialize(IGraphics graphics)
        {
            Drawer.graphics = graphics;
            Drawer.graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x, float y)
        {
            currentX = x;
            currentY = y;
        }

        public static void DrawLine(Pen pen, double length, double angle)
        {
            var targetX = (float)(currentX + length * Math.Cos(angle));
            var targetY = (float)(currentY + length * Math.Sin(angle));

            graphics.DrawLine(pen, currentX, currentY, targetX, targetY);

            currentX = targetX;
            currentY = targetY;
        }

        public static void MoveWithoutDrawing(double length, double angle)
        {
            currentX = (float)(currentX + length * Math.Cos(angle));
            currentY = (float)(currentY + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const double MainPartRatio = 0.375;
        private const double SmallPartRatio = 0.04;

        public static void Draw(int width, int height, double spinArea, IGraphics graphics)
        {
            Drawer.Initialize(graphics);

            var size = Math.Min(width, height);
            var mainLength = size * MainPartRatio;
            var smallLength = size * SmallPartRatio;
            var diagonalSmallLength = smallLength * Math.Sqrt(2);

            var startPoint = CalculateStartPoint(width, height, mainLength, smallLength);
            Drawer.SetPosition(startPoint.x, startPoint.y);

            var yellowPen = new Pen(Brushes.Yellow);

            DrawFourSides(yellowPen, mainLength, diagonalSmallLength, smallLength);
        }

        private static (float x, float y) CalculateStartPoint(
            int width, int height, double mainLength, double smallLength)
        {
            var diagonalLength = Math.Sqrt(2) * (mainLength + smallLength) / 2;
            var centerX = width / 2f;
            var centerY = height / 2f;

            var startX = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + centerX;
            var startY = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + centerY;

            return (startX, startY);
        }

        private static void DrawFourSides(
            Pen pen, double mainLength, double diagonalSmallLength, double smallLength)
        {
            DrawSide(pen, mainLength, diagonalSmallLength, smallLength, 0);
            DrawSide(pen, mainLength, diagonalSmallLength, smallLength, -Math.PI / 2);
            DrawSide(pen, mainLength, diagonalSmallLength, smallLength, Math.PI);
            DrawSide(pen, mainLength, diagonalSmallLength, smallLength, Math.PI / 2);
        }

        private static void DrawSide(
            Pen pen, double mainLength, double diagonalLength, double smallLength, double baseAngle)
        {
            Drawer.DrawLine(pen, mainLength, baseAngle);
            Drawer.DrawLine(pen, diagonalLength, baseAngle + Math.PI / 4);
            Drawer.DrawLine(pen, mainLength, baseAngle + Math.PI);
            Drawer.DrawLine(pen, mainLength - smallLength, baseAngle + Math.PI / 2);

            Drawer.MoveWithoutDrawing(smallLength, baseAngle - Math.PI);
            Drawer.MoveWithoutDrawing(diagonalLength, baseAngle + 3 * Math.PI / 4);
        }
    }
}