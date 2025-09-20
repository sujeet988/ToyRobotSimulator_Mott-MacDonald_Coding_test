using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Services.Implementation;
using ToyRobotSimulator.Services.Services;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Example_A()
        {
            var table = new Table();
            var robot = new Robot(table);
            var outputs = new List<string>();
            var parser = new CommandParser(robot, s => outputs.Add(s));

            var commands = new[] { "PLACE 0,0,NORTH", "MOVE", "REPORT" };
            foreach (var c in commands)
            {
                parser.Parse(c)?.Execute();
            }

            Assert.AreEqual("0,1,NORTH", outputs.Single());
        }

        [TestMethod]
        public void Example_B()
        {
            var table = new Table();
            var robot = new Robot(table);
            var outputs = new List<string>();
            var parser = new CommandParser(robot, s => outputs.Add(s));

            var commands = new[] { "PLACE 0,0,NORTH", "LEFT", "REPORT" };
            foreach (var c in commands) parser.Parse(c)?.Execute();

            Assert.AreEqual("0,0,WEST", outputs.Single());
        }

        [TestMethod]
        public void Example_C()
        {
            var table = new Table();
            var robot = new Robot(table);
            var outputs = new List<string>();
            var parser = new CommandParser(robot, s => outputs.Add(s));

            var commands = new[] { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };
            foreach (var c in commands) parser.Parse(c)?.Execute();

            Assert.AreEqual("3,3,NORTH", outputs.Single());
        }
    }

}
