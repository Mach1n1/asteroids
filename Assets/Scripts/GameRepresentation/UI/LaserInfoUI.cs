using TMPro;
using UnityEngine;

public class LaserInfoUI : MonoBehaviour
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private TMP_Text ammoAmount;
    [SerializeField] private TMP_Text reloadTime;

    private void FixedUpdate()
    {
        ammoAmount.text = $"Laser: {ammo.CurrentAmmo}";
        reloadTime.text = $"LaserCD: {ammo.ReloadTimeAmmoView}";
    }
}
