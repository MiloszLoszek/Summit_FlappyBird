using Tripledot.FlappyBird.Leaderboard.Domain.Model;

namespace Tripledot.FlappyBird.Leaderboard.Infrastructure.DTOs
{
    public class PlayerDataDTO
    {
        public string uid;
        public string name;
        public ScoreDTO scores;

        public PlayerDataDTO()
        {
        }

        public PlayerDataDTO(string uid, string name, ScoreDTO scores)
        {
            this.uid = uid;
            this.name = name;
            this.scores = scores;
        }

        public LeaderboardPlayerData ToPlayer() => new LeaderboardPlayerData(uid, name, scores.ToScore());

        public static PlayerDataDTO From(LeaderboardPlayerData player)
        {
            return new PlayerDataDTO(
                player.Id,
                player.Name,
                ScoreDTO.From(player.Score)
            );
        }
    }
}