using Tripledot.FlappyBird.Leaderboard.Domain.Services;
using UniRx;

namespace Tripledot.FlappyBird.Leaderboard.Presentation
{
    public class LeaderboardPresenter
    {
        private readonly LeaderboardView view;
        private readonly LeaderboardService leaderboardService;

        public LeaderboardPresenter(LeaderboardView view, LeaderboardService leaderboardService)
        {
            this.view = view;
            this.leaderboardService = leaderboardService;
        }

        public void Load()
        {
            leaderboardService.Get()
                .Do(leaderboard => view.ShowLeaderboardWith(leaderboard))
                .Subscribe();
        }
    }
}