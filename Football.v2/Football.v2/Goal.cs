using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.v2
{
    public class Goal
    {
        public int Minute { get; private set; }
        public FootballPlayer Player { get; private set; }
        public Goal(int minute, FootballPlayer player)
        {
            Minute = minute;
            Player = player;
        }
    }
}