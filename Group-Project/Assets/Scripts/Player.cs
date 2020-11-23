using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 1f;
    public bool reset = false;
    public bool touchingDoor;
    public GameObject exitText;
    // Start is called before the first frame update
    void Start()
    {
        touchingDoor = false;
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

        //if player is touching tower door
        if (touchingDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Overworld");
            }
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

    //if touching tower door
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Door") 
        {
            exitText.SetActive(true);
            touchingDoor = true;
        }
    }
    //if no longer touching tower door
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Door") 
        {
            exitText.SetActive(false);
            touchingDoor = false;
        }
    }
}
