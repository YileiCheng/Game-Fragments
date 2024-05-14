using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CollectableType
{
    NONE, COIN, FOOD, EGG, RING, Icecream
}

[System.Serializable]
public class Inventory
{

    void Start()
    {
        //Load all Item objects from the Resources/Items folder

    }

    [System.Serializable]
    public class Slot
    {
        public Item item;
        public int count;
        public int maxAllowed;


        public Slot()
        {
            item = null;
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
        public void addItem(Item item)
        {
            this.item = item;
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

    public Inventory()
    {
        for (int i = 0; i < 5; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void AddfromCollection(ItemCollection itemc)
    {
        foreach (Slot slot in slots)
        {
            // if < maxallowed
            if (slot.item == null)
            {
                slot.addItem(itemc.item);
                return;
            }
        }
    }

    public void AddfromItem(Item item)
    {
        foreach (Slot slot in slots)
        {
            // if < maxallowed
            if (slot.item == null)
            {
                slot.addItem(item);
                return;
            }
        }
    }

    public void AddfromType(CollectableType itemType)
    {
        foreach (Slot slot in slots)
        {
            // if < maxallowed
            if (slot.item == null)
            {
                foreach (Item item in AllItems.Instance.allItems)
                {
                    if (item.type == itemType)
                    {
                        slot.addItem(item);
                        break;
                    }
                }
                return;
            }
        }
    }
}
