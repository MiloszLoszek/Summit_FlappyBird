using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float velocity = 1.5f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private Rigidbody2D rigidbody2d;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            rigidbody2d.velocity = Vector2.up * velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigidbody2d.velocity.y * rotationSpeed);
    }
}
