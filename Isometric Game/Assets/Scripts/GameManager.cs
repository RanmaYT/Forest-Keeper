using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject specialCollider;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TriggerCollider triggerColliderScript;
    [SerializeField] EnemyCounter enemyCounter;

    Vector3[] positions = new Vector3[12];


    float spawnRate = 1f;

    int spawnNumber;
    int spawnCount;
    int randomPosIndex;

    GameObject target;

    public int invokeCalled = 0;

    private void Awake()
    {
        positions[0] = new Vector3(10, 4.5f, 0);
        positions[1] = new Vector3(10.5f, 4.75f, 0);
        positions[2] = new Vector3(11, 5, 0);
        positions[3] = new Vector3(23, 4.5f, 0);
        positions[4] = new Vector3(23.5f, 4.25f, 0);
        positions[5] = new Vector3(24, 4, 0);

        positions[6] = new Vector3(-1, 15, 0);
        positions[7] = new Vector3(-0.5f, 14.75f, 0);
        positions[8] = new Vector3(0, 14.5f, 0);
        positions[9] = new Vector3(-10, 14.5f, 0);
        positions[10] = new Vector3(-9.5f, 14.75f, 0);
        positions[11] = new Vector3(-9, 15, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        whichInvoke();

        if (spawnCount == spawnNumber || target == null)
        {
            CancelInvoke("EnemySpawner");
        }

        if (enemyCounter.enemiesAlive == 0)
        {
            specialCollider.SetActive(false);
        }
        else
        {
            specialCollider.SetActive(true);
        }

        if(target == null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    void EnemySpawner()
    {
        spawnCount++;
        Instantiate(enemyPrefab, positions[randomPosIndex], Quaternion.identity);

        Invoke("EnemySpawner", Random.Range(0.5f, 1.5f));
    }

    void BossSpawner()
    {
        Instantiate(bossPrefab, new Vector3(-27, 24, 0), Quaternion.identity);
    }

    void whichInvoke()
    {
        if(triggerColliderScript.whichTrigger == 1)
        {
            randomPosIndex = Random.Range(0, 6);
            if(invokeCalled == 0)
            {
                spawnNumber = Random.Range(10, 26);
                invokeCalled++;
                target.transform.position = new Vector3(22, -1.5f, 0);

                Invoke("EnemySpawner", spawnRate);
            }
        }

        if(triggerColliderScript.whichTrigger == 2)
        {
            randomPosIndex = Random.Range(6, 12);

            if (invokeCalled == 1)
            {
                spawnCount = 0;
                spawnNumber = Random.Range(20, 41);
                invokeCalled++;
                target.transform.position = new Vector3(0, 10, 0);

                Invoke("EnemySpawner", spawnRate);
            }
        }
        if(triggerColliderScript.whichTrigger == 3)
        {
            if (invokeCalled == 2)
            {
                invokeCalled++;
                Invoke("BossSpawner", 1);
            }
        }

    }
}
