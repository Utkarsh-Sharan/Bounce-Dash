using Main;
using UnityEngine;

namespace Obstacle
{
    public class RightSideSpikeController : ObstacleController
    {
        private RightSideSpikeView _rightSideSpikeView;
        private Vector3 _spawnPosition;

        public RightSideSpikeController(ObstacleView obstacleView, Vector3 spawnPosition)
        {
            _rightSideSpikeView = (RightSideSpikeView)obstacleView;
            _spawnPosition = spawnPosition;
            _rightSideSpikeView.Initialize(this);
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
            _rightSideSpikeView.GetObstacleBody().MovePosition(_rightSideSpikeView.GetObstacleBody().position + moveDown);
        }

        public override void HandleObstacleCollision(GameObject collisionObject)
        {
            if (collisionObject.GetComponent<ObstacleDeactivator>())   //If this obstacle collides with ObstacleDeactivator, it deactivates and returns to the pool.
                GameService.Instance.GetObstacleService().ReturnObstacleToPool(this, ObstacleType.Right_Side_Spike);
        }

        public override void ActivateObject()
        {
            _rightSideSpikeView.gameObject.SetActive(true);
            _rightSideSpikeView.transform.position = _spawnPosition;
        }

        public override void DeactivateObject() => _rightSideSpikeView.gameObject.SetActive(false);
    }
}