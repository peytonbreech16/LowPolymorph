using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject interactText;
    public bool interactyn = false;
    public GameObject TextBox;
    public GameObject UIUI;
    public bool dialogueActive = false;
    public Text dialogue;
    public string Name;
    public Text characterName;
    public bool startWalking = false;

    public string[] sentences;
    public int currentSentence;
    public Collider collider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactyn)
        {
            TextBox.SetActive(true);
            UIUI.SetActive(false);
            dialogueActive = interactyn;
        }

        if (currentSentence >= sentences.Length)
        {
            startWalking = true;
            dialogueActive = false;
            currentSentence = 0;
        }

        dialogue.text = sentences[currentSentence];
        characterName.text = Name;
        interactText.SetActive(interactyn);


        if (!dialogueActive)
        {
            UIUI.SetActive(true);
            TextBox.SetActive(false);
        }


        if ((Input.GetKeyDown(KeyCode.E)) && dialogueActive == true)
        {
            currentSentence++;
            Debug.Log("The E key was pressed.");
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactyn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (startWalking)
            {
                collider.enabled = false;
            }
            dialogueActive = false;
            interactyn = false;
        }
    }
}
