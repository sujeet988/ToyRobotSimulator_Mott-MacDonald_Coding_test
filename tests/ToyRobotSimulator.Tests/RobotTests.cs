using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Implementation;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Tests
{// Unit tests for the Robot class behavior
    [TestClass]
    public class RobotTests
    {
        private Table table;
        private Robot robot;

        /// <summary>
        /// Runs before each test. 
        /// Initializes a fresh 5x5 table and a new robot instance.
        /// Ensures tests are isolated and independent.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            table = new Table(5, 5);
            robot = new Robot();
        }

        /// <summary>
        /// Test: Placing the robot on a valid position (0,0,North) should succeed.
        /// Expected: Robot is placed and reports correct position.
        /// </summary>
        [TestMethod]
        public void Place_ValidPosition_ShouldPlaceRobot()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            Assert.IsTrue(robot.IsPlaced);
            Assert.AreEqual("0,0,North", robot.Report());
        }

        /// <summary>
        /// Test: Moving forward from (0,0,North) should move robot to (0,1,North).
        /// Expected: Y increases by 1.
        /// </summary>
        [TestMethod]
        public void Move_ValidMove_ShouldUpdatePosition()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            robot.Move();
            Assert.AreEqual("0,1,North", robot.Report());
        }

        /// <summary>
        /// Test: Moving forward from (0,4,North) should be ignored 
        /// because robot would fall off the table.
        /// Expected: Position stays (0,4,North).
        /// </summary>
        [TestMethod]
        public void Move_InvalidMove_ShouldIgnore()
        {
            robot.Place(new Position(0, 4, Direction.North), table);
            robot.Move();
            Assert.AreEqual("0,4,North", robot.Report());
        }

        /// <summary>
        /// Test: Rotating left from North should change facing direction to West.
        /// Expected: (0,0,WEST).
        /// </summary>
        [TestMethod]
        public void Left_ShouldRotateLeft()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            robot.Left();
            Assert.AreEqual("0,0,West", robot.Report());
        }

        /// <summary>
        /// Test: Rotating right from North should change facing direction to East.
        /// Expected: (0,0,East).
        /// </summary>
        [TestMethod]
        public void Right_ShouldRotateRight()
        {
            robot.Place(new Position(0, 0, Direction.North), table);
            robot.Right();
            Assert.AreEqual("0,0,East", robot.Report());
        }
    }

}
