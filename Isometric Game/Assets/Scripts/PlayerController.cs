using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    // This script is used to control the actions of the player, like movement and attack;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float speed = 1.5f;
    [SerializeField] GameObject boomerangPrefab;
    [SerializeField] AudioSource boomerangSound;
  
    private Rigidbody2D playerRb;

    public Vector2 currentDirection;
    public bool hasBoomerang = true;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        currentDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        // FixedUpdate is likely to be used when we are using physics, like movement.

        Move(); // Here we are getting the move function of the player.

        Attack();
    }

    private void Move()
    {
        playerRb.velocity = currentDirection.normalized * speed; // The "normalized" is used to make sure that the player when moving diagonally isn't faster.
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasBoomerang)
        {
            boomerangSound.Play();
            Instantiate(boomerangPrefab, transform);
        }
    }
}
