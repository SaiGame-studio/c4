using System.Collections.Generic;
using UnityEngine;

public class PathsManager : SaiSingleton<PathsManager>
{
    [SerializeField] protected List<Path> paths = new();

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
            Path path = child.GetComponent<Path>();
            path.LoadPoints();
            this.paths.Add(path);
        }
        Debug.Log(transform.name + ": LoadPaths", gameObject);
    }

    public virtual Path GetPath(int index)
    {
        return this.paths[index];
    }

    public virtual Path GetPath(string pathName)
    {
        foreach(Path path in this.paths)
        {
            if (path.name == pathName) return path;
        }

        return null;
    }
}
