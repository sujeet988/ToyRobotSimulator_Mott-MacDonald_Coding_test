using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    /// <summary>Command to rotate the robot 90 degrees to the right (clockwise).</summary>
    public class RightCommand : ICommand
    {
        /// <summary>Executes the RIGHT command by rotating the robot clockwise.</summary>
        public void Execute(IRobot robot, ITable table)
        {
            robot.Right();
        }
    }

}
