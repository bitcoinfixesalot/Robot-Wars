using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Tests
{
    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        public void IsValidArenaCommandTest()
        {
            CommandsParser commandParser = new CommandsParser();
            Arena arena;
            bool result = commandParser.IsValidArenaCommand("5 5", out arena);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidCreateRobotCommandTest()
        {
            CommandsParser commandParser = new CommandsParser();
            Robot robot;
            bool result = commandParser.IsValidCreateRobotCommand("1 2 N", out robot);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ParseRobotMoves()
        {
            CommandsParser commandParser = new CommandsParser();
            var result = commandParser.ParseRobotMoves("LMLMLMLMM");
            Assert.IsTrue(result.Count > 0);
        }
    }
}
