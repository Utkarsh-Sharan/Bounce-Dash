using UnityEngine;
using Main;

namespace Obstacle
{
    public class RotatingSpikeController : ObstacleController
    {
        private RotatingSpikeView _rotatingSpikeView;

        public RotatingSpikeController(ObstacleView obstacleView, Vector3 spawnPoint) : base()
        {
            _rotatingSpikeView = (RotatingSpikeView)Object.Instantiate(obstacleView, spawnPoint, obstacleView.transform.rotation);
            _rotatingSpikeView.Initialize(this);
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
            Quaternion rotatation = Quaternion.Euler(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
            _rotatingSpikeView.GetObstacleBody().MoveRotation(rotatation);
        }

        public override void HandleObstacleCollision(GameObject collisionObject)
        {
            if (collisionObject.GetComponent<ObstacleDeactivator>() != null)   //If this obstacle collides with ObstacleDeactivator, it deactivates and returns to the pool.
            {
                _rotatingSpikeView.gameObject.SetActive(false);
                GameService.Instance.GetObstacleService().ReturnObstacleToPool(this);
            }
        }
    }
}