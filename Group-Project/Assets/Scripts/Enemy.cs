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
    public float health;
    public bool dead;
    public GameObject healthBar;

    GameObject oozedeath;
    GameObject shelldeath;
    GameObject oozeattack;
    GameObject shellattack;

    bool deathSFX = false;
    bool attackSFX = false;
    public float timeRemaining = 5;

    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        oozedeath = Resources.Load("Oozedeath") as GameObject;
        shelldeath = Resources.Load("Shelldeath") as GameObject;
        oozeattack = Resources.Load("Oozeattack") as GameObject;
        shellattack = Resources.Load("Shellattack") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && attackSFX)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            attackSFX = false;
            timeRemaining = 5;
        }

        if (dead)
        {

        }
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

            if (!attackSFX)
            {
                GameObject Oozeattack = Instantiate(oozeattack) as GameObject;
                attackSFX = true;
            }
        }
        if (health <= 0)
        {
            dead = true;
            self.GetComponent<NavMeshAgent>().enabled = false;
            animator.Play("Die");
            healthBar.SetActive(false);

            if (!deathSFX)
            {
                GameObject Oozedeath = Instantiate(oozedeath) as GameObject;
                deathSFX = true;
            }
        }
    }
}
