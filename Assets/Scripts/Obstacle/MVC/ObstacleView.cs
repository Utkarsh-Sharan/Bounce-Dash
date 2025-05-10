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

        protected void FixedUpdate()
        {
            _obstacleController.MoveSpike();
        }

        public Rigidbody2D GetObstacleBody() => _obstacleBody;
    }
}