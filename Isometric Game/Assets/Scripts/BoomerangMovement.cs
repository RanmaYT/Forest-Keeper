using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoomerangMovement : MonoBehaviour
{
    // First I need to make the boomerang go away from the player based on which direction the player is facing;
    // After a certain time, I need to make the boomerang start to go back towards the player;

    // Additionals: When the boomerang hits something, he comes back more fast depending in how distant he was from the end of the timer;
    // Additionals²: When the boomerang is going away, he desaccelerate, but when he is coming back, he gots faster;

    [SerializeField] float timer = 0.5f;
    [SerializeField] float speed = 2.5f;

    [SerializeField] private PlayerAnimatorController playerAnimatorControllerScript;

    private Rigidbody2D boomerangRb;

    private void Awake()
    {
        boomerangRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            GoingAway();
        }
        else
        {
           // GoingBack();
        }
    }

    private void GoingAway()
    {
        boomerangRb.velocity = playerAnimatorControllerScript.lastDirection * speed;
        //timer = -Time.time;
    }

    private void GoingBack()
    {

    }
}
