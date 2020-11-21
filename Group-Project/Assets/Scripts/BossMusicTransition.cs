using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicTransition : MonoBehaviour
{

    public GameObject backgroundMusic;
    public GameObject bossMusic;
    AudioSource backSource;
    AudioSource bossSource;


    float bossVolume = 0.0f;
    float backVolume = 1.0f;
    public float volumeHeight = 0.6f;


    bool triggerEntered = false;
    bool check = false;

    void Start()
    {
        //set sources to sources of game objects in scene
        backSource = backgroundMusic.GetComponent<AudioSource>();
        bossSource = bossMusic.GetComponent<AudioSource>();

        //boss volume starts at 0, is silent
        bossVolume = 0;

        //volume height may be used later to create a master volume slider
        backVolume = volumeHeight;
    }

    private void Update()
    {
        //sorry it's all in update i tried to use coroutines but couldnt do it lol

        backSource.volume = backVolume;
        bossSource.volume = bossVolume;

        if (bossVolume > volumeHeight)
        {
            bossVolume = volumeHeight;
        }
        if (backVolume > volumeHeight)
        {
            backVolume = volumeHeight;
        }

        if (check)
        {
            if (triggerEntered)
            {
                if (backVolume > 0)
                {
                    backVolume -= 0.01f;
                }
                if (bossVolume < volumeHeight)
                {
                    bossVolume += 0.01f;
                }
                if (bossVolume >= volumeHeight)
                {
                    check = false;
                }
            }

            if (!triggerEntered)
            {
                if (bossVolume > 0)
                {
                    bossVolume -= 0.01f;
                }
                if (backVolume < volumeHeight)
                {
                    backVolume += 0.01f;
                }
                if (backVolume >= volumeHeight)
                {
                    check = false;
                }
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEntered = true;
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEntered = false;
            check = true;
        }
    }
}

