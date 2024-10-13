namespace Tripledot.FlappyBird.Leaderboard.Domain.Model
{
    public class LeaderboardPlayerData
    {
        public readonly string Id;
        public readonly string Name;
        public readonly Score Score;

        public LeaderboardPlayerData(string id, string name, Score score)
        {
            Id = id;
            Name = name;
            Score = score;
        }

        public LeaderboardPlayerData SetScore(int score) => new LeaderboardPlayerData(Id, Name, Score.NewScore(score));
    }
}