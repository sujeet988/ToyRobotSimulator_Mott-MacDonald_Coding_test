using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core.Models
{
    public record Position(int X, int Y)
    {
        public Position Move(Direction dir)
        {
            return dir switch
            {
                Direction.North => this with { Y = Y + 1 },
                Direction.South => this with { Y = Y - 1 },
                Direction.East => this with { X = X + 1 },
                Direction.West => this with { X = X - 1 },
                _ => this
            };
        }
    }
}
