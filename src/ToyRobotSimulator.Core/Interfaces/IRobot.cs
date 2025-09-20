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
        bool IsPlaced { get; }
        Position? Position { get; }
        Direction? Facing { get; }


        void Place(Position pos, Direction facing);
        void Move();
        void Left();
        void Right();
        string Report();
    }
}
