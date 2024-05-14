using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Event
{
    public enum EventType
    {
        DialogEvent,
        DecisionEvent,
        SubmitItemEvent,
        ReceiveItemEvent,
        DefaultEvent
    }

    public EventType Type { get; private set; }
    //public int nextEventIndex;
    protected Event(EventType type)
    {
        Type = type;
    }
    public abstract void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction);

}
