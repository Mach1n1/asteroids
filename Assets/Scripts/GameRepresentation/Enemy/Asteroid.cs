using Game.Logic;
using UnityEngine;

public class Asteroid : Enemy
{
    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
