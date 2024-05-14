using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots_UI : MonoBehaviour
{

    public Image itemIcon;
    public Image selectBox;
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
        Color invisible = new Color(1, 1, 1, 0);
        itemIcon.color = invisible;
        selectBox.color = invisible;
    }

}
