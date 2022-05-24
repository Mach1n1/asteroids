using UnityEngine;

public class Blaster : AbstractWeapon
{
    public override void WeaponShoot()
    {
        CreateProjectile(barrel, projectile);
    }
}
