using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispel : MonoBehaviour
{
    public Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) 
    {
        if (other.tag == "Animal")
        {
            other.GetComponent<Animals>().dispelled = true;
        }

        if (other.tag == "Boss" && boss.dead)
        {
            boss.bossDragon.SetActive(false);
            boss.bossHuman.SetActive(true);
            boss.dispelled = true;
        }
    }
}
