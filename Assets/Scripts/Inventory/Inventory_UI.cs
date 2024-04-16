using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Inventory_UI : MonoBehaviour
{

    public GameObject inventoryPanel;

    public Player player;

    public List<Slots_UI> slots_UIs = new List<Slots_UI>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Setup()
    {
        if(slots_UIs.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots_UIs.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots_UIs[i].setItem(player.inventory.slots[i]);
                }
                else
                {
                    slots_UIs[i].SetEmpty();
                }
            }
        }
    }

}
