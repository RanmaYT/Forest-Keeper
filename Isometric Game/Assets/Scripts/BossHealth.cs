using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{
    private void Start()
    {
        health = 10;
    }

    void Update()
    {
        Die();
    }
}
