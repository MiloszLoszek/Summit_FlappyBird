using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    private const string PlayerTagKey = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PlayerTagKey)) {
            Score.Instance.UpdateScore();
        }
    }
}
