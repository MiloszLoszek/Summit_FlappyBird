using System;
using System.Globalization;
using System.Linq;

namespace Tripledot.FlappyBird.Leaderboard.Infrastructure.DTOs
{
    public class LeaderboardDTO
    {
        public string start;
        public string end;
        public PlayerDataDTO[] players;

        public LeaderboardDTO(string start, string end, PlayerDataDTO[] players)
        {
            this.start = start;
            this.end = end;
            this.players = players;
        }

        public Domain.Model.Leaderboard ToLeaderboard()
        {
            return new Domain.Model.Leaderboard(DateTime.Parse(start),
                DateTime.Parse(end),
                players.Select(player => player.ToPlayer()).ToArray());
        }

        public static LeaderboardDTO From(Domain.Model.Leaderboard leaderboard)
        {
            return new LeaderboardDTO(
                leaderboard.Start.ToString(CultureInfo.InvariantCulture),
                leaderboard.End.ToString(CultureInfo.InvariantCulture),
                leaderboard.PlayersData.Select(PlayerDataDTO.From).ToArray()
            );
        }
    }
}