using UnityEngine;

public class LookAtPlayer : SaiMonoBehaviour
{
    [SerializeField] protected Transform playerCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.playerCamera != null) return;
        this.playerCamera = GameObject.Find("ThirdPersonCamera").transform;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    void Update()
    {
        transform.LookAt(playerCamera);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
    }
}
