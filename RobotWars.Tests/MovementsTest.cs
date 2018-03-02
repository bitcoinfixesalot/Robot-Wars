using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Infrastructure;

namespace RobotWars.Tests
{
    [TestClass]
    public class MovementsTest
    {
        [TestMethod]
        public void MoveRobotToPosition()
        {
            CommandsParser commandParser = new CommandsParser();
            Arena arena;
            bool result = commandParser.IsValidArenaCommand("5 5", out arena);
            Assert.IsTrue(result);
            Robot robot;
            result = commandParser.IsValidCreateRobotCommand("1 2 N", out robot);
            Assert.IsTrue(result);
            var moves = commandParser.ParseRobotMoves("LMLMLMLMM");
            Assert.IsTrue(moves.Count > 0);

            MovesProvider provider = new MovesProvider();
            provider.MoveRobotToPosition(arena, robot, moves);

            Assert.AreEqual<int>(1, robot.PositionX);

            Assert.AreEqual<int>(3, robot.PositionY);

            Assert.AreEqual<CompasPoints>(CompasPoints.North, robot.Compas);
        }
    }
}
