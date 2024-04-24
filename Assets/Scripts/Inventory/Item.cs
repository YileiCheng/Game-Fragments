using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public CollectableType type;
    public Sprite icon;
}
