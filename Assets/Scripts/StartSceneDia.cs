using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneDia : MonoBehaviour
{
    public Dialogue dialogue;
    private bool begin;
    
    public GameObject nextSceneButton;
    public GameObject textBox;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneButton.SetActive(false);
        begin = true;
    }
    private void Update()
    {
        if(begin)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
            
            begin = false;

        }
        if (!textBox.activeSelf)
        {
            Debug.Log("uhhhh");
            nextSceneButton.SetActive(true);
        }

    }

    // Update is called once per frame
}
