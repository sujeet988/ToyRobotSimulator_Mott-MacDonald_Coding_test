using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Services.Implementation
{
    public class Table: ITable
    {
        private readonly int _width;
        private readonly int _height;

        public Table(int width = 5, int height = 5)
        {
            _width = width;
            _height = height;
        }

        public bool IsValidPosition(Position pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < _width && pos.Y < _height;

        }
          
    }
}
