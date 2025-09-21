using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Services.Commands
{
    
        /// <summary>Command to place the robot at given coordinates and facing direction.</summary>
        public class PlaceCommand : ICommand
        {
            // X and Y coordinates where the robot will be placed
            private readonly int _x, _y;

            // Direction the robot will face after placement
            private readonly Direction _facing;

            /// <summary>Initializes a new PlaceCommand with X, Y and facing direction.</summary>
            public PlaceCommand(int x, int y, Direction facing)
            {
                _x = x;
                _y = y;
                _facing = facing;
            }

            /// <summary>Executes the PLACE command by positioning the robot on the table.</summary>
            public void Execute(IRobot robot, ITable table)
            {
                robot.Place(new Position(_x, _y, _facing), table);
            }
        }

    

}
