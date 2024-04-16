using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{

    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void setItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
    }

}
