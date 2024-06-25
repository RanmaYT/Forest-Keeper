using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    [SerializeField]float speed = 1.5f;

    public Rigidbody2D playerRb;

    public Vector2 currentDirection;

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
        Move();
    }

    private void Move()
    {
        playerRb.velocity = currentDirection.normalized * speed;
    }
}
