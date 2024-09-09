using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    float x;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            x = player.transform.position.x;

            Vector2 spawnPos = new Vector2(Random.Range(x - 4, x + 4f), 5);
            Instantiate(enemyPrefabs, spawnPos, Quaternion.identity);
        }
    }
}
