using System;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public int itemId;
    public string itemName;
    public ItemProfileSO itemProfile;
    public int itemCount;

    //public ItemInventory()
    //{
    //    this.itemId = UnityEngine.Random.Range(0, 999999999);
    //}
}
