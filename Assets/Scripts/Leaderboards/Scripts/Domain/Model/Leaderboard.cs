using System;
using System.Linq;
using Newtonsoft.Json.Utilities;

namespace Tripledot.FlappyBird.Leaderboard.Domain.Model
{
    public class Leaderboard
    {
        public readonly DateTime Start;
        public readonly DateTime End;
        public readonly LeaderboardPlayerData[] PlayersData;

        public Leaderboard(DateTime start, DateTime end,
            LeaderboardPlayerData[] playersData)
        {
            Start = start;
            End = end;
            PlayersData = playersData;
        }

        public static Leaderboard Empty()
        {
            return new Leaderboard(DateTime.Now,
                DateTime.Now.AddDays(1),
                new LeaderboardPlayerData[] { });
        }

        public Leaderboard RegisterPlayerScore(string name, int score)
        {
            return new Leaderboard(Start,
                End,
                AddOrUpdatePlayer(name, score)
            );
        }

        public LeaderboardPlayerData[] GetTopTenPlayers() =>
            PlayersData
                .OrderByDescending(playerInfo => playerInfo.Score.Current)
                .Take(10)
                .ToArray();

        public bool IsNewRecord(int score) => LeaderboardIsEmpty() || IsHigherThanTopTenScores(score);

        private bool IsHigherThanTopTenScores(int score)
        {
            return GetTopTenPlayers()
                .Any(player => score > player.Score.Current);
        }

        private bool LeaderboardIsEmpty()
        {
            return PlayersData.Length == 0;
        }

        private LeaderboardPlayerData[] AddOrUpdatePlayer(string name, int score)
        {
            var playerIndex = PlayersData.IndexOf(playerData => playerData.Name.Equals(name));

            if (playerIndex >= 0) {
                PlayersData[playerIndex] = PlayersData[playerIndex].SetScore(score);

                return PlayersData;
            }

            return PlayersData.Append(new LeaderboardPlayerData(name, name, new Score(score, score))).ToArray();
        }

#region EqualityMembers

        protected bool Equals(Leaderboard other)
        {
            return Start.Equals(other.Start) &&
                   End.Equals(other.End) &&
                   PlayersData.SequenceEqual(other.PlayersData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Leaderboard)obj);
        }

#endregion
    }
}