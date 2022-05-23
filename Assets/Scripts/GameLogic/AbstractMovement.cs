using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Logic
{
    public abstract class AbstractMovement
    {
        protected float moveSpeed;

        public abstract void Move(Transform transformObject);

        public abstract void Rotate(Transform transformObject);

        public abstract void SetSpeed(float speed, float deltaTime);
    }

}