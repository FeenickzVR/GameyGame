using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private float spawnRate;
    public float spawnDelay;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    GameObject enemyClone;
    float x;


    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = spawnRate;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {


    }

    private IEnumerator Spawner()
    {

        while (canSpawn)
        {

                if (spawnDelay > 0.1)
                {
                spawnDelay -= 0.05f;
                }
                yield return new WaitForSeconds(spawnDelay);

            x = player.transform.position.x;

            Vector2 spawnPos = new Vector2(Random.Range(x - 4, x + 4f), 5);
            enemyClone = Instantiate(enemyPrefabs, spawnPos, Quaternion.identity);
            enemyClone.transform.Rotate(0, 0, 180);

            Destroy(enemyClone, 2.5f);

        }
    }

}
