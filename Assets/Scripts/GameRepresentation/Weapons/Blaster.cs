using UnityEngine;

public class Blaster : AbstractWeapon
{
    public override void WeaponShoot()
    {
        CreateBullet(barrel, projectile);
    }
}
