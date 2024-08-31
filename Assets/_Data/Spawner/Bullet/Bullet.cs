using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
