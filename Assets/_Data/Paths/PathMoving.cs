using System.Collections.Generic;
using UnityEngine;

public class PathMoving : SaiMonoBehaviour
{
    [SerializeField] protected List<Point> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform child in transform)
        {
            Point point = child.GetComponent<Point>();
            //point.LoadNextPoint();
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }

    public virtual Point GetPoint(int index)
    {
        return this.points[index];
    }
}
