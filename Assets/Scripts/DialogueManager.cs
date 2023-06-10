using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    DialogueInitiator dialogueInitiator;
    DialogueTrigger dialogueTrigger;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    int activeOption;
    public static bool isActive = false;

    void Start()
    {
        dialogueInitiator = FindObjectOfType<DialogueInitiator>();
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    // Dialogue Part
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Convo Started: " + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Convo Ended!");
            isActive = false;
            DeactivateUI();
        }
    }

    //Deactivate UI Part
    private void DeactivateUI()
    {
        dialogueInitiator.backgroundBox.SetActive(false);
        dialogueInitiator.infoTextE.enabled = false;
        dialogueInitiator.infoTextSpace.enabled = false;
    }
}
