using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossMovement : EnemyMovement
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        speed *= 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
}
