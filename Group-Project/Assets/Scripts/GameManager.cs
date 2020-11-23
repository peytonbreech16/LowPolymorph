using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject [] animals = new GameObject [0];
    public static bool [] animalsDispelled = new bool [3];
    public GameObject [] enemies = new GameObject [0];
    public static bool [] enemyDead = new bool [24];
    public static bool gameReset;
    public Player player;
    public GameObject gate;
    public GameObject gateAmbient;
    public GameObject gateSFX;
    // Start is called before the first frame update
    void Start()
    {
        gameReset = player.reset;
        if (!gameReset)
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
                }
            }
        }
        else
        {
            //Check what enemies are already dead
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemyDead[i])
                {
                    enemies[i].SetActive(true);
                }
            }

            //Check what animals have been dispelled
            for (int i = 0; i < animals.Length; i++)
            {
                if (animalsDispelled[i])
                {
                    animals[i].SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
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

        //if animal 0 dispelled, wizard goes to rock
        if (animalsDispelled[0])
        {
            //wizard doing ritual animation
        }

        //if animal 1 dispelled, wizard goes to rock
        if (animalsDispelled[1])
        {
            //wizard doing ritual animation
        }

        //if animal 2 dispelled, wizard goes to rock
        if (animalsDispelled[2])
        {
            //wizard doing ritual animation
        }
        
        //if all 3 animals dipselled, open gate
        if (animalsDispelled[0] && animalsDispelled[1] && animalsDispelled[2])
        {
            gateAmbient.SetActive(false);
            gate.SetActive(false);
            gateSFX.SetActive(true);
        }

        //Check if game is reset
        gameReset = player.reset;
    }
}
