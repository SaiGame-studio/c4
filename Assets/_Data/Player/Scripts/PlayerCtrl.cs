using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected vThirdPersonController thirdPersonCtrl;
    public vThirdPersonController ThirdPersonController => thirdPersonCtrl;


    [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
    public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonCtrl();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
    }

    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
    }
    protected virtual void LoadThirdPersonCtrl()
    {
        if (this.thirdPersonCtrl != null) return;
        this.thirdPersonCtrl = GetComponent<vThirdPersonController>();
        Debug.Log(transform.name + ": LoadThirPersonCtrl", gameObject);
    }


    protected virtual void LoadThirdPersonCamera()
    {
        if (this.thirdPersonCamera != null) return;
        this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.2f;
        this.thirdPersonCamera.height = 1.3f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
        Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
    }
}
