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
        // The tabletop the robot is placed on
        private ITable _table;

        // The current position and facing direction of the robot
        public Position Position { get; private set; }

        // Indicates whether the robot has been placed on the table
        public bool IsPlaced { get; private set; }

        /// <summary>
        /// Places the robot on the given table at the specified position.
        /// Placement only happens if the position is valid (within table bounds).
        /// </summary>
        public void Place(Position position, ITable table)
        {
            if (table.IsValidPosition(position))
            {
                Position = position;
                _table = table;
                IsPlaced = true;
            }
        }

        /// <summary>
        /// Moves the robot one step forward in the current facing direction.
        /// The move is only applied if it keeps the robot within table boundaries.
        /// </summary>
        public void Move()
        {
            if (!IsPlaced) return;

            // Start with the current position
            var newPos = Position.GetNextPosition();

            // Adjust based on facing direction
            switch (Position.Facing)
            {
                case Direction.North: newPos.Y++; break;
                case Direction.South: newPos.Y--; break;
                case Direction.East: newPos.X++; break;
                case Direction.West: newPos.X--; break;
            }

            // Update position only if the new one is valid
            if (_table.IsValidPosition(newPos))
                Position = newPos;
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the left without changing its position.
        /// </summary>
        public void Left()
        {
            if (!IsPlaced) return;

            switch (Position.Facing)
            {
                case Direction.North: Position.Facing = Direction.West; break;
                case Direction.West: Position.Facing = Direction.South; break;
                case Direction.South: Position.Facing = Direction.East; break;
                case Direction.East: Position.Facing = Direction.North; break;
            }
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the right without changing its position.
        /// </summary>
        public void Right()
        {
            if (!IsPlaced) return;

            switch (Position.Facing)
            {
                case Direction.North: Position.Facing = Direction.East; break;
                case Direction.East: Position.Facing = Direction.South; break;
                case Direction.South: Position.Facing = Direction.West; break;
                case Direction.West: Position.Facing = Direction.North; break;
            }
        }

        /// <summary>
        /// Returns the robot’s current position and facing direction.
        /// If the robot is not placed yet, a message is returned instead.
        /// </summary>
        public string Report()
        {
            return IsPlaced
                ? $"{Position.X},{Position.Y},{Position.Facing}"
                : "Robot not placed.";
        }

    }
}
