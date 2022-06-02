public class AlienShip : Enemy
{
    public override void Die()
    {
        gameObject.SetActive(false);
        AddScore();
    }
}
