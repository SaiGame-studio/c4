using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public InvCodeName invCodeName;
    public ItemCode itemCode;
    public string itemName;
    public bool isStackable = false;

    protected virtual void Reset()
    {
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        this.AutoLoadItemCode();
        this.AutoLoadItemName();
    }

    protected virtual void AutoLoadItemCode()
    {
        string className = this.GetType().Name;
        Debug.Log("className: " + className);
        this.itemCode = ItemCodeParse.Parse("Item1");
    }

    protected virtual void AutoLoadItemName()
    {
        Debug.Log("name: " + this.name);
        this.itemName = "Item1";
    }
}