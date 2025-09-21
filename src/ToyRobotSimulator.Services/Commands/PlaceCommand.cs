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
        private readonly int _x, _y;
        private readonly Direction _facing;
        public PlaceCommand(int x, int y, Direction facing)
        {
            _x = x; _y = y; _facing = facing;
        }

        public void Execute(IRobot robot, ITable table)
        {
            robot.Place(new Position(_x, _y, _facing), table);
        }
    }
}
