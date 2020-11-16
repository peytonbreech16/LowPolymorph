using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flames : MonoBehaviour
{
    private Animator animator;
    public GameObject slime;
    void Start() 
    {

    }
    void Update() 
    {

    }
    //Collision for the flames spell to register on enemies.
    private void OnParticleCollision(GameObject other) 
    {
        if (other.tag == "Slimes")
        {
            animator = other.GetComponent<Animator>();
            //animator.SetBool("Chasing", false);
            //animator.SetBool("Attacking", false);
            other.GetComponent<Enemy>().health -= 0.01f;
        }

        if (other.tag == "Shells")
        {
            animator = other.GetComponent<Animator>();
            //animator.SetBool("Chasing", false);
            //animator.SetBool("Attacking", false);
            other.GetComponent<Enemy>().health -= 0.005f;
        }
    }
}
