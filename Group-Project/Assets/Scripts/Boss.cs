using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Enemy enemy;
    public GameObject bossDragon;
    public GameObject bossHuman;
    public Animator animator;
    public bool dead;
    public bool dispelled;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        dispelled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.health <= 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            dead = true;
        }
    }
}
