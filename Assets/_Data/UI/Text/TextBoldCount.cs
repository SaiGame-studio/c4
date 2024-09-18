using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoldCount : SaiMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPro;

    protected virtual void FixedUpdate()
    {
        this.LoadGoldCount();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }

    protected virtual void LoadTextPro()
    {
        if (this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTextPro", gameObject);
    }

    protected virtual void LoadGoldCount()
    {
        ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Gold);
        string goldCount;
        if (item == null) goldCount = "0";
        else goldCount = item.itemCount.ToString();
        this.textPro.text = goldCount;

    }
}
