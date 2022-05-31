using Game.Logic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public event UnityAction PlayerDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Dead();

            PlayerDead?.Invoke();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}
