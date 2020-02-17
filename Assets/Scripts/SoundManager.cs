using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource walkingSound;//, doorOpeningSound, doorClosingSound;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        playSound();
    }

    public void playSound()
    {
        if(FlagsManager.getFlag(0))
        {
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
            
        }

    }
}
