using System.Collections;
using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int maxAmmo;
    private int currentAmmo;
    private const byte noAmmo = 0;

    [SerializeField] private float timeToReloadAmmo;
    [SerializeField] private float reloadAmmoSpeed;

    private float currentTimeReloadAmmo;
    private const byte limitTimeReloadAmmo = 0;

    private bool isReloading = false;
    public int NoAmmo => noAmmo;
    public int CurrentAmmo => currentAmmo;
    public float TimeReloadAmmoView => currentTimeReloadAmmo;

    private void Start()
    {
        if (maxAmmo <= noAmmo)
            throw new ArgumentOutOfRangeException(nameof(maxAmmo));

        SetCurrentAmmo();
        SetCurrentReloadTime();
    }

    private void Update()
    {
        ReloadConditions();
    }

    public void SpendCharge()
    {
        currentAmmo--;
    }

    private void ReloadConditions()
    {
        if (currentAmmo > maxAmmo)
        {
            throw new ArgumentOutOfRangeException(nameof(currentAmmo));
        }
        if (isReloading)
        {
            return;
        }

        ReloadAmmo();
        NegativReloadAmmo();
    }

    private void ReloadAmmo()
    {
        if (currentAmmo == noAmmo)
            StartCoroutine(AutoReloadAmmo());
    }

    private void NegativReloadAmmo()
    {
        if (currentAmmo < noAmmo)
        {
            currentAmmo = noAmmo;

            StartCoroutine(AutoReloadAmmo());
        }
    }

    private IEnumerator AutoReloadAmmo()
    {
        isReloading = true;

        while (currentTimeReloadAmmo > limitTimeReloadAmmo)
        {
            yield return new WaitForSeconds(reloadAmmoSpeed);

            currentTimeReloadAmmo--;
        }

        SetCurrentAmmo();
        SetCurrentReloadTime();

        isReloading = false;
    }

    private void SetCurrentAmmo()
    {
        currentAmmo = maxAmmo;
    }
    private void SetCurrentReloadTime()
    {
        currentTimeReloadAmmo = timeToReloadAmmo;
    }

}
