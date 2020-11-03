using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public bool enter;
    public AudioSource source;

    // Use this for initialization
    void Start()
    {
        enter = false;
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && enter == false)
        {
            enter = true;
            // Play the sound only on the trigger
            source.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        source.Pause();
    }
}
