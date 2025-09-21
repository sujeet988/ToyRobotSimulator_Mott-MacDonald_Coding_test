using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Interfaces
{
    /// <summary>Represents a tabletop that defines boundaries for the robot.</summary>
    public interface ITable
    {
        /// <summary>The width of the table.</summary>
        int Width { get; }

        /// <summary>The height of the table.</summary>
        int Height { get; }

        /// <summary>Checks whether the given position is within table boundaries.</summary>
        bool IsValidPosition(Position pos);
    }

}
