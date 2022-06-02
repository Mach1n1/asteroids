using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Blaster blaster;
    [SerializeField] Laser laser;
    [SerializeField] private Ammo ammo;

    private PlayerInputActions input;

    private void Awake()
    {
        input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.ShootBlaster.performed += ctx => OnShootBlaster();
        input.Player.ShootLaser.performed += ctx => OnShootLaser();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.ShootBlaster.performed -= ctx => OnShootBlaster();
        input.Player.ShootLaser.performed -= ctx => OnShootLaser();
    }

    private void OnShootBlaster()
    {
        blaster.WeaponShoot();
    }

    private void OnShootLaser()
    {
        TryShootLaser();
    }

    private void TryShootLaser()
    {
        if (ammo.CurrentAmmo > 0)
        {
            laser.WeaponShoot();
        }
    }
}
