using Game.Logic;
using UnityEngine;

public class AlienMovement : AbstractMovement
{
    private Vector3 targetPostion;

        public override void Move(Transform enemy)
        {
            enemy.position = Vector2.MoveTowards(enemy.position, targetPostion, moveSpeed);
        }

        public override void Rotate(Transform enemy)
        {
            Vector3 direction = enemy.InverseTransformPoint(targetPostion);

            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            enemy.Rotate(0, 0, -angle);
        }

        public void SetTarget(Vector3 targetPosition)
        {
            targetPostion = targetPosition;
        }

        public override void SetSpeed(float speedMove, float deltaTime)
        {
            moveSpeed = speedMove * deltaTime;
        }
}
