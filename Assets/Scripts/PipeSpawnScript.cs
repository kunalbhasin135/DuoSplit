using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime * 0.00001f;
        spawnRate -= speedMultiplier;
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

        if (spawnRate < 0.5)
        {
            spawnRate = 0.5f;
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}