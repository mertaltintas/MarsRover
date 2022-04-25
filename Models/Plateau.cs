using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Plateau
    {
        public int upper_Y { get; }
        public int lower_Y { get; } = 0;
        public int right_X { get; }
        public int left_X { get; } = 0;
        public Plateau(int rightX, int upperY)
        {
            right_X = rightX;
            upper_Y = upperY;
        }
    }
}
