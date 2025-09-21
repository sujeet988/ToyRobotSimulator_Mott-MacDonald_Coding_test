using ToyRobotSimulator.Core.Implementation;
using ToyRobotSimulator.Core.Interfaces;
using ToyRobotSimulator.Services.Services;

namespace ToyRobotSimulator.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a 5x5 table
            ITable table = new Table(5, 5);

            // Create the robot (initially not placed)
            IRobot robot = new Robot();

            Console.WriteLine("Toy Robot Simulator");
            Console.WriteLine("Enter commands (PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT). Type EXIT to quit.");
            Console.WriteLine();

            // Infinite loop to accept commands until user types EXIT
            while (true)
            {
                Console.Write("> "); // show prompt
                string? input = Console.ReadLine();

                // If no input or user typed EXIT → stop program
                if (string.IsNullOrWhiteSpace(input) || input.ToUpper() == "EXIT")
                    break;

                // Parse user input into a command object (Command Pattern)
                var command = CommandProcessor.Parse(input);

                // If valid command, execute it against the robot + table
                command?.Execute(robot, table);
            }


        }

    }
    
}
