using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Core.Models;
using ToyRobotSimulator.Services.Commands;

namespace ToyRobotSimulator.Services.Services
{

    /// <summary>
    /// Responsible for parsing user input strings into executable commands.
    /// Implements a simple Command Pattern factory.
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>
        /// Parses a string input (e.g., "MOVE", "LEFT", "PLACE 1,2,NORTH") 
        /// and returns the corresponding command object.
        /// Returns null if the command is invalid.
        /// </summary>
        /// <param name="input">The raw command entered by the user.</param>
        /// <returns>An <see cref="ICommand"/> implementation if valid, otherwise null.</returns>
        public static ICommand? Parse(string input)
        {
            // Ignore empty input
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Split input by space, first token is the command keyword
            var parts = input.Trim().Split(' ');

            switch (parts[0].ToUpper())
            {
                case "MOVE":   // Move forward
                    return new MoveCommand();

                case "LEFT":   // Rotate left
                    return new LeftCommand();

                case "RIGHT":  // Rotate right
                    return new RightCommand();

                case "REPORT": // Print current position
                    return new ReportCommand();

                case "PLACE":
                    // PLACE command must have arguments: X,Y,F
                    if (parts.Length < 2) return null;

                    // Split args: "1,2,NORTH" → [1, 2, NORTH]
                    var args = parts[1].Split(',');
                    if (args.Length != 3) return null;

                    // Validate arguments: X and Y must be integers, F must be a Direction
                    if (int.TryParse(args[0], out int x) &&
                        int.TryParse(args[1], out int y) &&
                        Enum.TryParse(args[2], true, out Direction facing))
                    {
                        return new PlaceCommand(x, y, facing);
                    }

                    // Invalid PLACE arguments
                    return null;

                default:
                    // Unknown command → ignore
                    return null; 
            }
        }
    }
    
}
