using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject [] animals = new GameObject [0];
    public static bool [] animalsDispelled = new bool [3];
    public GameObject [] enemies = new GameObject [0];
    public static bool [] enemyDead = new bool [24];
    public GameObject [] mages = new GameObject [3];
    public static bool gameReset;
    public bool gateb = false;
    public Player player;
    public GameObject gate;
    public GameObject gateAmbient;
    public GameObject gateSFX;
    public Boss boss;
    public float bossDuration = 3;
    // Start is called before the first frame update
    void Start()
    {
        //Check what enemies are already dead
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemyDead[i])
            {
                enemies[i].SetActive(false);
            }
        }

        //Check what animals have been dispelled
        for (int i = 0; i < animals.Length; i++)
        {
            if (animalsDispelled[i])
            {
                animals[i].SetActive(false);
                mages[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.reset)
        {
            //if enemy dies, set their global dead value to true so they do not respawn
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<Enemy>().dead)
                {
                    enemyDead[i] = true;
                }
            }

            //if animal has been dispelled, set their global dispelled avlue to true so they do not respawn
            for (int i = 0; i < animals.Length; i++)
            {
                if (animals[i].GetComponent<Animals>().dispelled)
                {
                    animalsDispelled[i] = true;
                }
            }

            //if all 3 animals dipselled, open gate
            if (animalsDispelled[0] && animalsDispelled[1] && animalsDispelled[2])
            {
                gateb = true;
            }

            if (boss.dispelled)
            {
                bossDuration -= Time.deltaTime;
                if (bossDuration <= 0)
                {
                    SceneManager.LoadScene("Win Screen");
                }

                else if (bossDuration <= 1)
                {
                    Reset();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gateb)
        {
            gateAmbient.SetActive(false);
            gate.SetActive(false);
            gateSFX.SetActive(true);
        }
    }

    //reset all static variables such as wizards being dispelled and enemies that were slain
    public void Reset()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<Enemy>().dead)
            {
                enemyDead[i] = false;
                enemies[i].GetComponent<Enemy>().dead = false;
            }
        }

        for (int i = 0; i < animals.Length; i++)
        {
            if (animals[i].GetComponent<Animals>().dispelled)
            {
                animalsDispelled[i] = false;
                animals[i].GetComponent<Animals>().dispelled = false;
            }
        }

        //Check what enemies are already dead
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemyDead[i])
            {
                enemies[i].SetActive(true);
            }
        }

        //Check what animals have been dispelled
        for (int i = 0; i < animals.Length; i++)
        {
            if (!animalsDispelled[i])
            {
                animals[i].SetActive(true);
                mages[i].SetActive(false);
            }
        }
    }
}
