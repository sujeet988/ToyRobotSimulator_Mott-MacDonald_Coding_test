using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Interfaces;

namespace ToyRobotSimulator.Services.Commands
{
    public class ReportCommand: ICommand
    {

        private readonly IRobot _robot;
        private readonly Action<string> _output;

        public ReportCommand(IRobot robot, Action<string> output)
        {
            _robot = robot;
            _output = output;
        }

        public void Execute()
        {
            var report = _robot.Report();
            if (!string.IsNullOrWhiteSpace(report))
            {
                _output(report);
            }
                
        }
    }
}
