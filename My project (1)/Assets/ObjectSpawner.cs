using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField]GameObject player;
    const float betweenSpawnStart = 5f;
    float betweenSpawn = betweenSpawnStart;
    float timer;
    float deviation = 3f;
    float exponential = 1f;
    int counter = 0;
    int spawnrate = 1;
    [SerializeField]GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + betweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            //Creating the object
            timer = Time.time + betweenSpawn;
            spawner();
                
        }
    }

    void spawner()
    {
        float xSpawn = Random.Range(player.transform.position.x - deviation, player.transform.position.x + deviation);
        Instantiate(projectile, new Vector2(xSpawn, transform.position.y), projectile.transform.rotation);
        betweenSpawn -= exponential;
        //counter++;
    }
}
