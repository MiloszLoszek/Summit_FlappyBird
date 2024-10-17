using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float backgroundSpeed = 2f; // Speed at which the background moves
    public SpriteRenderer[] backgrounds; // Array of sprite renderers for the backgrounds
    public float backgroundWidth; // Width of e

    void Start()
    {
        // If backgroundWidth is not set, calculate it based on the first sprite renderer's bounds
        if (backgroundWidth == 0 && backgrounds.Length > 0) {
            backgroundWidth = backgrounds[0].bounds.size.x - 0.1f;
        }
    }

    void Update()
    {
        // Scroll each background to the left
        foreach (var background in backgrounds) {
            background.transform.Translate(Vector2.left * backgroundSpeed * Time.deltaTime);

            // If the background moves off-screen to the left, reposition it to the right
            if (background.transform.position.x < GetLeftBoundary()) {
                RepositionBackground(background);
            }
        }
    }

    // Get the left boundary (this is where we will reposition the backgrounds)
    private float GetLeftBoundary()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(-0.5f, 0, 0)).x - (backgroundWidth / 2); // Ensure it accounts for half the width
    }

    // Reposition the background to the right side of the last background
    private void RepositionBackground(SpriteRenderer background)
    {
        // Find the rightmost background
        SpriteRenderer rightmostBackground = GetRightmostBackground();

        // Position the current background exactly to the right of the rightmost background
        float newXPosition = rightmostBackground.transform.position.x + backgroundWidth;
        background.transform.position = new Vector3(newXPosition, background.transform.position.y, background.transform.position.z);
    }

    // Find the background sprite that is currently the farthest to the right
    private SpriteRenderer GetRightmostBackground()
    {
        SpriteRenderer rightmost = backgrounds[0];
        foreach (var background in backgrounds) {
            if (background.transform.position.x > rightmost.transform.position.x) {
                rightmost = background;
            }
        }
        return rightmost;
    }
}