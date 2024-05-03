using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Dialogue dialogue;
    bool detect_player = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detect_player && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("trying to trigger dialogue");
            TriggerDialogue();
            detect_player = false;
            if (gameObject.CompareTag("Fragment"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player detected");
            detect_player = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            detect_player = false;
        }
    }

    private void TriggerDialogue()
    {
       
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
