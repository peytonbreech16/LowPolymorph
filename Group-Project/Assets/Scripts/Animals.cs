using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public GameObject animal;
    public GameObject person;
    public bool dispelled;
    // Start is called before the first frame update
    void Start()
    {
        dispelled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dispelled)
        {
            animal.SetActive(false);
            person.SetActive(true);
        }
    }    
}
