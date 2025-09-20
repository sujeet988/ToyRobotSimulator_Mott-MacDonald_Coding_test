using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Services.Implementation
{
    public class Robot : IRobot
    {
        private readonly ITable _table;

        public Robot(ITable table) => _table = table;

        public bool IsPlaced { get; private set; }
        public Position? Position { get; private set; }
        public Direction? Facing { get; private set; }

        public void Place(Position pos, Direction dir)
        {
            if (_table.IsValidPosition(pos))
            {
                Position = pos;
                Facing = dir;
                IsPlaced = true;
            }
        }

        public void Move()
        {
            if (!IsPlaced || Facing == null || Position == null) return;
            var newPos = Position.Move(Facing.Value);
            if (_table.IsValidPosition(newPos)) Position = newPos;
        }

        public void Left()
        {
            if (!IsPlaced || Facing == null) return;
            Facing = Facing switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => Facing
            };
        }

        public void Right()
        {
            if (!IsPlaced || Facing == null) return;
            Facing = Facing switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => Facing
            };
        }

        public string Report() =>
            IsPlaced && Position != null && Facing != null
                ? $"{Position.X},{Position.Y},{Facing.ToString().ToUpper()}"
                : string.Empty;
    }
}
