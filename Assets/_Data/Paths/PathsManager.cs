using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : SaiMonoBehaviour
{
    [SerializeField] protected List<Path> paths = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPaths();
    }

    protected virtual void LoadPaths()
    {
        if (this.paths.Count > 0) return;
        foreach (Transform child in transform)
        {
            Path path = child.GetComponent<Path>();
            path.LoadPoints();
            this.paths.Add(path);
        }
        Debug.Log(transform.name + ": LoadPaths", gameObject);
    }
}
