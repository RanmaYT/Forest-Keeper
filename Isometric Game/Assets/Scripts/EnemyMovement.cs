using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;

    public float speed = 2.0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform ;
    }

    void FixedUpdate()
    {
        if(target != null)
        {
            EnemyMove();
        }
    }

    private void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
