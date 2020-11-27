using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Freeze : MonoBehaviour
{
    private Animator animator;
    public GameObject slime;
    Enemy enemy;

    void Start() 
    {

    }
    void Update() 
    {

    }
    //Collision for the flames spell to register on enemies.
    private void OnParticleCollision(GameObject other) 
    {
        enemy = other.GetComponent<Enemy>();
        if (other.tag == "Slimes" && !enemy.dead)
        {
            enemy.frozen = true;
            other.GetComponent<NavMeshAgent>().enabled = false;
            animator = other.GetComponent<Animator>();
            animator.SetBool("Chasing", false);
            animator.SetBool("Attacking", false);
            animator.Play("SlimeFreeze");
        }

        if (other.tag == "Shells" && !enemy.dead)
        {
            enemy = other.GetComponent<Enemy>();
            enemy.frozen = true;
            other.GetComponent<NavMeshAgent>().enabled = false;
            animator = other.GetComponent<Animator>();
            animator.SetBool("Chasing", false);
            animator.SetBool("Attacking", false);
            animator.Play("ShellFreeze");
        }

        if (other.tag == "Boss" && !enemy.dead)
        {
            enemy = other.GetComponent<Enemy>();
            enemy.frozen = true;
            other.GetComponent<NavMeshAgent>().enabled = false;
            animator = other.GetComponentInChildren<Animator>();
            animator.SetBool("Chasing", false);
            animator.SetBool("Attacking", false);
            animator.Play("BossFreeze");
        }
    }
}
