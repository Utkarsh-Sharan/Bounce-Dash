using UnityEngine;
using Main;

namespace Obstacle
{
    public class LeftSideSpikeController : ObstacleController
    {
        private LeftSideSpikeView _leftSideSpikeView;
        private Vector3 _spawnPosition;

        public LeftSideSpikeController(ObstacleView obstacleView, Vector3 spawnPosition)
        {
            _leftSideSpikeView = (LeftSideSpikeView)obstacleView;
            _spawnPosition = spawnPosition;
            _leftSideSpikeView.Initialize(this);
        }

        public override void Configure(float moveSpeed, float rotationSpeed)
        {
            base.Configure(moveSpeed, rotationSpeed);
        }

        public override void FixedUpdateObstacle()
        {
            MoveSpike();
        }

        private void MoveSpike()
        {
            Vector2 moveDown = Vector2.down * moveSpeed * Time.fixedDeltaTime;
            _leftSideSpikeView.GetObstacleBody().MovePosition(_leftSideSpikeView.GetObstacleBody().position + moveDown);
        }

        public override void HandleObstacleCollision(GameObject collisionObject)
        {
            if (collisionObject.GetComponent<ObstacleDeactivator>())   //If this obstacle collides with ObstacleDeactivator, it deactivates and returns to the pool.
                GameService.Instance.GetObstacleService().ReturnObstacleToPool(this, ObstacleType.Left_Side_Spike);
        }

        public override void ActivateObject()
        {
            _leftSideSpikeView.gameObject.SetActive(true);
            _leftSideSpikeView.transform.position = _spawnPosition;
        } 

        public override void DeactivateObject() => _leftSideSpikeView.gameObject.SetActive(false);
    }
}