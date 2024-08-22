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
        timer = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time <= timer)
        {
            //Creating the object
            
            spawner();
            timer = Time.time;

        }
    }

    void spawner()
    {

        while (wave >= counter)
        {
            float xSpawn = Random.Range(player.transform.position.x - deviation, player.transform.position.x + deviation);
            Instantiate(projectile, new Vector2(xSpawn, transform.position.y), projectile.transform.rotation);
            counter++;
        }
        betweenSpawn -= exponential;
        if(betweenSpawn >= 15)
        {
            betweenSpawn = betweenSpawnStart - (wave/1.23f);
            wave++;
            spawnrate++;
            rb.gravityScale = rb.gravityScale * 1.12f;
            timer = Time.time - betweenSpawn;
        }
        counter = 0;
    }


}
