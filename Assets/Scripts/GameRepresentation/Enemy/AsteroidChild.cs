using Game.Logic;
using UnityEngine;

public class AsteroidChild : Enemy
{
    public override void Die()
    {
        gameObject.SetActive(false);
        AddScore();
    }
}
