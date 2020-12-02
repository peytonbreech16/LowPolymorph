using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float fireRateTeleport = 90f;
    private float nextFireTeleport = 0.5f;
    public Animator flamesCD;
    public Animator freezeCD;
    public Animator dispelCD;
    public Animator teleportCD;

    public AudioSource flamesSource;
    public AudioClip iceSFX;
    public AudioClip dispelSFX;
    public AudioClip[] flameSFXArray;
    private int clipIndex;

    // Start is called before the first frame update
    void Start()
    {
        flames = Resources.Load("Flames") as GameObject;
        dispel = Resources.Load("Dispel") as GameObject;
        freeze = Resources.Load("Freeze") as GameObject;
        nextFireTeleport = Time.time + fireRateTeleport;
        teleportCD.Play("TeleportCD");
    }

    // Update is called once per frame
    void Update()
    {
        //LMB clicked, cast flames spell
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireFlames)
        {
            PlayFireRoundRobin();
            flamesCD.Play("FlamesCD");
            nextFireFlames = Time.time + fireRateFlames;
            GameObject Flames = Instantiate(flames) as GameObject;
            Flames.transform.position = transform.position + Camera.main.transform.forward;
            Flames.transform.rotation = Camera.main.transform.rotation;
        }
        //D clicked, cast dispel spell
        if (Input.GetKeyDown(KeyCode.R) && Time.time > nextFireDispel)
        {
            dispelCD.Play("DispelCD");
            flamesSource.PlayOneShot(dispelSFX);
            nextFireDispel = Time.time + fireRateDispel;
            GameObject Dispel = Instantiate(dispel) as GameObject;
            Dispel.transform.position = transform.position + Camera.main.transform.forward * 5;
            Dispel.transform.rotation = Camera.main.transform.rotation;
        }
        //RMB key pressed, cast freeze spell
        if (Input.GetMouseButtonDown(1) && Time.time > nextFireFreeze)
        {
            freezeCD.Play("FreezeCD");
            flamesSource.PlayOneShot(iceSFX);
            nextFireFreeze = Time.time + fireRateFreeze;
            GameObject Freeze = Instantiate(freeze) as GameObject;
            Freeze.transform.position = transform.position + Camera.main.transform.forward; //* 5;
            Freeze.transform.rotation = Camera.main.transform.rotation;
            
        }
        //T key pressed, cast teleport spell to go back home
        if (Input.GetKeyDown(KeyCode.T) && Time.time > nextFireTeleport) //&& Time.time > nextFireTeleport)
        {
            SceneManager.LoadScene("Inside_Tower");
        }
    }

    void PlayFireRoundRobin()
    {

        if (clipIndex < flameSFXArray.Length)
        {
            flamesSource.PlayOneShot(flameSFXArray[clipIndex]);
            clipIndex++;
        }

        else
        {
            clipIndex = 0;
            flamesSource.PlayOneShot(flameSFXArray[clipIndex]);
            clipIndex++;
        }
    }
}