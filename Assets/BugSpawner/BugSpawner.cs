using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bugToSpawn;
    public float spawnTime;
    private float realSpawnTime;
    void Start()
    {
        realSpawnTime = spawnTime;
    }
    //Spawns a bug on a fixed interval. 
    void Update()
    {
        realSpawnTime -= Time.deltaTime;
        if(realSpawnTime <= 0)
        {
            Spawn();
            realSpawnTime = spawnTime;
        }
        
    }
    void Spawn()
    {
        Instantiate(bugToSpawn, this.transform.position, Quaternion.Euler(0,0,0));
    }
}
