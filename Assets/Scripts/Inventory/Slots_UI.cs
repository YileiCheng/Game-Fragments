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
            itemIcon.sprite = slot.item.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
    }

}
