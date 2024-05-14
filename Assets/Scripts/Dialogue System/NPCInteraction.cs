using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeReference]
    public List<Event> events = new();

    public Dialogue dialogue;

    bool detect_player = false;
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // method 1
        if (Input.GetKeyDown(KeyCode.E) && detect_player && events.Count > currentIndex)
        {
            Event currentEvent = events[currentIndex];
            Debug.Log("press e");

            currentEvent.Execute(currentIndex, FindObjectOfType<DialogueManagerNew>(), this);
            
            detect_player = false;

        }

        // original
        //if (detect_player && Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("trying to trigger dialogue");
        //    TriggerDialogue();

        //    // add the item at the end of dialogue
        //    //GameObject playerGameObject = GameObject.Find("Player");
        //    //if (playerGameObject != null)
        //    //{
        //    //    Player player = playerGameObject.GetComponent<Player>();
        //    //    player.inventory.AddfromItem(item);
        //    //}

        //    detect_player = false;
        //    if (gameObject.CompareTag("Fragment"))
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}

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

    public void UpdateSeq(int newIndex)
    {
        currentIndex = newIndex;
        Debug.Log("Updated sequence to: " + currentIndex);
    }
}
