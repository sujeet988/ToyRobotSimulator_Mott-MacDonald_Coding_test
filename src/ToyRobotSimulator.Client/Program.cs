using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Services.Implementation;
using ToyRobotSimulator.Services.Services;

namespace ToyRobotSimulator.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITable table = new Table(5, 5);
            IRobot robot = new Robot(table);
            var parser = new CommandParser(robot, Console.WriteLine);

            IEnumerable<string> lines;

            if (args.Length > 0 && File.Exists(args[0]))
                lines = File.ReadAllLines(args[0]);
            else
            {
                Console.WriteLine("Enter commands (empty line to finish):");
                var input = new List<string>();
                string? line;
                while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                    input.Add(line);
                lines = input;
            }

            foreach (var line in lines)
                parser.Parse(line)?.Execute();
        }
    }
}
