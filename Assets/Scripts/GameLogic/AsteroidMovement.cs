using UnityEngine;

namespace Game.Logic
{
    public class AsteroidMovement : AbstractMovement
    {

        private float fullAngle = 360.0f;

        public override void Move(Transform enemy)
        {
            enemy.Translate(Vector2.one * moveSpeed);
        }

        public override void Rotate(Transform enemy)
        {
            enemy.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * fullAngle);
        }

        public override void SetSpeed(float speed, float deltaTime)
        {
            moveSpeed = speed * deltaTime;
        }
    }
}