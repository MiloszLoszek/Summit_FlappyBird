using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 1.5f;
    [SerializeField]
    private float heightRange = 0.45f;
    [SerializeField]
    private GameObject pipe;

    private float timer;
    private float pipeSpeed;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > spawnInterval) {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        if (spawnInterval > .5f) {
            pipeSpeed += .1f;
            spawnInterval -= .1f;
        }
        
        var spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        var spawnedPipe = Instantiate(pipe, spawnPos, Quaternion.identity);
        spawnedPipe.GetComponent<PipeMover>().Speed = pipeSpeed;
        
        Destroy(spawnedPipe, 10f);
    }
}
