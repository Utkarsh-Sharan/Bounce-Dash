using UnityEngine;

namespace Obstacle
{
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _obstacleBody;
        private ObstacleController _obstacleController;

        public void Initialize(ObstacleController obstacleController)
        {
            _obstacleController = obstacleController;
        }

        private void FixedUpdate()
        {
            _obstacleController.FixedUpdateObstacle();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _obstacleController.HandleObstacleCollision(other.gameObject);
        }

        public Rigidbody2D GetObstacleBody() => _obstacleBody;
    }
}