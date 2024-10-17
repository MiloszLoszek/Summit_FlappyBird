using UnityEngine;
using UnityEngine.UI;

public class ImageSpinnerUI : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100.0f;
    
    [SerializeField]
    private Image spriteRenderer;

    private float rainbowTimer = 0.0f;

    private void Start()
    {
        spriteRenderer.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation of image
        gameObject.transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);

        RainbowColorTime(Time.deltaTime);
    }

    void RainbowColorTime(float deltatime)
    {
        //from RGB TO HUESV makes rainbow color EZ
        Color.RGBToHSV(spriteRenderer.color, out float h, out float s, out float v);
        
        //Go through whole spectrum of colors in 5ish seconds
        rainbowTimer += 50.0f * deltatime;
        if (rainbowTimer >= 360.0f) {
            rainbowTimer -= 360.0f;
        }
        h = rainbowTimer / 360.0f;
        spriteRenderer.color = Color.HSVToRGB(h, 1.0f, 1.0f, false);
    }
}
