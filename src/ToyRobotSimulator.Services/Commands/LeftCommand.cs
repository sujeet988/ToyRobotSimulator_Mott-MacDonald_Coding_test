using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    /// <summary>Command to rotate the robot 90 degrees to the left (counter-clockwise).</summary>
    public class LeftCommand : ICommand
    {
        /// <summary>Executes the LEFT command by rotating the robot counter-clockwise.</summary>
        public void Execute(IRobot robot, ITable table) => robot.Left();
    }


}
