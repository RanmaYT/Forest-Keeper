using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    
    private Rigidbody2D enemyRb;

    [SerializeField] GameManager gameManagerScript;

    [SerializeField] Transform player;

    void FixedUpdate()
    {
        if (!gameManagerScript.gameOver)
        {
            EnemyMove();
        }
    }

    private void EnemyMove()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
