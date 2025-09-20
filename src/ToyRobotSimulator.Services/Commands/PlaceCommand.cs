using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Services.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly IRobot _robot;
        private readonly Position _pos;
        private readonly Direction _dir;

        public PlaceCommand(IRobot robot, Position pos, Direction dir)
        {
            _robot = robot;
            _pos = pos;
            _dir = dir;
        }

        public void Execute()
        {
            _robot.Place(_pos, _dir);
        }
    }
}
