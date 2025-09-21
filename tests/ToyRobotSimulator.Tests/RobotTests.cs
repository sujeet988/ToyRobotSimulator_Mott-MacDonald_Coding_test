using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Implementation;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class RobotTests
    {
        private Table table;
        private Robot robot;

        [TestInitialize]
        public void Setup()
        {
            table = new Table(5, 5);
            robot = new Robot();
        }

        [TestMethod]
        public void Place_ValidPosition_ShouldPlaceRobot()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            Assert.IsTrue(robot.IsPlaced);
            Assert.AreEqual("0,0,North", robot.Report());
        }

        [TestMethod]
        public void Move_ValidMove_ShouldUpdatePosition()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            robot.Move();
            Assert.AreEqual("0,1,North", robot.Report());
        }

        [TestMethod]
        public void Move_InvalidMove_ShouldIgnore()
        {
            robot.Place(new Position(0, 4, Direction.North), table);
            robot.Move();
            Assert.AreEqual("0,4,N", robot.Report());
        }

        [TestMethod]
        public void Left_ShouldRotateLeft()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            robot.Left();
            Assert.AreEqual("0,0,West", robot.Report());
        }

        [TestMethod]
        public void Right_ShouldRotateRight()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            robot.Right();
            Assert.AreEqual("0,0,East", robot.Report());
        }

    }
}
