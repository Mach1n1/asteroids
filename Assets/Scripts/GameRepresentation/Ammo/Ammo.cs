using System.Collections;
using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    
    [SerializeField] private int maxAmmo;
    [SerializeField] private int recoverAmmoTime;

    private int currentAmmo;
    public int CurrentAmmo => currentAmmo;

    /* private WaitForSeconds regenTick = new WaitForSeconds(2f); */

    private WaitForSeconds regenTick;
    private Coroutine regen;

    public static Ammo instance;

    private void Awake()
    {
        instance = this;
        regenTick = new WaitForSeconds((float)recoverAmmoTime);
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    public void SpendCharge()
    {
        Debug.Log(instance.currentAmmo);
        if(currentAmmo > 0)
        {
            currentAmmo--;  

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenAmmo());
        }
        else
        {
            Debug.Log("No Ammo");
        }
    }

    private IEnumerator RegenAmmo()
    {
        yield return new WaitForSeconds(recoverAmmoTime);

        while(currentAmmo < maxAmmo)
        {
            currentAmmo++;
            yield return regenTick;
        }
        regen = null;
    }

}
