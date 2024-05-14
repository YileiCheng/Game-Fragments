using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitItem : Event
{
    public List<Dialogue> dialogueBeforeSubmission;
    public Dialogue dialogueWhileSubmission;
    public List<Dialogue> dialoguewithPassing;
    public List<Dialogue> dialoguewithWrongItem;
    public List<Dialogue> dialogueWithoutSubmitting;
    public Item itemRequired;

    private DialogueManagerNew manager;
    private int nextSeq;
    private NPCInteraction interaction;

    bool accepted;

    public SubmitItem() : base(EventType.SubmitItemEvent)
    {
    }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        nextSeq = seq;
        interaction = npcInteraction;
        manager = dialogueManager;

        foreach (Dialogue dialogue in dialogueBeforeSubmission)
        {
            manager.StartDialogue(dialogue);
        }
        manager.StartSubmission(this);
    }

    public void OnDecisionMade(bool decision, int index)
    {
        Debug.Log(index);
        if (decision && index != -1)
        {
            GameObject playerGameObject = GameObject.Find("Player");
            if (playerGameObject != null)
            {
                Player player = playerGameObject.GetComponent<Player>();
                Item item = player.inventory.GetItemfromKey(index);
                if(item.type == itemRequired.type)
                {
                    foreach (Dialogue dialogue in dialoguewithPassing)
                    {
                        manager.StartDialogue(dialogue);
                        interaction.UpdateSeq(nextSeq + 1);
                    }
                }
                else
                {
                    foreach (Dialogue dialogue in dialoguewithWrongItem)
                    {
                        manager.StartDialogue(dialogue);
                    }
                }
            }


        }
        else
        {
            foreach (Dialogue dialogue in dialogueWithoutSubmitting)
            {
                manager.StartDialogue(dialogue);
            }
        }
    }
}
