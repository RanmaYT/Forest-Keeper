using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class BoomerangCollisions : MonoBehaviour
{
    [SerializeField] BoomerangMovement boomerangMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && boomerangMovement.timer < 0.1)
        {
            Destroy(gameObject);
        }
    }
}
