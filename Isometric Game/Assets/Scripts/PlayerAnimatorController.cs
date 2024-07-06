using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public float coyoteTime = 1.0f;

    private bool isWalking;
    public bool isOnCoyoteTime;
    
    [SerializeField] private Animator playerAnimator;

    [SerializeField] private PlayerController playerController;

    public Vector2 lastDirection = Vector2.zero;
    public Vector2 currentDirection = Vector2.zero;

    void Update()
    {

        if (lastDirection != currentDirection && !isOnCoyoteTime && isWalking)
        {
            isOnCoyoteTime = true;
            Invoke(nameof(StopWaiting), coyoteTime);
        }

        currentDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        WalkingChecking();
        DirectionChecking();
        AnimPosition();

        //if(!isWalking && isOnCoyoteTime)
        //{
        //    CancelInvoke(nameof(StopWaiting));
        //}
    }

    private void AnimPosition()
    {
        playerAnimator.SetFloat("x", currentDirection.x);
        playerAnimator.SetFloat("y", currentDirection.y);
    }
    
    private void WalkingChecking()
    {
        isWalking = currentDirection.magnitude > 0;
        playerAnimator.SetBool("Walking", isWalking);

        //isDiagonally =  
        //playerAnimator.SetBool("")
    }

    private void DirectionChecking()
    {
        if (isWalking)
        {
            playerAnimator.SetFloat("lastMoveX", lastDirection.x);
            playerAnimator.SetFloat("lastMoveY", lastDirection.y);
        } 
    }

    private void StopWaiting()
    {
        if (isWalking && lastDirection != currentDirection)
        {
            lastDirection = currentDirection;
        }

        isOnCoyoteTime = false;
    }
}
