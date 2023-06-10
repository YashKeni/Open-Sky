using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI infoTextE;
    [SerializeField] public TextMeshProUGUI infoTextSpace;
    [SerializeField] public GameObject backgroundBox;
    [SerializeField] bool isPlayerNear;
    [SerializeField] DialogueTrigger trigger;

    bool hasInteracted = false;

    void Awake()
    {
        isPlayerNear = false;
        infoTextE.enabled = false;
        infoTextSpace.enabled = false;
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKey(KeyCode.E) && hasInteracted == false)
        {
            backgroundBox.transform.localScale = Vector3.one;
            trigger.StartDialogue();
            hasInteracted = true;
            infoTextE.enabled = false;
            infoTextSpace.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerNear = true;
            infoTextE.enabled = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerNear = false;
            infoTextE.enabled = false;
            infoTextSpace.enabled = false;
        }

    }
}
