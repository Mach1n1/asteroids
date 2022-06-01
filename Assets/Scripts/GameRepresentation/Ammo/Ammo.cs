using System.Collections;
using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    
    [SerializeField] private int maxAmmo;
    [SerializeField] private float recoverAmmoTime;

    private float countdown = 1;
    private const byte limitTimeReloadAmmo = 0;

    private float currentRecoverAmmoTime;

    private int currentAmmo;
    public int CurrentAmmo => currentAmmo;
    public float ReloadTimeAmmoView => currentRecoverAmmoTime;
    private Coroutine regen;

    private bool isReloading = false;
    public static Ammo instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        SetCurrentCountdownTimeView();
    }

    private void FixedUpdate()
    {
        ConditionsReloadingAmmo();
    }

    private void ConditionsReloadingAmmo()
    {
        if (isReloading || currentAmmo == maxAmmo)
        {
            return;
        }
        ReloadAmmo();
    }

    private void ReloadAmmo()
    {
        regen = StartCoroutine(RegenAmmo());
    }

    public void SpendCharge()
    {
        currentAmmo--;
    }

private IEnumerator RegenAmmo()
    {
        isReloading = true;

        while(currentRecoverAmmoTime > limitTimeReloadAmmo)
        {
            yield return new WaitForSeconds(countdown);
            currentRecoverAmmoTime--;
        }
        currentAmmo++;
        SetCurrentCountdownTimeView();

        isReloading = false;
    }

    private void SetCurrentCountdownTimeView()
    {
        currentRecoverAmmoTime = recoverAmmoTime;
    }


}
