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
            if (!IsPlaced)
            {
                return;
            }
            //Position.Facing = (Direction)(((int)Position.Facing + 3) % 4); // rotate left
            switch (Position.Facing)
            {
                case Direction.North: Position.Facing = Direction.West; break;
                case Direction.West: Position.Facing = Direction.South; break;
                case Direction.South: Position.Facing = Direction.East; break;
                case Direction.East: Position.Facing = Direction.North; break;
            }
        }

        public void Right()
        {
            if (!IsPlaced) return;
            //  Position.Facing = (Direction)(((int)Position.Facing + 1) % 4); // rotate right

            switch (Position.Facing)
            {
                case Direction.North: Position.Facing = Direction.East; break;
                case Direction.East: Position.Facing = Direction.South; break;
                case Direction.South: Position.Facing = Direction.West; break;
                case Direction.West: Position.Facing = Direction.North; break;
            }
        }

        public string Report()
        {
            return IsPlaced
                ? $"{Position.X},{Position.Y},{Position.Facing}"
                : "Robot not placed.";
        }
    }
}
