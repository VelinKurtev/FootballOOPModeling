using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.v2
{
    class Game
    {
        public Team Team1 { get; private set; }
        public Team Team2 { get; private set; }
        public Referee Referee { get; private set; }
        public List<Referee> AssistantReferees { get; private set; }
        public List<Goal> Goals { get; private set; }
        public string GameResult { get; private set; }
        public string Winner { get; private set; }

        public Game(Team team1, Team team2, Referee referee, List<Referee> assistantReferees)
        {
            Team1 = team1;
            Team2 = team2;
            Referee = referee;
            AssistantReferees = assistantReferees;
            Goals = new List<Goal>();
            GameResult = "Not played yet";
            Winner = null;
        }

        public void AddGoal(int minute, FootballPlayer player)
        {
            Goals.Add(new Goal(minute, player));
        }

        public void SetGameResult(string result, string winner)
        {
            GameResult = result;
            Winner = winner;
        }

    }
}
