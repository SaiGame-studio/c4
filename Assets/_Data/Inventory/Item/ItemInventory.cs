using System;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public int itemId = UnityEngine.Random.Range(0, 999999999);
    public string itemName;
    public ItemProfileSO itemProfile;
    public int itemCount;
}
