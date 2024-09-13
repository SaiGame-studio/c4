using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.2215742f, 0.177404f, 0.3095092f);
        transform.localRotation = Quaternion.Euler(26.657f, -97.288f, -98.937f);
    }
}
