using UnityEngine;
using Main;

namespace Obstacle
{
    public class SpikeController : ObstacleController
    {
        private SpikeView _spikeView;

        public SpikeController(ObstacleView obstacleView, Vector3 spawnPoint) : base()
        {
            _spikeView = (SpikeView)Object.Instantiate(obstacleView, spawnPoint, Quaternion.identity);
            _spikeView.Initialize(this);
        }

        public override void Configure(float moveSpeed, float rotationSpeed)
        {
            _spikeView.gameObject.SetActive(true);
            base.Configure(moveSpeed, rotationSpeed);
        }

        public override void FixedUpdateObstacle()
        {
            MoveSpike();
        }

        private void MoveSpike()
        {
            Vector2 moveDown = Vector2.down * moveSpeed * Time.fixedDeltaTime;
            _spikeView.GetObstacleBody().MovePosition(_spikeView.GetObstacleBody().position + moveDown);
        }

        public override void HandleObstacleCollision(GameObject collisionObject)
        {
            if (collisionObject.GetComponent<ObstacleDeactivator>())   //If this obstacle collides with ObstacleDeactivator, it deactivates and returns to the pool.
            {
                _spikeView.gameObject.SetActive(false);
                GameService.Instance.GetObstacleService().ReturnObstacleToPool(this);
            }
        }
    }
}