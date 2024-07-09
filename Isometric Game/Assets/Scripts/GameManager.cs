using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    Vector3 spawnPos = new Vector3(10, 4.5f, 0);

    float spawnRate;
    int spawnCount;

    int randomNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawner", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //randomNumber = Random.Range(0, spawnPos.Length);
        if (spawnCount > 10)
        {
            CancelInvoke("EnemySpawner");
        }
    }

    void EnemySpawner()
    {
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawnCount++;
    }
}
