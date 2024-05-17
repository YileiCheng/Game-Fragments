using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : Event
{
    public List<Dialogue> dialogueBeforeReceiving;
    public Dialogue dialogueWhenReceiving;
    public Item item;
    public ReceiveItem() : base(EventType.ReceiveItemEvent)
    {
    }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        foreach (Dialogue dialogue in dialogueBeforeReceiving)
        {
            dialogueManager.StartDialogue(dialogue);
        }
        dialogueManager.StartDialogue(this.dialogueWhenReceiving);

        GameObject playerGameObject = GameObject.Find("Player");
        if (playerGameObject != null)
        {
            Player player = playerGameObject.GetComponent<Player>();
            player.inventory.AddfromItem(item);
        }

        // set invisible
        GameObject itemGameObject = GameObject.Find(item.type.ToString());
        if (itemGameObject != null)
        {
            Debug.Log("Find item" + item.type.ToString());
            itemGameObject.SetActive(false);
        }

        npcInteraction.UpdateSeq(seq + 1);

    }
}
