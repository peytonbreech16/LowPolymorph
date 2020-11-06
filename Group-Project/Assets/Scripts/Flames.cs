using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    void Start() 
    {
        
    }
    void Update() 
    {
        
    }
    //Collision for the flames spell to register on enemies.
    private void OnParticleCollision(GameObject other) 
    {
        if (other.tag == "Enemy")
        {
            Destroy(other);
        }
    }
}
