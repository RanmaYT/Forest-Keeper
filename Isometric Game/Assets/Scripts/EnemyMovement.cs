using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    public float speed = 2.0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform ;
    }

    void FixedUpdate()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);    
        }
    }
}
