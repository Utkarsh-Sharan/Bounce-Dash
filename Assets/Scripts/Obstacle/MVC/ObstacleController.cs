using UnityEngine;

namespace Obstacle
{
    public class ObstacleController
    {
        protected float moveSpeed;
        protected float rotationSpeed;

        public void Configure(float moveSpeed, float rotationSpeed)
        {
            this.moveSpeed = moveSpeed;
            this.rotationSpeed = rotationSpeed;
        }

        public virtual void FixedUpdateObstacle() { }
        public virtual void HandleObstacleCollision(GameObject collisionObject) { }
    }
}