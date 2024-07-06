using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameManager gameManagerScript;
    [SerializeField] private Transform playerPos;

    private Vector3 offset = new Vector3(1, 0, -1);

    void Update()
    {
        if(!gameManagerScript.gameOver)
        {
            transform.position = playerPos.position + offset;
        }
    }
}
