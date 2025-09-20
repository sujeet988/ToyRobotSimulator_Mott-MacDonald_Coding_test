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
        private readonly IRobot _robot;
        public RightCommand(IRobot robot) => _robot = robot;
        public void Execute() => _robot.Right();
    }
}
