using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollectableType
{
    NONE, COIN, FOOD, EGG, RING
}

[System.Serializable]
public class Inventory
{

    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }
        public bool canAdd()
        {
            if(count < maxAllowed)
            {
                return true;
            }
            return false;
        }
        public void addItem(ItemCollection item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i=0; i< numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(ItemCollection token)
    {
        foreach(Slot slot in slots)
        {
            // if < maxallowed
            if (slot.type == CollectableType.NONE)
            {
                slot.addItem(token);
                return;
            }
        }
    }
}
