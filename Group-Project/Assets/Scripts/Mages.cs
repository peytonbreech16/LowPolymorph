using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mages : MonoBehaviour
{
    NavMeshAgent nma = null;
    public float walkDuration = 10;
    public Transform goal;
    public bool destinationReached;
    Animator animator;
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        destinationReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!destinationReached && dialogue.startWalking)
        {
            animator.SetBool("startWalking", true);
            nma.destination = goal.position;
            walkDuration -= Time.deltaTime;
            if (walkDuration <= 0)
            {
                animator.Play("Praying");
                nma.enabled = false;
                destinationReached = true;
                
            }
        }
    }
}
