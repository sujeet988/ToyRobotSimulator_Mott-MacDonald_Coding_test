using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    /// <summary>Command to print the robot’s current position and direction.</summary>
    public class ReportCommand : ICommand
    {
        /// <summary>Executes the REPORT command by writing the robot’s status to console.</summary>
        public void Execute(IRobot robot, ITable table)
        {
            Console.WriteLine(robot.Report());
        }
    }

}

