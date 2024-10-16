using UnityEngine;

public class CanvasGameStart : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            gameManager.RestartGame();
        }
    }
}
