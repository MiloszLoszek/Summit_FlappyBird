using System;
using Functional.Maybe;
using Newtonsoft.Json;
using Tripledot.FlappyBird.Leaderboard.Domain.Services;
using Tripledot.FlappyBird.Leaderboard.Infrastructure.DTOs;
using UniRx;

namespace Tripledot.FlappyBird.Leaderboard.Infrastructure.Services
{
    public class DiskLeaderboardService : LeaderboardService
    {
        private const string LeaderboardKey = "leaderboard";
        private readonly StorageService storageService;

        public DiskLeaderboardService(StorageService storageService)
        {
            this.storageService = storageService;
        }

        public IObservable<Domain.Model.Leaderboard> Get()
        {
            return Observable.Return(GetLeaderboard());
        }

        public IObservable<Unit> Submit(string name, int score)
        {
            var leaderboard = GetLeaderboard();
            var updatedLeaderboard = leaderboard.RegisterPlayerScore(name, score);
            var serializedLeaderboard = JsonConvert.SerializeObject(LeaderboardDTO.From(updatedLeaderboard));
            storageService.Save(LeaderboardKey, serializedLeaderboard);

            return Observable.ReturnUnit();
        }

        private Domain.Model.Leaderboard GetLeaderboard()
        {
            return storageService.Get(LeaderboardKey)
                .Select(leaderboardJson =>
                    JsonConvert.DeserializeObject<LeaderboardDTO>(leaderboardJson).ToLeaderboard())
                .OrElse(Domain.Model.Leaderboard.Empty());
        }
    }
}