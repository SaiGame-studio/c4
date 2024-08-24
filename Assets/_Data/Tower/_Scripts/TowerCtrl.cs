using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
