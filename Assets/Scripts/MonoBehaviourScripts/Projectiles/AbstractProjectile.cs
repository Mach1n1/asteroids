using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour
{
    [SerializeField] protected float BulletSpeed;
    [SerializeField] protected float TimeToDestroy;

    protected void BulletMovement(float bulletSpeed)
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
}
