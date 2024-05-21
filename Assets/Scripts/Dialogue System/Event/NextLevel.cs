using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : Event
{
    public List<Dialogue> dialogueBeforeDecision;

    public Dialogue dialogueMoreThen2;
    public Dialogue dialogueEqualTo2;
    public Dialogue dialogueLessThen2;

    public Decision WhetherNextLevel;
    public SubmitItem removeItem;

    private DialogueManagerNew manager;
    private int nextSeq;
    private NPCInteraction interaction;
    //public bool firstDecisionMade = false;

    public NextLevel() : base(EventType.Nextlevel) { }

    public override void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction)
    {
        nextSeq = seq;
        interaction = npcInteraction;

        manager = dialogueManager;

        manager.addDialogueList(dialogueBeforeDecision);

        GameObject playerGameObject = GameObject.Find("Player");
        if (playerGameObject != null)
        {
            Player player = playerGameObject.GetComponent<Player>();


            if (player.inventory.Counts() == 2)
            {
                manager.StartDialogue(dialogueEqualTo2);
                WhetherNextLevel.Execute(seq, manager, interaction);

            }
            else if (player.inventory.Counts() >= 3)
            {
                manager.StartDialogue(dialogueMoreThen2);
                removeItem.Execute(seq, manager, interaction);
            }
            else
            {
                manager.StartDialogue(dialogueLessThen2);

            }
        }

    }


}
