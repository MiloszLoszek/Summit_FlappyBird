using System;
using System.Collections.Generic;
using Tripledot.FlappyBird.Leaderboard.Presentation;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Tripledot.FlappyBird.Leaderboard.UnityDelivery.Views
{
    public class UnityLeaderboardView : MonoBehaviour, LeaderboardView
    {
        [SerializeField]
        private Button backButton;
        [SerializeField]
        private Transform cellContainer;
        [SerializeField]
        private CellTextView cellTextPrefab;

        private LeaderboardPresenter presenter;
        private List<CellTextView> currentGridContent = new List<CellTextView>();

        private CompositeDisposable disposables = new CompositeDisposable();

        public void Init(Action onBack)
        {
            presenter = new LeaderboardPresenter(this, DependencyManager.Instance.LeaderboardService);

            backButton.OnClickAsObservable()
                .Do(_ => onBack())
                .Subscribe()
                .AddTo(disposables);
        }

        private void OnDestroy()
        {
            disposables.Clear();
        }

        public void Show()
        {
            presenter.Load();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ShowLeaderboardWith(Domain.Model.Leaderboard leaderboard)
        {
            ClearGrid();

            foreach (var playerInfo in leaderboard.GetTopTenPlayers()) {
                AddCellWith(playerInfo.Name);
                AddCellWith(playerInfo.Score.Current.ToString());
                AddCellWith(playerInfo.Score.Past.ToString());
            }
        }

        private void AddCellWith(string text)
        {
            var cell = Instantiate(cellTextPrefab, cellContainer);
            cell.SetWith(text);
            currentGridContent.Add(cell);
        }

        private void ClearGrid()
        {
            currentGridContent.ForEach(cell => Destroy(cell.gameObject));
            currentGridContent.Clear();
        }
    }
}