using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Interfaces
{
    public interface ITable
    {
        int Width { get; }
        int Height { get; }
        bool IsValidPosition(Position pos);
    }
}
