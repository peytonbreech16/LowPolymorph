using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image UIHealth;
    private GameObject player;
    private float health;
    // Update is called once per frame
    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Player>().health;
    }
    void Update()
    {
        health = player.GetComponent<Player>().health;
        UIHealth.fillAmount = health; 
    }
}
