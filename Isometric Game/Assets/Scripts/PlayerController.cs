using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float speed = 1.5f;

    [SerializeField] GameManager gameManagerScript;

    [SerializeField] GameObject weaponPrefab;

    private Rigidbody2D playerRb;

    public Vector2 currentDirection;

    private Vector3 currentPos;

    private bool withBoomerang = true;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        currentDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (!gameManagerScript.gameOver)
        {
            Move();

            Attack();
        }
    }

    private void Move()
    {
        playerRb.velocity = currentDirection.normalized * speed;
    }

    private void Attack()
    {
        //boomerangPos.position = currentPosition.position + offset;

        if (Input.GetKeyDown(KeyCode.Space) && withBoomerang)
        {
            Instantiate(weaponPrefab, transform);
        }
    }
}
