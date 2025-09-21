using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    /// <summary>Command to move the robot one unit forward in its current facing direction.</summary>
    public class MoveCommand : ICommand
    {
        /// <summary>Executes the MOVE command by moving the robot forward one step if valid.</summary>
        public void Execute(IRobot robot, ITable table)
        {
            robot.Move();
        }
    }


}
