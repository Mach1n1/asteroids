using Game.Logic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private AsteroidMovement movement;
    private Transform asteroidTransform;

    private void Start()
    {
        movement = new AsteroidMovement();

        asteroidTransform = GetComponent<Transform>();

        movement.Rotate(asteroidTransform);
    }

    private void FixedUpdate()
    {
        movement.SetSpeed(moveSpeed, Time.deltaTime);
        movement.Move(asteroidTransform);
    }
}
