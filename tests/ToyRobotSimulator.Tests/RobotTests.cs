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
        /// Test: Placing the robot on a valid position (0,0,NORTH) should succeed.
        /// Expected: Robot is placed and reports correct position.
        /// </summary>
        [TestMethod]
        public void Place_ValidPosition_ShouldPlaceRobot()
        {
            robot.Place(new Position(0, 0, Direction.NORTH), table);
            Assert.IsTrue(robot.IsPlaced);
            Assert.AreEqual("0,0,NORTH", robot.Report());
        }

        /// <summary>
        /// Test: Moving forward from (0,0,NORTH) should move robot to (0,1,NORTH).
        /// Expected: Y increases by 1.
        /// </summary>
        [TestMethod]
        public void Move_ValidMove_ShouldUpdatePosition()
        {
            robot.Place(new Position(0, 0, Direction.NORTH), table);
            robot.Move();
            Assert.AreEqual("0,1,NORTH", robot.Report());
        }

        /// <summary>
        /// Test: Moving forward from (0,4,NORTH) should be ignored 
        /// because robot would fall off the table.
        /// Expected: Position stays (0,4,NORTH).
        /// </summary>
        [TestMethod]
        public void Move_InvalidMove_ShouldIgnore()
        {
            robot.Place(new Position(0, 4, Direction.NORTH), table);
            robot.Move();
            Assert.AreEqual("0,4,NORTH", robot.Report());
        }

        /// <summary>
        /// Test: Rotating left from NORTH should change facing direction to WEST.
        /// Expected: (0,0,WEST).
        /// </summary>
        [TestMethod]
        public void Left_ShouldRotateLeft()
        {
            robot.Place(new Position(0, 0, Direction.NORTH), table);
            robot.Left();
            Assert.AreEqual("0,0,WEST", robot.Report());
        }

        /// <summary>
        /// Test: Rotating right from NORTH should change facing direction to EAST.
        /// Expected: (0,0,EAST).
        /// </summary>
        [TestMethod]
        public void Right_ShouldRotateRight()
        {
            robot.Place(new Position(0, 0, Direction.NORTH), table);
            robot.Right();
            Assert.AreEqual("0,0,EAST", robot.Report());
        }
    }

}
