using UnityEngine;

public class LaserProjectile : AbstractProjectile
{
    private void Start()
    {
        DestroyYourselfAfterSomeTime(gameObject, TimeToDestroy);
    }

    private void Update()
    {
        BulletMovement(BulletSpeed);
    }

    public void DestroyYourselfAfterSomeTime(GameObject gameObject, float timeDestroy)
    {
        Destroy(gameObject, timeDestroy);
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }
    }

}
