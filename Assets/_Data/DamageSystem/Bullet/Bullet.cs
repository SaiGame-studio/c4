using UnityEngine;

public class Bullet : PoolObj
{
    [SerializeField] protected float speed = 10f;

    public override string GetName()
    {
        return "Bullet";
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
