using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// code from: https://www.youtube.com/watch?v=8oTYabhj248

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI textDia;
    public float textSpeed;
    public Queue<string> sentences;

    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox = GameObject.FindWithTag("DialogueBox");
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
        else
        {
            Debug.LogError("1 DialogueBox GameObject not found in the scene with the 'DialogueBox' tag.");
        }
        textDia.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        // this key is what moves the dialogue forward (set to E right now since I'm not using a mouse)
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            if (textDia.text == lines[idx])
            {
                NextLine();
            }
        } else
        {
            StopAllCoroutines();
            textDia.text = lines[idx];
        }*/
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("here i am");
            if (sentences.Count > 0)
            {
                NextLine();

                //StartCoroutine(TypeLine());
            }
            else
            {
                EndConversation();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {

        dialogueBox.SetActive(true);

        Debug.Log("starting conversation with: " + dialogue.name);
        sentences.Clear();
        foreach (string s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }

        
    }

            // This creates type writer effect
            IEnumerator TypeLine()
            {
                foreach(char c in sentences.Dequeue().ToCharArray())
                {
                    textDia.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
                
                yield return new WaitForSeconds(textSpeed);
            }

    // This allows you to have a conversation, i.e. "how are you?" on one screen then switching to "I'm fine, thanks"
    private void NextLine()
    {
        if (sentences.Count > 0)
        {
            //textDia.text = sentences.Dequeue();
           textDia.text = string.Empty;
           StartCoroutine(TypeLine());
        } else
        {
            EndConversation();
            //gameObject.SetActive(false);
        }
    }

    void EndConversation()
    {
        
        dialogueBox.SetActive(false);
    }


}
