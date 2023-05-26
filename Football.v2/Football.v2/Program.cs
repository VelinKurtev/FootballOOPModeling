using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.v2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FootballPlayer> createdPlayers = new List<FootballPlayer>();
            List<Team> createdTeams = new List<Team>();
            List<Game> createdGames = new List<Game>();
            List<Referee> createdReferees = new List<Referee>();
            List<Coach> createdCoaches = new List<Coach>();
            while (true)
            {
                PrintMenu();
                int opIndex = int.Parse(Console.ReadLine());
                switch (opIndex)
                {
                    case 0:
                        createdPlayers = AddPlayer(createdPlayers);
                        break;
                    case 1:
                        createdTeams = AddTeam(createdTeams, createdPlayers);
                        break;
                    case 6:
                        return;
                }
            }
        }

        private static List<Team> AddTeam(List<Team> createdTeams, List<FootballPlayer> createdPlayers)
        {
            throw new NotImplementedException();
        }

        static void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("0.Add Player");
            sb.AppendLine("1.Add Team");
            sb.AppendLine("2.Add Referee");
            sb.AppendLine("3.Add Coach");
            sb.AppendLine("4.Add Game");
            sb.AppendLine("5.View Team Avg Age");
            sb.AppendLine("6.Exit");
            sb.Append("Choose operation:");
            Console.WriteLine(sb.ToString());
        }

        private static List<FootballPlayer> AddPlayer(List<FootballPlayer> currentPlayers)
        {
            Console.WriteLine("Select position:");
            Console.WriteLine("0.Striker");
            Console.WriteLine("1.Midfielder");
            Console.WriteLine("2.Defender");
            Console.WriteLine("3.Goalkeeper");
            int posIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter height:");
            double height = double.Parse(Console.ReadLine());

            FootballPlayer player;
            switch (posIndex)
            {
                case 0:
                    player = new Striker(name, age, number, height);
                    break;
                case 1:
                    player = new Midfielder(name, age, number, height);
                    break;
                case 2:
                    player = new Defender(name, age, number, height);
                    break;
                case 3:
                    player = new Goalkeeper(name, age, number, height);
                    break;
                default:
                    Console.WriteLine("Invalid position selected");
                    return currentPlayers;
            }
            currentPlayers.Add(player);
            return currentPlayers;
        }
    }
}
