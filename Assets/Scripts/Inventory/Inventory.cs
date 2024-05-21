using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CollectableType
{
    NONE, Coin, Food, Egg, Ring, Icecream, Book, Dog
}

[System.Serializable]
public class Inventory
{

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
        public void removeItem()
        {
            this.item = null;
            //count;
        }
    }

    public List<Slot> slots = new();

    public Inventory(int numSlots)
    {
        for(int i=0; i< numSlots; i++)
        {
            Slot slot = new();
            slots.Add(slot);
        }
    }

    public Inventory()
    {
        for (int i = 0; i < 5; i++)
        {
            Slot slot = new();
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

    public Item GetItemfromKey(int key)
    {
        return slots[key].item;
    }
    public void RemoveItemfromKey(int key)
    {
        slots[key].removeItem();
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

    public int Counts()
    {
        int itemCount = 0;
        foreach (Slot slot in slots)
        {
            if (slot.item != null)
            {
                itemCount++;
            }
        }
        return itemCount;
    }
}
