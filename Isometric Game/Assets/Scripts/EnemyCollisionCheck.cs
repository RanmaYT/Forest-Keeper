using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    [SerializeField] GameManager gameManagerScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManagerScript.gameOver = true;

            Destroy(collision.gameObject);

            Debug.Log("GAMEOVER");
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(gameObject);
        }
    }
}
