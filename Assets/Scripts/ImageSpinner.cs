using UnityEngine;

public class ImageSpinner : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100.0f;
    
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        //rotation of image
        gameObject.transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);

        //RainbowColorTime(Time.deltaTime);
    }

    void RainbowColorTime(float deltatime)
    {
        //from RGB TO HUESV
        Debug.Log("color of sprite before: " + spriteRenderer.color);
        Color.RGBToHSV(spriteRenderer.color, out float h, out float s, out float v);
        v += deltatime;
        if (v > 1.0f) {
            v -= 1.0f;
        }
        
        spriteRenderer.color = Color.HSVToRGB(h, s, v);
        Debug.Log("color of sprite after: " + spriteRenderer.color);
    }
}
