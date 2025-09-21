using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Implementation
{
    public class Robot : IRobot
    {
        private ITable _table;
        public Position Position { get; private set; }
        public bool IsPlaced { get; private set; }

        public void Place(Position position, ITable table)
        {
            if (table.IsValidPosition(position))
            {
                Position = position;
                _table = table;
                IsPlaced = true;
            }
        }

        public void Move()
        {
            if (!IsPlaced) return;

            var newPos = Position.Clone();
            switch (Position.Facing)
            {
                case Direction.North: newPos.Y++; break;
                case Direction.South: newPos.Y--; break;
                case Direction.East: newPos.X++; break;
                case Direction.West: newPos.X--; break;
            }

            if (_table.IsValidPosition(newPos))
                Position = newPos;
        }

        public void Left()
        {
            if (!IsPlaced) return;
            Position.Facing = (Direction)(((int)Position.Facing + 3) % 4); // rotate left

            //
            //if (!IsPlaced || Facing == null) return;
            //Facing = Facing switch
            //{
            //    Direction.North => Direction.West,
            //    Direction.West => Direction.South,
            //    Direction.South => Direction.East,
            //    Direction.East => Direction.North,
            //    _ => Facing
            //};
        }

        public void Right()
        {
            if (!IsPlaced) return;
            Position.Facing = (Direction)(((int)Position.Facing + 1) % 4); // rotate right

            //if (!IsPlaced || Facing == null)
            //{
            //    return;
            //}
            //Facing = Facing switch
            //{
            //    Direction.North => Direction.East,
            //    Direction.East => Direction.South,
            //    Direction.South => Direction.West,
            //    Direction.West => Direction.North,
            //    _ => Facing
            //};
        }

        public string Report()
        {
            return IsPlaced
                ? $"{Position.X},{Position.Y},{Position.Facing}"
                : "Robot not placed.";
        }
    }
}
