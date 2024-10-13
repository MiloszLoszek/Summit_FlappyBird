namespace Tripledot.FlappyBird.Leaderboard.Infrastructure.DTOs
{
    public class ScoreDTO
    {
        public int current;
        public int past;

        public ScoreDTO()
        {
        }

        public ScoreDTO(int current, int past)
        {
            this.current = current;
            this.past = past;
        }

        public Domain.Model.Score ToScore() => new Domain.Model.Score(current, past);

        public static ScoreDTO From(Domain.Model.Score score)
        {
            return new ScoreDTO(
                score.Current,
                score.Past
            );
        }
    }
}