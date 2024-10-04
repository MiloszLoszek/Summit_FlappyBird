using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float maxTime = 1.5f;
    [SerializeField]
    private float heightRange = 0.45f;
    [SerializeField]
    private GameObject pipe;

    private float timer;
    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > maxTime) {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        var spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        var spawnedPipe = Instantiate(pipe, spawnPos, Quaternion.identity);
        
        Destroy(spawnedPipe, 10f);
    }
}
