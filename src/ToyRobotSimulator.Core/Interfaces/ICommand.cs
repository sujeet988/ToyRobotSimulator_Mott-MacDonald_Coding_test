using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core.Interfaces
{
    /// <summary>
    /// Represents a command that can be executed by the robot.
    /// Each command (e.g., PLACE, MOVE, LEFT, RIGHT, REPORT) 
    /// implements this interface and defines its own behavior.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command on the given robot within the given table context.
        /// </summary>
        /// <param name="robot">The robot that the command will act upon.</param>
        /// <param name="table">The table defining valid movement boundaries.</param>
        void Execute(IRobot robot, ITable table);
    }
}
