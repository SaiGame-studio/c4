using System.Collections.Generic;
using UnityEngine;

public class PathsManager : SaiSingleton<PathsManager>
{
    [SerializeField] protected List<PathMoving> paths = new();

    protected override void Awake()
    {
        base.Awake();
    }

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
            PathMoving path = child.GetComponent<PathMoving>();
            path.LoadPoints();
            this.paths.Add(path);
        }
        Debug.Log(transform.name + ": LoadPaths", gameObject);
    }

    public virtual PathMoving GetPath(int index)
    {
        return this.paths[index];
    }

    public virtual PathMoving GetPath(string pathName)
    {
        foreach(PathMoving path in this.paths)
        {
            if (path.name == pathName) return path;
        }

        return null;
    }
}
