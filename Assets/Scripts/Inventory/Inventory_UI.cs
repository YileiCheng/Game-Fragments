using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{

    public GameObject inventoryPanel;

    public Player player;

    public List<Slots_UI> slots_UIs = new List<Slots_UI>();

    int selectedTag = -1;

    KeyCode[] keyCodes = {
            KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
            KeyCode.Alpha4, KeyCode.Alpha5
        };

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Setup();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
        if (inventoryPanel.activeSelf)
        {
            Select();

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

    public void Select()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i])) 
            {
                Debug.Log("press"+i);
                if (selectedTag == i) 
                {
                    ToggleSelectBox(slots_UIs[i].selectBox);
                    selectedTag = -1; 
                }
                else 
                {
                    if (selectedTag != -1) 
                    {
                        setInvisible(slots_UIs[selectedTag].selectBox);
                    }
                    ToggleSelectBox(slots_UIs[i].selectBox); 
                    selectedTag = i; 
                }
                break; 
            }
        }


    }

    public void setInvisible(Image image)
    {
        image.color = new Color(1, 1, 1, 0);
    }

    public void ToggleSelectBox(Image image)
    {
        Color visible = new Color(1, 1, 1, 1);
        Color invisible = new Color(1, 1, 1, 0);
        image.color = image.color == visible ? invisible : visible;
    }

    void Setup()
    {
        if(slots_UIs.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots_UIs.Count; i++)
            {
                if (player.inventory.slots[i].item != null)
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
