using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Infrastructure
{
    public class MovesProvider
    {
        public void MoveRobotToPosition(Arena arena, Robot robot, List<Move> moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case Move.RotateLeft:
                    case Move.RoteteRight:
                        Rotate(robot, move);
                        break;
                    case Move.MoveForward:
                        StartMoving(robot, arena);
                        break;
                    default:
                        break;
                }
            }
        }

        private void StartMoving(Robot robot, Arena arena)
        {
            switch (robot.Compas)
            {
                case CompasPoints.North:
                    if (robot.PositionY < arena.Hight)
                        robot.PositionY++;
                    break;
                case CompasPoints.East:
                    if (robot.PositionX < arena.Width)
                        robot.PositionX++;
                    break;
                case CompasPoints.South:
                    if (robot.PositionY > 0)
                        robot.PositionY--;
                    break;
                case CompasPoints.West:
                    if (robot.PositionX > 0)
                        robot.PositionX--;
                    break;
            }
        }

        public void Rotate(Robot robot, Move move)
        {
            if (move == Move.RoteteRight)
            {
                robot.Compas = robot.Compas == CompasPoints.West ? CompasPoints.North : (CompasPoints)(((int)robot.Compas) << 1);
            }
            else
            {
                robot.Compas = robot.Compas == CompasPoints.North ? CompasPoints.West : (CompasPoints)(((int)robot.Compas) >> 1);
            }
        }
    }
}
