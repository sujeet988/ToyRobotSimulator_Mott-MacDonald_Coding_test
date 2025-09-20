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
    public class CommandParser
    {
        private readonly IRobot _robot;
        private readonly Action<string> _output;

        public CommandParser(IRobot robot, Action<string> output)
        {
            _robot = robot;
            _output = output;
        }

        public ICommand? Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            var parts = input.Trim().Split(' ');
            var cmd = parts[0].ToUpperInvariant();

            return cmd switch
            {
                "PLACE" when parts.Length > 1 => ParsePlace(parts[1]),
                "MOVE" => new MoveCommand(_robot),
                "LEFT" => new LeftCommand(_robot),
                "RIGHT" => new RightCommand(_robot),
                "REPORT" => new ReportCommand(_robot, _output),
                _ => null
            };
        }

        private ICommand? ParsePlace(string args)
        {
            var tokens = args.Split(',');
            if (tokens.Length != 3) return null;

            if (!int.TryParse(tokens[0], out var x)) return null;
            if (!int.TryParse(tokens[1], out var y)) return null;

            if (!Enum.TryParse<Direction>(tokens[2], true, out var dir)) return null;

            return new PlaceCommand(_robot, new Position(x, y), dir);
        }
    }
}
