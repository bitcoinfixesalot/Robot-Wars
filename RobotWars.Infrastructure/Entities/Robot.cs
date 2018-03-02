using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Infrastructure
{
    public class Robot
    {
        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public CompasPoints Compas { get; set; }
    }
}
