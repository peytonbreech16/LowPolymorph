using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spellbook : MonoBehaviour
{
    public GameObject SpellbookUI;
    public GameObject interactText;
    bool nearby = false;
    public bool active = false;

    void Update()
    {
        if (nearby)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpellbookUI.SetActive(!(SpellbookUI.activeInHierarchy));
                interactText.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearby = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            nearby = false;
        }
    }
}
