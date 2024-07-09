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

    [SerializeField] PlayerAnimatorController playerDir;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float acellaration = 0.2f;

    GameObject target;
    PlayerController playerController;
    int state = 1;

    public Rigidbody2D boomerangRb;
    public float timer = 0.64f;
    public Vector2 backDirection;

    private void Start()
    {
        boomerangRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        playerDir = GetComponentInParent<PlayerAnimatorController>();
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        backDirection = target.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if(state == 1)
        {
            Trown();
        }

        if(state == 2)
        {
            GoingBack();
        }
    }

    void Trown()
    {
        boomerangRb.velocity = (playerDir.lastDirection.normalized * speed);
        playerController.hasBoomerang = false;

        speed -= acellaration;
        timer -= Time.deltaTime;

        if(timer < 0.1)
        {
            state = 2;
            timer = 0.64f;
        }
    }

    public void GoingBack()
    {
        boomerangRb.velocity = (backDirection.normalized * speed);

        speed += acellaration;
        timer -= Time.deltaTime;

        if(timer < 0.1)
        {
            playerController.hasBoomerang = true;
        }
    }
}
