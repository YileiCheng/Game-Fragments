using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEvent : Event
{
    public Dialogue defaultDialogue;
    public DefaultEvent() : base(EventType.DefaultEvent)
    {
    }

    // Start is called before the first frame update

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        dialogueManager.StartDialogue(this.defaultDialogue);
        //throw new System.NotImplementedException();
    }
}
