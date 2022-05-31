using UnityEngine;

public class BlasterProjectile : AbstractProjectile
{
    private void Start()
    {
        DestroyYourselfAfterSomeTime(gameObject, TimeToDestroy);
    }

    private void Update()
    {
        BulletMovement(BulletSpeed);
    }

    public void DestroyYourselfAfterSomeTime(GameObject gameObject, float timeToDestroy)
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            DestroyYourselfCollision();
        }
    }

    private void DestroyYourselfCollision()
    {
        Destroy(gameObject);
    }
}
