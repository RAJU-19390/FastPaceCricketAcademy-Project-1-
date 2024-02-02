using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerDetails;

namespace CricketPlayer
{
    class Program
    {
        static CricketTeam cricket_team = new CricketTeam();
        static void Main(string[] args)
        {

            char ch='Y';
            do {

                Console.WriteLine("1.Add Player Details(Id,Name,Age)\n2.Remove Player from Team by entering Id\n3.Display player details by entering Id\n4.Display player Details by entering name\n5.Display All Player Details\n6.Exit\nSelect One Option : ");
                int userchoice = Convert.ToInt32(Console.ReadLine());
                switch (userchoice)
                {
                    case 1:
                        AddPlayerDetails();
                        break;
                    case 2:
                        RemovePlayerById();
                        break;
                    case 3:
                        PlayerDetailsById();
                        break;
                    case 4:
                        PlayerDetailsByName();
                        break;
                    case 5:
                        AllPlayerDetails();
                        break;
                    case 6:
                        Environment.Exit(1);
                        break;
                    default: Console.WriteLine("Oops!Invalid option!!Enter correct option...");
                        break;
                }
                Console.WriteLine("***********************************************************************************");

            } while (ch=='Y'||ch=='y');
            Console.ReadLine();
        }
        static void AddPlayerDetails()
        {
            cricket_team.AddPlayer();
        }

        static void RemovePlayerById()
        {
            Console.WriteLine("Enter Player Id to remove");
            int removeid = Convert.ToInt32(Console.ReadLine());
            cricket_team.RemovePlayer(removeid);
        }

        static void PlayerDetailsById()
        {
            Console.WriteLine("Enter Player Id to display details : ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Player playerdetailsbyid = cricket_team.GetPlayerById(Id);
            if (playerdetailsbyid != null)
            { 
                Console.WriteLine($"PlayerId: {playerdetailsbyid.PlayerId} | PlayerName: {playerdetailsbyid.PlayerName} | PlayerAge: {playerdetailsbyid.PlayerAge}");
            }
            else
            {
                Console.WriteLine("Given ID of player not found");
            }
        }

        static void PlayerDetailsByName()
        {
            Console.WriteLine("Enter Player Name to display details: ");
            string playername = Console.ReadLine();
            List<Player> playerdetailsbyname = cricket_team.GetPlayerByName(playername);
            if (playerdetailsbyname.Count > 0)
            {
                foreach (var player in playerdetailsbyname)
                {
                    Console.WriteLine($"PlayerId: {player.PlayerId} | PlayerName: {player.PlayerName} | PlayerAge: {player.PlayerAge}");
                }
            }
            else
            {
                Console.WriteLine("No players found with the given name.");
            }
        }
        static void AllPlayerDetails()
        {
            if (cricket_team.players.Count > 0)
            {
                foreach (var player in cricket_team.GetAllPlayers())
                {
                    Console.WriteLine($"PlayerId: {player.PlayerId} | PlayerName: {player.PlayerName} | PlayerAge: {player.PlayerAge}");
                }
            }
            else
            {
                Console.WriteLine("No player details found");
            }
        }
    }
}

