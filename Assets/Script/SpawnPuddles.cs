using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPuddles : MonoBehaviour
{


    public GameObject puddlePrefab;
    public float beginSpawnTime = 8.0f;
    public float spawnTimeInterval = 5.0f;
    public Vector2[] puddleSpawnsPoints;



    void Start()
    {
        InvokeRepeating("SpawnPuddle", beginSpawnTime, spawnTimeInterval);
    }


    void SpawnPuddle() 
    {
        Vector2 spawnPoint = puddleSpawnsPoints[Random.Range(0, puddleSpawnsPoints.Length)];
        GameObject obj = Instantiate(puddlePrefab, spawnPoint, Quaternion.identity);
        Destroy(obj, 5.0f);

    }


}
