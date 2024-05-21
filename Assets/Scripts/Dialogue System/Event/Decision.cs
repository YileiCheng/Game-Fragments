using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Decision : Event
{
    public List<Dialogue> dialogueBeforeDecision;
    public Dialogue dialogueWhileDecision;
    public List<Dialogue> dialogueAfterYesDecision;
    public List<Dialogue> dialogueAfterNoDecision;
    private DialogueManagerNew manager;
    private int nextSeq;
    private NPCInteraction interaction;

    public Decision() : base(EventType.DecisionEvent) {}

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        nextSeq = seq;
        interaction = npcInteraction;

        manager = dialogueManager;

        foreach (Dialogue dialogue in dialogueBeforeDecision)
        {
            manager.StartDialogue(dialogue);
        }
        //manager.StartDialogue(dialogueWhileDecision);
        manager.StartDecision(this);
    }

    public void OnDecisionMade(bool decision)
    {
        if (decision)
        {
            foreach (Dialogue dialogue in dialogueAfterYesDecision)
            {
                manager.StartDialogue(dialogue);
                interaction.UpdateSeq(nextSeq + 1);
            }
        }
        else
        {
            foreach (Dialogue dialogue in dialogueAfterNoDecision)
            {
                manager.StartDialogue(dialogue);
            }
        }
    }
}
