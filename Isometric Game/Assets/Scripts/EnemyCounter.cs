using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] AudioSource endSound;

    public GameObject[] enemies;
    public int enemiesAlive;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesAlive = enemies.Length;

        if(enemiesAlive == 0)
        {
            endSound.Play();
        }
    }
}
