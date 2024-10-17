using UnityEngine;

public class KillPlayerOutOfBounds : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float upperBoundOffset = 0.5f;

    private float upperBoundary;

    private void Start()
    {
        // Calculate the upper boundary based on the camera's viewport height
        upperBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + upperBoundOffset;
    }

    private void Update()
    {
        // Check if the player's Y position is above the upper boundary
        if (player.transform.position.y > upperBoundary) {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        Debug.Log("Player died after flying out of bounds!");
        GameManager.Instance.GameOver();
    }
}