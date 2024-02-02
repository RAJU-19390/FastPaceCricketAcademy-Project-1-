using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerDetails;

namespace CricketPlayer
{

    public interface ITeamPlayers
    {
        void AddPlayer();
        void RemovePlayer(int playerId);
        Player GetPlayerById(int playerId);
        List<Player> GetPlayerByName(string playerName);
        List<Player> GetAllPlayers();
    }

    public class CricketTeam : ITeamPlayers
    {
        public List<Player> players = new List<Player>();
        

        public void AddPlayer()
        {
            Console.WriteLine("Enter player details:");

            while (players.Count <= 11)
            {
                Console.Write("Player Id: ");
                int playerid = Convert.ToInt32(Console.ReadLine());

                Console.Write("Player Name: ");
                string playername = Console.ReadLine();

                Console.Write("Player Age: ");
                int playerage = Convert.ToInt32(Console.ReadLine());

                Player newplayer = new Player { PlayerId = playerid, PlayerName = playername, PlayerAge = playerage };

                if (players.Count <= 11)
                {
                    players.Add(newplayer);
                    Console.WriteLine($"{newplayer.PlayerName} added to Cricket Team.");
                }
                else
                {
                    Console.WriteLine("Team limit reached.Only 11 Players");
                    break;
                }
                Console.Write("Do you want to add another player? (Y/N): ");
                string userInput = Console.ReadLine().Trim();

                if (userInput.ToUpper() != "Y")
                {
                    break;
                }
            }

            Console.WriteLine($"{players.Count} Player(s) added to Cricket team successfully.");
        }
        public void RemovePlayer(int playerid)
        {
            Player PlayerToRemove = players.Find(p => p.PlayerId == playerid);
            if (PlayerToRemove != null)
            {
                players.Remove(PlayerToRemove);
                Console.WriteLine($"Player {PlayerToRemove.PlayerName} removed from the team.");
            }
            else
            {
                Console.WriteLine("Player not found in the team.");
            }
        }
        public Player GetPlayerById(int playerid)
        {
            return players.Find(p => p.PlayerId == playerid);
        }

        public List<Player> GetPlayerByName(string playername)
        {
            return players.Where(p => p.PlayerName.Equals(playername, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Player> GetAllPlayers()
        {
            return players;
        }

    }
}
