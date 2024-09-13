using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.288f, 0.141f, 0.379f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
