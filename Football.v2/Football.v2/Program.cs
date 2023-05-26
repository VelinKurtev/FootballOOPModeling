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

            //TEST PLAYERS
            createdPlayers.Add(new Striker("Test", 10, 00, 100));
            createdPlayers.Add(new Striker("Test", 20, 00, 100));
            createdPlayers.Add(new Striker("Test", 30, 00, 100));
            createdPlayers.Add(new Striker("Test", 40, 00, 100));
            createdPlayers.Add(new Striker("Test", 50, 00, 100));
            createdPlayers.Add(new Striker("Test", 60, 00, 100));
            createdPlayers.Add(new Striker("Test", 70, 00, 100));
            createdPlayers.Add(new Striker("Test", 80, 00, 100));
            createdPlayers.Add(new Striker("Test", 90, 00, 100));
            createdPlayers.Add(new Striker("Test", 80, 00, 100));
            createdPlayers.Add(new Striker("Test", 70, 00, 100));
            //TEST COACHES
            createdCoaches.Add(new Coach("Ivan Petev", 55));
            createdCoaches.Add(new Coach("Ivan Asenov", 35));

            //TEST REFS
            createdReferees.Add(new Referee("Asen Blatechki", 45));
            createdReferees.Add(new Referee("Arnold Terminatora", 70));
            createdReferees.Add(new Referee("Silvestur Rockito", 65));
            //
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
                        createdTeams = AddTeam(createdTeams, createdPlayers, createdCoaches);
                        break;
                    case 2:
                        createdReferees = AddReferee(createdReferees);
                        break;
                    case 3:
                        createdCoaches = AddCoach(createdCoaches);
                        break;
                    case 4:
                        createdGames = AddGames(createdGames, createdTeams, createdReferees);
                        break;
                    case 5:
                        ViewAverageAgeOfTeam(createdTeams);
                        break;
                    case 6:
                        ViewGames(createdGames);
                        break;
                    case 7:
                        return;
                }
            }
        }

        private static List<Game> AddGames(List<Game> createdGames, List<Team> createdTeams, List<Referee> createdReferees)
        {
            List<Referee> tempReferees = createdReferees.ToList();
            List<Team> tempTeams = createdTeams.ToList();
            List<Referee> astRefs = new List<Referee>();
            bool gameNotEnded = true;

            if (createdTeams.Count < 2)
            {
                Console.WriteLine("Not enough teams!");
                return createdGames;
            }

            for (int i = 0; i < tempTeams.Count; i++)
            {
                Console.WriteLine($"{i}. {tempTeams[i]}");
            }
            Console.WriteLine("Select Team 1:");
            int team1Index = int.Parse(Console.ReadLine());
            Team team1 = tempTeams[team1Index];
            tempTeams.RemoveAt(team1Index);

            for (int i = 0; i < tempTeams.Count; i++)
            {
                Console.WriteLine($"{i}. {tempTeams[i]}");
            }
            Console.WriteLine("Select Team 2:");
            int team2Index = int.Parse(Console.ReadLine());
            Team team2 = tempTeams[team2Index];
            tempTeams.RemoveAt(team2Index);

            if (tempReferees.Count < 3)
            {
                Console.WriteLine("Not enough refs");
                return createdGames;
            }

            for (int i = 0; i < tempReferees.Count; i++)
            {
                Console.WriteLine($"{i}. {tempReferees[i]}");
            }
            Console.WriteLine("Select Main Ref:");
            int mainRefIndex = int.Parse(Console.ReadLine());
            Referee referee = tempReferees[mainRefIndex];
            tempReferees.RemoveAt(mainRefIndex);

            for (int times = 0; times < 2; times++)
            {
                for (int i = 0; i < tempReferees.Count; i++)
                {
                    Console.WriteLine($"{i}. {tempReferees[i]}");
                }
                Console.WriteLine("Select Ast. Ref:");
                int astRefIndex = int.Parse(Console.ReadLine());
                Referee astRef = tempReferees[astRefIndex];
                astRefs.Add(astRef);
                tempReferees.RemoveAt(astRefIndex);
            }

            Game game = new Game(team1, team2, referee, astRefs);

            int team1Goals = 0;
            int team2Goals = 0;

            while (gameNotEnded)
            {
                Console.WriteLine("0.Score a Goal");
                Console.WriteLine("1.End Game");
                Console.WriteLine("Choose operation:");
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 0:
                        Console.WriteLine("In minute:");
                        int minute = int.Parse(Console.ReadLine());

                        Console.WriteLine("Select which team scores:");
                        Console.WriteLine($"0.{team1.Name}");
                        Console.WriteLine($"1.{team2.Name}");
                        int selectedTeam = int.Parse(Console.ReadLine());
                        Team scoringTeam;
                        if (selectedTeam == 0)
                        {
                            scoringTeam = team1;
                        }
                        else
                        {
                            scoringTeam = team2;
                        }
                        
                        List<FootballPlayer> players = scoringTeam.Players;
                        Console.WriteLine("Available Players:");
                        for (int i = 0; i < players.Count; i++)
                        {
                            Console.WriteLine($"{i}. {players[i]}");
                        }
                        Console.WriteLine("Select which player scores:");
                        int playerIndex = int.Parse(Console.ReadLine());
                        game.AddGoal(minute, players[playerIndex]);
                        if (selectedTeam == 0)
                        {
                            team1Goals++;
                        }
                        else
                        {
                            team2Goals++;
                        }
                        break;
                    case 1:
                        gameNotEnded = false;
                        string winner = (team1Goals > team2Goals) ? team1.Name : (team1Goals < team2Goals) ? team2.Name : "Draw";
                        game.SetGameResult($"{team1Goals}:{team2Goals}", winner);
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }
            }

            createdGames.Add(game);

            return createdGames;
        }

        private static void ViewAverageAgeOfTeam(List<Team> createdTeams)
        {
            if (createdTeams.Count > 0)
            {
                Console.WriteLine("Select team to view average age of players:");
                for (int i = 0; i < createdTeams.Count; i++)
                {
                    Console.WriteLine($"{i}. {createdTeams[i]}");
                }
                int selectedTeam = int.Parse(Console.ReadLine());
                Console.WriteLine($"{createdTeams[selectedTeam].Name} Average Age of Players: {createdTeams[selectedTeam].AveragePlayerAge:f2}");
            }
            else
            {
                Console.WriteLine("No teams to be selected");
            }
        }

        private static List<Coach> AddCoach(List<Coach> createdCoaches)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            createdCoaches.Add(new Coach(name, age));
            return createdCoaches;
        }

        private static List<Referee> AddReferee(List<Referee> createdReferees)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            createdReferees.Add(new Referee(name, age));
            return createdReferees;
        }

        private static List<Team> AddTeam(List<Team> createdTeams, List<FootballPlayer> createdPlayers, List<Coach> createdCoaches)
        {
            Console.WriteLine("Enter team name:");
            string name = Console.ReadLine();

            if (createdCoaches.Count == 0)
            {
                Console.WriteLine("No coaches to be selected!");
                return createdTeams;
            }
            Console.WriteLine("Available coaches:");
            for (int i = 0; i < createdCoaches.Count; i++)
            {
                Console.WriteLine($"{i}. {createdCoaches[i]}");
            }
            Console.WriteLine("Select Coach:");
            Coach coach = createdCoaches[int.Parse(Console.ReadLine())];
            Team team = new Team(name, coach);

            if (createdPlayers.Count < 11)
            {
                Console.WriteLine("Not enough players for creation of an team!");
                return createdTeams;
            }
            List<FootballPlayer> tempPlayers = createdPlayers.ToList();
            while (tempPlayers.Count != 0 && team.Players.Count != 22)
            {
                for (int i = 0; i < tempPlayers.Count; i++)
                {
                    Console.WriteLine($"{i}. {tempPlayers[i]}");
                }
                Console.WriteLine("Select player to add to team:");
                int playerIndex = int.Parse(Console.ReadLine());

                team.Players.Add(tempPlayers[playerIndex]);
                tempPlayers.RemoveAt(playerIndex);

                if (team.Players.Count >= 11)
                {
                    Console.Write("Do you want to end selection?(y/n):");
                    string end = Console.ReadLine();
                    if (end == "y")
                    {
                        break;
                    }
                }
            }

            createdTeams.Add(team);
            return createdTeams;
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
            sb.AppendLine("6.View Games");
            sb.AppendLine("7.Exit");
            sb.Append("Choose operation:");
            Console.WriteLine(sb.ToString());
        }

        private static List<FootballPlayer> AddPlayer(List<FootballPlayer> currentPlayers)
        {
            List<string> positions = new List<string> { "Striker", "Midfielder", "Defender", "Goalkeeper" };

            Console.WriteLine("Select position:");
            for (int i = 0; i < positions.Count; i++)
            {
                Console.WriteLine($"{i}.{positions[i]}");
            }

            int posIndex = int.Parse(Console.ReadLine());
            if (posIndex < 0 || posIndex >= positions.Count)
            {
                Console.WriteLine("Invalid position selected!");
                return currentPlayers;
            }

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
                    Console.WriteLine("Invalid position selected!");
                    return currentPlayers;
            }

            currentPlayers.Add(player);
            return currentPlayers;
        }

        static void ViewGames(List<Game> createdGames)
        {
            if (createdGames == null || createdGames.Count == 0)
            {
                Console.WriteLine("No games recorded!");
                return;
            }

            foreach (var game in createdGames)
            {
                Console.WriteLine($"{createdGames.IndexOf(game)}. {game.Team1.Name} vs {game.Team2.Name}, Result: {game.GameResult}, Winner: {game.Winner}, Main ref: {game.Referee.Name}");
            }
        }

    }
}
