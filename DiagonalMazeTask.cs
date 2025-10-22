namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            var pathHorizontal = width - 2;
            var pathVertical = height - 2;
            if (pathHorizontal > pathVertical)
                MoveMoreHorizontal(robot, pathHorizontal, pathVertical);
            else
                MoveMoreVertical(robot, pathHorizontal, pathVertical);
        }

        public static void MoveMoreHorizontal(Robot robot, int width, int height)
        {
            var rightStepsPerSegment = width / height;
            var downStepsPerSegment = 1;
            for (int segment = 0; segment < height; segment++)
            {
                MoveRight(robot, rightStepsPerSegment);
                if (segment < height - 1)
                    MoveDown(robot, downStepsPerSegment);
            }
        }

        public static void MoveMoreVertical(Robot robot, int width, int height)
        {
            var downStepsPerSegment = height / width;
            var rightStepsPerSegment = 1;
            for (int segment = 0; segment < width; segment++)
            {
                MoveDown(robot, downStepsPerSegment);
                if (segment < width - 1)
                    MoveRight(robot, rightStepsPerSegment);
            }
        }

        public static void MoveRight(Robot robot, int steps)
        {
            for (int i = 0; i < steps; i++)
                robot.MoveTo(Direction.Right);
        }

        public static void MoveDown(Robot robot, int steps)
        {
            for (int i = 0; i < steps; i++)
                robot.MoveTo(Direction.Down);
        }
    }
}