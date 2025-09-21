using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Interfaces
{
    /// <summary>Represents a toy robot that can be placed on a table and controlled by commands.</summary>
    public interface IRobot
    {
        /// <summary>The current position and facing direction of the robot.</summary>
        Position Position { get; }

        /// <summary>Indicates whether the robot has been placed on the table.</summary>
        bool IsPlaced { get; }

        /// <summary>Places the robot at the given position on the specified table if valid.</summary>
        void Place(Position position, ITable table);

        /// <summary>Moves the robot one unit forward in its current facing direction.</summary>
        void Move();

        /// <summary>Rotates the robot 90 degrees to the left.</summary>
        void Left();

        /// <summary>Rotates the robot 90 degrees to the right.</summary>
        void Right();

        /// <summary>Reports the current position and facing direction of the robot.</summary>
        string Report();
    }

}
