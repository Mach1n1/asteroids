using UnityEngine;
using Game.Logic;

public class BlasterProjectile : AbstractProjectile
{
    private void Start()
    {
        DestroyYourselfAfterCertainTime(gameObject, TimeToDestroy);
    }

    private void Update()
    {
        BulletMovement(BulletSpeed);
    }

    public void DestroyYourselfAfterCertainTime(GameObject gameObject, float timeToDestroy)
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void DestroyYourselfCollision()
    {
        Destroy(gameObject);
    }
}
