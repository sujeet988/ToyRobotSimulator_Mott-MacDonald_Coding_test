using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    public class LeftCommand : ICommand
    {
        private readonly IRobot _robot;
        public LeftCommand(IRobot robot)
        {
            _robot = robot;
        }
        public void Execute()
        {
            _robot.Left();
        }
    }
}
