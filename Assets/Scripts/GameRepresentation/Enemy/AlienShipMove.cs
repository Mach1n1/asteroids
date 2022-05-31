using Game.Logic;
using UnityEngine;

public class AlienShipMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private AlienMovement movement;
    private Transform _alienTransform;

    private Player target => FindObjectOfType<Player>();

    private void Start()
    {
        movement = new AlienMovement();
        _alienTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            movement.SetSpeed(moveSpeed, Time.deltaTime);
            movement.SetTarget(target.transform.position);

            movement.Move(_alienTransform);
            movement.Rotate(_alienTransform);
        }
    }
}

