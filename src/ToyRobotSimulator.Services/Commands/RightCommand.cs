using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    public class RightCommand : ICommand
    {
      
        public void Execute(IRobot robot, ITable table)
        {
            robot.Right();
        }
    }
}
