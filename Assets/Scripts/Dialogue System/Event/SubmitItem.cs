using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubmitItem : Event
{
    public List<Dialogue> dialogueBeforeSubmission;
    public Dialogue dialogueWhileSubmission;
    public List<Dialogue> dialoguewithPassing;
    public List<Dialogue> dialoguewithWrongItem;
    public List<Dialogue> dialogueWithoutSubmitting;
    public Item itemRequired;
    public bool remove;

    private DialogueManagerNew manager;
    private int nextSeq;
    private NPCInteraction interaction;

    public SubmitItem() : base(EventType.SubmitItemEvent)
    {
    }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        nextSeq = seq;
        interaction = npcInteraction;
        manager = dialogueManager;

        manager.addDialogueList(dialogueBeforeSubmission);

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
                if (!remove)
                {
                    if (item.type == itemRequired.type)
                    {
                        manager.addDialogueList(dialoguewithPassing);

                        interaction.UpdateSeq(nextSeq + 1);
                        player.inventory.RemoveItemfromKey(index);
                    }
                    else
                    {
                        manager.addDialogueList(dialoguewithWrongItem);
                    }
                }
                else
                {
                    if (item != null)
                    {
                        manager.addDialogueList(dialoguewithPassing);
                        player.inventory.RemoveItemfromKey(index);
                    }
                    else
                    {
                        manager.addDialogueList(dialogueWithoutSubmitting);
                    }
                }

            }


        }
        else
        {
            manager.addDialogueList(dialogueWithoutSubmitting);
        }
    }
}
