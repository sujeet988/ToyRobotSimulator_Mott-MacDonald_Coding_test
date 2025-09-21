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
    public class CommandProcessor
    {
        public static ICommand? Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            var parts = input.Trim().Split(' ');

            switch (parts[0].ToUpper())
            {
                case "MOVE": return new MoveCommand();
                case "LEFT": return new LeftCommand();
                case "RIGHT": return new RightCommand();
                case "REPORT": return new ReportCommand();
                case "PLACE":
                    if (parts.Length < 2)
                    {
                        return null;
                    }
                    var args = parts[1].Split(',');
                    if (args.Length != 3)
                    {
                        return null;
                    }

                    if (int.TryParse(args[0], out int x) &&
                        int.TryParse(args[1], out int y) &&
                        Enum.TryParse(args[2], true, out Direction facing))
                    {
                        return new PlaceCommand(x, y, facing);
                    }
                    return null;
                default:
                    return null;
            }
        }
    }
}
