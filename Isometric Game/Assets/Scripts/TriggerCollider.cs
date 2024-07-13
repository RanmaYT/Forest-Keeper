using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] GameObject specialCollider;
    [SerializeField] GameObject barrierOne;
    [SerializeField] GameObject barrierTwo;

    public int whichTrigger = 0;
    public bool triggerOne;

    private void Update()
    {
        if(whichTrigger == 1)
        {
            barrierOne.SetActive(true);
        }

        if(whichTrigger == 2)
        {
            barrierTwo.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            whichTrigger++;
        }
    }
}
