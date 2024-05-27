using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    [SerializeReference]
    public List<Event> events = new();

    public Dialogue dialogue;

    bool detect_player = false;
    int currentIndex = 0;
    bool hasLoggedEndGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         //method 1
        if (Input.GetKeyDown(KeyCode.E) && detect_player && events.Count > currentIndex)
        {
            Event currentEvent = events[currentIndex];
            Debug.Log("press e");

            currentEvent.Execute(currentIndex, FindObjectOfType<DialogueManagerNew>(), this);
            
            detect_player = false;

        }

        if (!hasLoggedEndGame && events.Count > 0 && currentIndex == events.Count)
        {
            var lastEvent = events[events.Count - 1];
            if (lastEvent.GetType() == typeof(NextLevel))
            {
                // Add here
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
                Debug.Log("end game");
                hasLoggedEndGame = true;
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

    public void UpdateSeq(int newIndex)
    {
        currentIndex = newIndex;
        Debug.Log("Updated sequence to: " + currentIndex);
    }
}
