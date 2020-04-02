using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.05f, targetPosition);
    }

    protected override void PlaySound()
    {
        // TODO
    }

    protected override void SetEffectDisplayTime()
    {
        _effectDisplayTime = 0.2f;
    }
}
