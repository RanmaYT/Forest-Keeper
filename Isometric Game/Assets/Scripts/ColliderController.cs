using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderController : MonoBehaviour
{
    private TilemapRenderer spriteRend;

    public bool collisionShowing = false;
    
    void Start()
    {
        spriteRend = GetComponent<TilemapRenderer>();
        spriteRend.enabled = collisionShowing;
    }
}
