using TMPro;
using UnityEngine;

namespace Tripledot.FlappyBird.Leaderboard.UnityDelivery.Views
{
    public class CellTextView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI label;

        public void SetWith(string text)
        {
            label.text = text;
        }
    }
}