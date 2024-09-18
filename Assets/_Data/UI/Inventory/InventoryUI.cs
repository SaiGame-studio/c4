using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : SaiMonoBehaviour
{
    protected bool isShow = true;
    bool IsShow => isShow;

    protected override void Start()
    {
        base.Start();
        this.Hide();
    }

    public virtual void Show()
    {
        this.isShow = true;
        gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }
}

