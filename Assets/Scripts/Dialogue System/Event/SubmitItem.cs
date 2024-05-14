using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitItem : Event
{
    public Dialogue dialogueBeforeSubmission;
    public Item itemRequired;
    bool accepted;
    public SubmitItem() : base(EventType.SubmitItemEvent)
    {
    }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {

    }
}
