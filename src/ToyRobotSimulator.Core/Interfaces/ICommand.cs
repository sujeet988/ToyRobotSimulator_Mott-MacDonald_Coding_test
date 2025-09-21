using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core.Interfaces
{
    public interface ICommand
    {
        void Execute(IRobot robot, ITable table);
    }
}
