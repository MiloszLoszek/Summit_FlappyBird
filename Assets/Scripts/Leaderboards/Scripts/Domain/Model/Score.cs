namespace Tripledot.FlappyBird.Leaderboard.Domain.Model
{
    public struct Score
    {
        public readonly int Current;
        public readonly int Past;

        public Score(int current, int past)
        {
            this.Current = current;
            this.Past = past;
        }

        public Score NewScore(int score) => new Score(score, Past);
    }
}