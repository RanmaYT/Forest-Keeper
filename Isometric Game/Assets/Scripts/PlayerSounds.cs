using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource walkingSound;

    bool isWalking;
    bool soundPlaying;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;

        if(!isWalking)
        {
            walkingSound.Stop();
            soundPlaying = false;
        }
        else if(!soundPlaying)
        {
            walkingSound.Play();
            soundPlaying = true;
        }
    }
}
