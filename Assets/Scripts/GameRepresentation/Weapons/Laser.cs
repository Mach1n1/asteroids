using UnityEngine;

[RequireComponent(typeof(Ammo))]
public sealed class Laser : AbstractWeapon
{
    private Ammo ammo;

    private void Start()
    {
        ammo = GetComponent<Ammo>();
    }
    public override void WeaponShoot()
    {
        ammo.SpendCharge();
        CreateProjectile(barrel, projectile);
    }
}
