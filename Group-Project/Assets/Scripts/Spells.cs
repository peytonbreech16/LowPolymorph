using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    GameObject flames;
    GameObject dispel;
    GameObject freeze;
    public float fireRateFlames = 2f;
    private float nextFireFlames = 0.5f;
    public float fireRateDispel = 2f;
    private float nextFireDispel = 0.5f;
    public float fireRateFreeze = 2f;
    private float nextFireFreeze = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        flames = Resources.Load("Flames") as GameObject;
        dispel = Resources.Load("Dispel") as GameObject;
        freeze = Resources.Load("Freeze") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //LMB clicked, cast flames spell
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireFlames)
        {
            nextFireFlames = Time.time + fireRateFlames;
            GameObject Flames = Instantiate(flames) as GameObject;
            Flames.transform.position = transform.position + Camera.main.transform.forward;
            Flames.transform.rotation = Camera.main.transform.rotation;
        }
        //RMB clicked, cast dispel spell
        if (Input.GetMouseButtonDown(1) && Time.time > nextFireDispel)
        {
            nextFireDispel = Time.time + fireRateDispel;
            GameObject Dispel = Instantiate(dispel) as GameObject;
            Dispel.transform.position = transform.position + Camera.main.transform.forward * 5;
            Dispel.transform.rotation = Camera.main.transform.rotation;
        }
        //F key pressed, cast freeze spell
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextFireFreeze)
        {
            nextFireFreeze = Time.time + fireRateFreeze;
            GameObject Freeze = Instantiate(freeze) as GameObject;
            Freeze.transform.position = transform.position + Camera.main.transform.forward * 2;
            Freeze.transform.rotation = Camera.main.transform.rotation;
            
        }
    }
}