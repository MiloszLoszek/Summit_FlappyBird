using System;
using UniRx;

namespace Tripledot.FlappyBird.Leaderboard.Domain.Services
{
    public interface LeaderboardService
    {
        IObservable<Model.Leaderboard> Get();
        IObservable<Unit> Submit(string name, int score);
    }
}