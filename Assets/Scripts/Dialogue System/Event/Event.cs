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

    protected Event(EventType type)
    {
        Type = type;
    }
    public abstract void Execute(int seq, DialogueManagerNew dialogueManager, NPCInteraction npcInteraction);

    //Event nextEvent;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

}
