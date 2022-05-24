using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Blaster blaster;

    private PlayerInputActions input;

    private void Awake()
    {
        input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.ShootBlaster.performed += ctx => OnShootBlaster();
    }

    private void OnShootBlaster()
    {
        blaster.WeaponShoot();
    }

}
