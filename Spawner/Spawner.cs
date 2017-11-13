using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    private float spawnTime = 2f;
    public Transform[] spawnPoints;
    private int enemyCount = 0;
    public float diff = 30f;
    public float delaytime = 2f;



    void Start()
    {
       
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        diff -= Time.deltaTime;

        if (diff <= 0)
        {
            diff = 20f;
            delaytime -= 0.2f;
            
            if(delaytime <= 0)
            {
                delaytime = 0.2f;
            }
        }

        if (spawnTime <= 0)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject enemyC = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyCount++;
            spawnTime = delaytime;

            if (enemyCount == 20)
            {
               enemy.GetComponent<Enemy>().SetsTime(-0.1f);
               enemyCount = 0;
            }

        }
   
    }
}
