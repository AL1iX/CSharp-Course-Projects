namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
	{
		HorizontalMove(robot, Direction.Right, width);
		VerticalMove(robot, Direction.Down, height);
	}

	public static void HorizontalMove(Robot robot, Direction direction, int width)
	{
		var horizontalDist = width - 2 - robot.X;
		for (int i = 0; i < horizontalDist; i++)
			robot.MoveTo(direction);
	}
	 
	public static void VerticalMove(Robot robot, Direction direction, int height)
	{
		var verticalDist = height - 2 - robot.Y;
		for (int i = 0; i < verticalDist; i++) 
			robot.MoveTo(direction);
	}
}