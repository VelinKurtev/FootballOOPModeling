using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.v2
{
    class Team
    {
        public string Name { get; private set; }
        public Coach Coach { get; private set; }
        public List<FootballPlayer> Players { get; private set; }

        public double AveragePlayerAge
        {
            get
            {
                if (Players.Count == 0)
                    return 0;

                int totalAge = Players.Sum(player => player.Age);
                return (double)totalAge / Players.Count;
            }
        }

        public Team(string name, Coach coach)
        {
            Name = name;
            Coach = coach;
            Players = new List<FootballPlayer>();
        }

        public override string ToString()
        {
            return $"{Name}, Coach: {Coach.Name} Players: {Players.Count}";
        }
    }
}
