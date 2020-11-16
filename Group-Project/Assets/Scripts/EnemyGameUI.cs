using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGameUI : MonoBehaviour
{
    [SerializeField] Image UIHealth;
    public GameObject enemy;
    private float health;
    // Update is called once per frame
    void Start() 
    {
        health = enemy.GetComponent<Enemy>().health;
    }
    void Update()
    {
        health = enemy.GetComponent<Enemy>().health;
        UIHealth.fillAmount = health; 
    }
}
