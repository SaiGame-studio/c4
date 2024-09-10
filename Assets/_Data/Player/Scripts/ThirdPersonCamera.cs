using Invector;
using UnityEngine;

public class ThirdPersonCamera : vThirdPersonCamera
{
    protected virtual void Reset()
    {
        this.rightOffset = 0.6f;
        this.defaultDistance = 0.7f;
    }
}
