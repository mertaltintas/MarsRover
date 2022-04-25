using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Services
{
    internal interface IRoverService
    {
        public void StartAction(Plateau plateau);
        public (int x, int y, char direction) GetFinalState();
    }
}
