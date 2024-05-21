using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : Event
{
    public List<Dialogue> dialogueBeforeDecision;

    public Dialogue dialogueFirstDecision;
    public List<Dialogue> dialogueAfterFirstYesDecision;
    public List<Dialogue> dialogueAfterFirstNoDecision;

    public Dialogue dialogueSecondDecision;
    public List<Dialogue> dialogueAfterSecondYesDecision;
    public List<Dialogue> dialogueAfterSecondNoDecision;
    
    private DialogueManagerNew manager;
    private int nextSeq;
    private NPCInteraction interaction;
    private bool firstDecisionMade = false;

    public NextLevel() : base(EventType.Nextlevel) { }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        nextSeq = seq;
        interaction = npcInteraction;

        manager = dialogueManager;

        foreach (Dialogue dialogue in dialogueBeforeDecision)
        {
            manager.StartDialogue(dialogue);
        }
        manager.StartDialogue(dialogueFirstDecision);
    }

    public void OnFirstDecisionMade(bool decision)
    {
        if (decision)
        {
            firstDecisionMade = true;
            foreach (Dialogue dialogue in dialogueAfterFirstYesDecision)
            {
                manager.StartDialogue(dialogue);
                manager.StartDialogue(dialogueSecondDecision);
                manager.StartNextLevel(this);
            }
        }
        else
        {
            foreach (Dialogue dialogue in dialogueAfterFirstNoDecision)
            {
                manager.StartDialogue(dialogue);
            }
        }
    }

    private void OnSecondDecisionMade(bool decision)
    {
        if (decision)
        {
            foreach (Dialogue dialogue in dialogueAfterSecondYesDecision)
            {
                manager.StartDialogue(dialogue);
                interaction.UpdateSeq(nextSeq + 1);
            }
        }
        else
        {
            foreach (Dialogue dialogue in dialogueAfterSecondNoDecision)
            {
                manager.StartDialogue(dialogue);
            }
        }
    }
}
