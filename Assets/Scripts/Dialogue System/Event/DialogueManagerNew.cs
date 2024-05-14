using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManagerNew : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI name;
    public TextMeshProUGUI textDia;
    public float textSpeed;
    public Queue<string> sentences;

    private bool isTyping = false;
    private string currentSentence;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();
    private bool isDialogueRunning = false;

    public GameObject decisionPanel;
    public Button yesButton;
    public Button noButton;
    private Decision currentDecision;
    private bool whileDecision;

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
            Debug.LogError("DialogueBox GameObject not found in the scene with the 'DialogueBox' tag.");
        }
        textDia.text = string.Empty;

        whileDecision = false;
        decisionPanel.SetActive(false);
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                textDia.text = currentSentence;
                isTyping = false;
            }
            else
            {
                if (sentences.Count > 0)
                {
                    NextLine();
                }
                else
                {
                    EndConversation();
                }
            }
        }
    }

    private void OnYesButtonClicked()
    {
        decisionPanel.SetActive(false);
        whileDecision = false;
        if (currentDecision != null)
        {
            NextLine();
            currentDecision.OnDecisionMade(true);
        }
    }

    private void OnNoButtonClicked()
    {
        decisionPanel.SetActive(false);
        whileDecision = false;
        if (currentDecision != null)
        {
            NextLine();
            currentDecision.OnDecisionMade(false);
        }
    }

    public void StartDecision(Decision decisionEvent)
    {
        currentDecision = decisionEvent;
        dialogueQueue.Enqueue(currentDecision.dialogueWhileDecision);
        whileDecision = true;
        currentDecision = decisionEvent;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueQueue.Enqueue(dialogue);
        if (!isDialogueRunning)
        {
            ProcessNextDialogue();
        }
    }

    private void ProcessNextDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            isDialogueRunning = true;
            Dialogue dialogue = dialogueQueue.Dequeue();
            dialogueBox.SetActive(true);
            name.text = dialogue.name;
            sentences.Clear();
            foreach (string s in dialogue.sentences)
            {
                sentences.Enqueue(s);
            }
            NextLine();
        }
        else if (whileDecision)
        {
            decisionPanel.SetActive(true);
        }
        else
        {
            isDialogueRunning = false;
            dialogueBox.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        currentSentence = sentences.Dequeue();
        textDia.text = string.Empty;
        foreach (char c in currentSentence.ToCharArray())
        {
            textDia.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
        if (sentences.Count == 0 && whileDecision)
        {
            decisionPanel.SetActive(true);
        }
    }

    private void NextLine()
    {
        textDia.text = string.Empty;
        if (sentences.Count > 0)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndConversation();
        }
    }

    void EndConversation()
    {
        ProcessNextDialogue();
    }
}