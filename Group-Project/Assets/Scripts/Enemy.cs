using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nma = null;
    private float dist;
    private Transform player;
    public float howClose;
    public Animator animator;
    public GameObject self;
    public int health;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        //if player leaves enemy chase range
        if (dist > howClose && !dead)
        {
            //nma.SetDestination()
        }
        //if player enters enemy chase range, chase player
        if (dist <= howClose && !dead)
        {
            animator.SetBool("Attacking", false);
            animator.SetBool("Chasing", true);
            nma.SetDestination(player.transform.position);
        }
        //if enemy is within melee range, then attack
        if (dist <= 3f && !dead)
        {
            //do damage
            animator.SetBool("Attacking", true);
            //animator.SetBool("Chasing", true);
        }
        if (health <= 0)
        {
            dead = true;
            self.GetComponent<NavMeshAgent>().enabled = false;
            animator.Play("Die");
        }
    }
}
