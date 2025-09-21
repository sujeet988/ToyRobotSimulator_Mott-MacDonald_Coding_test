using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core.Models;

namespace ToyRobotSimulator.Core.Interfaces
{
    public interface IRobot
    {
        Position Position { get; }
        bool IsPlaced { get; }
        void Place(Position position, ITable table);
        void Move();
        void Left();
        void Right();
        string Report();
    }
}
