using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Infrastructure
{
    [Flags]
    public enum CompasPoints
    {
        North = 1,
        East = 2,
        South = 4,
        West = 8
    }
}
