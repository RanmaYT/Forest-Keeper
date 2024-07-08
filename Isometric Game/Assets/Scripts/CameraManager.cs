using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform target;
    private Vector3 offset = new Vector3(1, 0, -1);

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
       if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
