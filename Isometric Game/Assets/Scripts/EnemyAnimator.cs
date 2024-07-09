using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;

    Transform target;
    bool isMoving;

    public float directionX;
    public float directionY;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            directionX = target.position.x - transform.position.x; // DirectionX < 0 -> andando pra direita;
            directionY = target.position.y - transform.position.y; // DirectionY < 0 -> andando pra cima;

            isMoving = true;

            enemyAnimator.SetBool("isMoving", isMoving);
            enemyAnimator.SetFloat("x", directionX);
            enemyAnimator.SetFloat("y", directionY);
            
        }
        else
        {
            isMoving = false;
            enemyAnimator.SetBool("isMoving", isMoving);
        }

        
    }
}
