using UnityEngine;
using Main;

namespace Obstacle
{
    public class RotatingSpikeController : ObstacleController
    {
        private RotatingSpikeView _rotatingSpikeView;
        private Vector3 _spawnPosition;

        public RotatingSpikeController(ObstacleView obstacleView, Vector3 spawnPosition)
        {
            _rotatingSpikeView = (RotatingSpikeView)obstacleView;
            _spawnPosition = spawnPosition;
            _rotatingSpikeView.Initialize(this);
        }

        public override void Configure(float moveSpeed, float rotationSpeed)
        {
            base.Configure(moveSpeed, rotationSpeed);
        }

        public override void FixedUpdateObstacle()
        {
            MoveSpike();
            RotateSpike();
        }

        private void MoveSpike()
        {
            Vector2 moveDown = Vector2.down * moveSpeed * Time.fixedDeltaTime;
            _rotatingSpikeView.GetObstacleBody().MovePosition(_rotatingSpikeView.GetObstacleBody().position + moveDown);
        }

        private void RotateSpike()
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
            _rotatingSpikeView.GetObstacleBody().MoveRotation(_rotatingSpikeView.transform.rotation * rotation);
        }

        public override void HandleObstacleCollision(GameObject collisionObject)
        {
            if (collisionObject.GetComponent<ObstacleDeactivator>() != null)   //If this obstacle collides with ObstacleDeactivator, it deactivates and returns to the pool.
                GameService.Instance.GetObstacleService().ReturnObstacleToPool(this, ObstacleType.Rotating_Spike);
        }

        public override void ActivateObject()
        {
            _rotatingSpikeView.gameObject.SetActive(true);
            _rotatingSpikeView.transform.position = _spawnPosition;
        } 

        public override void DeactivateObject() => _rotatingSpikeView.gameObject.SetActive(false);
    }
}