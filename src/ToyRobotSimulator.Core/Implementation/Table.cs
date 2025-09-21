using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Implementation
{
    /// <summary>
    /// Represents a rectangular tabletop where the robot can move.
    /// The table ensures that the robot does not fall off by validating positions.
    /// </summary>
    public class Table : ITable
    {
        /// <summary>
        /// Width of the table (number of units along the X-axis).
        /// Default is 5.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of the table (number of units along the Y-axis).
        /// Default is 5.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Creates a new table with given dimensions.
        /// By default, creates a 5x5 table.
        /// </summary>
        public Table(int width = 5, int height = 5)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Checks if the given position is within the table boundaries.
        /// Returns true if the position is valid, otherwise false.
        /// </summary>
        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < Width &&
                   position.Y >= 0 && position.Y < Height;
        }
    }

}
