using NSubstitute;
using NUnit.Framework;
using Tripledot.FlappyBird.Leaderboard.Domain.Services;
using Tripledot.FlappyBird.Leaderboard.Presentation;
using UniRx;
using static Tripledot.FlappyBird.Leaderboard.Scripts.Tests.Editor.Utils.LeaderboardMother;

namespace Tripledot.FlappyBird.Leaderboard.Scripts.Tests.Editor
{
    public class LeaderboardPresenterShould 
    {
        private LeaderboardPresenter presenter;
        private LeaderboardService leaderboardService;
        private LeaderboardView view;

        [SetUp]
        public void Setup()
        {
            view = Substitute.For<LeaderboardView>();
            leaderboardService = Substitute.For<LeaderboardService>();
            presenter = new LeaderboardPresenter(view, leaderboardService);

            leaderboardService.Get().Returns(Observable.Return(ALeaderboard()));
        }
        
        [Test]
        public void Load_Leaderboard()
        {
            WhenLoading();
            ThenLeaderboardIsLoaded();
        }

        [Test]
        public void Show_Leaderboard()
        {
            WhenLoading();
            ThenLeaderboardIsShown();
        }

        private void WhenLoading()
        {
            presenter.Load();
        }

        private void ThenLeaderboardIsLoaded()
        {
            leaderboardService.Received(1).Get();
        }

        private void ThenLeaderboardIsShown()
        {
            view.Received(1).ShowLeaderboardWith(Arg.Any<Domain.Model.Leaderboard>());
        }
    }
}
