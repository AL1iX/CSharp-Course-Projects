namespace Mazes;

public static class EmptyMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        DirectionMove(robot, Direction.Right, width - 2 - robot.X);
        DirectionMove(robot, Direction.Down, height - 2 - robot.Y);
    }

    public static void DirectionMove(Robot robot, Direction direction, int dist)
    {
        for (var i = 0; i < dist; i++)
            robot.MoveTo(direction);
    }
}
