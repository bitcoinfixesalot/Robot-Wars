using RobotWars.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Infrastructure
{
    public class CommandsParser
    {
        const char ROTATE_LEFT = 'L';
        const char ROTETE_RIGHT = 'R';
        const char MOVE_FORWARD = 'M';
              
        const string NORTH = "N";
        const string SOUTH = "S";
        const string EAST = "E";
        const string WEST = "W";

        public bool IsValidArenaCommand(string commands, out Arena arena)
        {
            var command = commands.Split(' '); //not sure if I should put more validation or every time is 3 simbols separeted by empty char

            arena = new Arena();
            int cordinate;
            if (int.TryParse(command[0], out cordinate))
                arena.Width = cordinate;
            else
                return false;

            if (int.TryParse(command[1], out cordinate))
                arena.Hight = cordinate;
            else
                return false;

            return true;
        }

        public bool IsValidCreateRobotCommand(string commands, out Robot robot)
        {
            var command = commands.Split(' ');
            
            robot = new Robot();

            int cordinate;
            if (int.TryParse(command[0], out cordinate))
                robot.PositionX = cordinate;
            else
                return false;

            if (int.TryParse(command[1], out cordinate))
                robot.PositionY = cordinate;
            else
                return false;

            CompasPoints compas;
            if (!TryGetCompasPoints(command[2], out compas))
                return false;

            robot.Compas = compas;
            return true;
        }

        public List<Move> ParseRobotMoves(string commands)
        {
            List<Move> moves = new List<Move>();
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ROTATE_LEFT:
                        moves.Add(Move.RotateLeft);
                        break;
                    case ROTETE_RIGHT:
                        moves.Add(Move.RoteteRight);
                        break;
                    case MOVE_FORWARD:
                        moves.Add(Move.MoveForward);
                        break;
                    default:
                        break;
                }
            }
            return moves;
        }

        private bool TryGetCompasPoints(string command, out CompasPoints position)
        {
            switch (command.ToUpper())
            {
                case NORTH:
                    position = CompasPoints.North;
                    return true;
                case SOUTH:
                    position = CompasPoints.South;
                    return true;
                case WEST:
                    position = CompasPoints.West;
                    return true;
                case EAST:
                    position = CompasPoints.East;
                    return true;
                default:
                    position = CompasPoints.North;
                    return false;
            }
        }

    }
}
