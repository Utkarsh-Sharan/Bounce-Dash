using UnityEngine;

namespace Obstacle
{
    public abstract class ObstacleController
    {
        protected float moveSpeed;
        protected float rotationSpeed;

        public virtual void Configure(float moveSpeed, float rotationSpeed)
        {
            this.moveSpeed = moveSpeed;
            this.rotationSpeed = rotationSpeed;
        }

        public abstract void FixedUpdateObstacle();
        public abstract void HandleObstacleCollision(GameObject collisionObject);

        public abstract void ActivateObject();
        public abstract void DeactivateObject();
    }
}