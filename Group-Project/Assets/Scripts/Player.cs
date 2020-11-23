using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 1f;
    public bool reset = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player dies
        if (health <= 0)
        {
            reset = true;
            SceneManager.LoadScene("GameOver");
        }
        /*
        //Player wins
        if (winCondition)
        {
            reset = true;
            SceneManager.LoadScene("WinScreen");
        }
        */
    }
}
