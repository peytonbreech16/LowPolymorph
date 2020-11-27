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

    public AudioSource a_AudioSource;
    public AudioClip voiceActing;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("I'm not setting Dialogue active 3");
            TextBox.SetActive(interactyn);
            UIUI.SetActive(!interactyn);
            dialogueActive = interactyn;
        }

        if (currentSentence >= sentences.Length)
        {
            Debug.Log("I'm not setting Dialogue active 2");
            startWalking = true;
            dialogueActive = false;
            currentSentence = 0;
            UIUI.SetActive(true);
            TextBox.SetActive(false);
        }

        dialogue.text = sentences[currentSentence];
        characterName.text = Name;
        interactText.SetActive(interactyn);

        if ((Input.GetKeyDown(KeyCode.E)) && dialogueActive == true)
        {
            currentSentence++;
            a_AudioSource.PlayOneShot(voiceActing);
            Debug.Log("The E key was pressed.");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactyn = true;
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
            
            UIUI.SetActive(true);
            TextBox.SetActive(false);
            dialogueActive = false;
            interactyn = false;
        }
    }
}
