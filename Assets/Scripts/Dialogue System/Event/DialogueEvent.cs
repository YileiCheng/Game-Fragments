using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : Event
{
    public List<Dialogue> dialogues;
    public DialogueEvent() : base(EventType.DialogEvent)
    {
    }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            dialogueManager.StartDialogue(dialogue);
        }
        npcInteraction.UpdateSeq(seq + 1);
    }
}
