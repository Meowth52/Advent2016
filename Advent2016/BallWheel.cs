using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2016
{
    class BallWheel
    {
        int NrOfPositions;
        int StartPosition;
        public BallWheel(int nrOfPositions, int startPostition)
        {
            NrOfPositions = nrOfPositions;
            StartPosition = startPostition;
        }
        public bool IsAtZero(int StartTime)
        {
            return (0 == (StartTime+StartPosition)%NrOfPositions);
        }
    }
}
