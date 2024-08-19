using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField]GameObject player;
    const float betweenSpawnStart = 3f;
    float betweenSpawn = betweenSpawnStart;
    float timer;
    float deviation = 3f;
    float exponential = 0.5f;
    int counter = 0;
    int spawnrate = 0;
    public static int wave = 1;
    [SerializeField]GameObject projectile;
    [SerializeField]Rigidbody2D rb;

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

        while (spawnrate >= counter)
        {
            float xSpawn = Random.Range(player.transform.position.x - deviation, player.transform.position.x + deviation);
            Instantiate(projectile, new Vector2(xSpawn, transform.position.y), projectile.transform.rotation);
            counter++;
        }
        betweenSpawn -= exponential;
        if(betweenSpawn <= 0)
        {
            betweenSpawn = betweenSpawnStart - (wave/1.23f);
            wave++;
            spawnrate++;
            rb.gravityScale = rb.gravityScale * 1.12f;
            
        }
        counter = 0;
    }


}
