using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 1;
    public float timer = 0.2f;

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void Die()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            health--;
        }
    }
}
