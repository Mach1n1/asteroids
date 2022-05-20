using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logic
{
    public abstract class Movement
    {
        protected float moveSpeed;

        public abstract void Move(Transform transformObject);

        public abstract void Rotate(Transform transformObject);

        public abstract void SetSpeed(float speed, float deltaTime);
    }

    public sealed class PlayerMovement : Movement
    {
        public Vector3 acceleration {get; private set;}
        public float eulerAngle {get; private set;}
        private float rotate;
        private float rotateSpeed;

        public void Accelerate(Transform player, float unitsInSecond, float maxSpeed, float deltaTime)
        {
            acceleration = acceleration + player.up * (unitsInSecond * deltaTime);
            acceleration = Vector2.ClampMagnitude(acceleration, maxSpeed);
        }

        public void Slow(float secondsToStop, float deltaTime)
        {
            acceleration = acceleration - acceleration * (deltaTime / secondsToStop);
        }
        public override void Move(Transform player)
        {
            player.position = player.position + acceleration;
        }

        public override void Rotate(Transform player)
        {
            player.Rotate(0f, 0f, -rotate * rotateSpeed);
        }

        public void SetRotateValue(float rotate)
        {
            this.rotate = rotate;
        }

        public float GetEulerAngle(float rotate, Transform player)
        {
            rotate = player.rotation.eulerAngles.z;

            return eulerAngle = rotate;
        }

        public override void SetSpeed(float rotateSpeed, float deltaTime)
        {
            this.rotateSpeed = rotateSpeed * deltaTime;
        }

    }
}