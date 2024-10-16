using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField]
    private float defaultSpeed = 0.65f;

    private float speed;

    public float Speed {
        set => speed = value < defaultSpeed ? defaultSpeed : value;
    }

    private void Update()
    {
        var actualSpeed = defaultSpeed + speed;
        transform.position += Vector3.left * (actualSpeed * Time.deltaTime);
    }
}
