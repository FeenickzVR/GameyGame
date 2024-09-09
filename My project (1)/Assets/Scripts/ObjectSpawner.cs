using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    GameObject enemyClone;
    float x;
    float waveTimer;
    int waveCount;
    public float minWaitTime = 0.1f; 
    public float maxWaitTime = 5f; 



    // Start is called before the first frame update
    void Start()
    {
        waveTimer -= Time.deltaTime;
        spawnRate = 1f;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        waveTimer -= Time.deltaTime;
        if (waveTimer <= 0)
        {
            waveCount++;
            waveTimer = 10;
        }

        
        
    }

    private IEnumerator Spawner()
    {
        float wait = Mathf.Clamp(spawnRate, minWaitTime, maxWaitTime);

        while (canSpawn)
        {
            yield return wait;

            x = player.transform.position.x;

            Vector2 spawnPos = new Vector2(Random.Range(x - 4, x + 4f), 5);
            enemyClone = Instantiate(enemyPrefabs, spawnPos, Quaternion.identity);
            enemyClone.transform.Rotate(0, 0, 180);
            

        }
    }

}
