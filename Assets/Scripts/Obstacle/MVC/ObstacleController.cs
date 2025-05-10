using UnityEngine;

namespace Obstacle
{
    public class ObstacleController
    {
        private ObstacleView _obstacleView;

        public virtual void MoveSpike()
        {
            Vector2 moveDown = Vector2.down * 4 * Time.fixedDeltaTime;
            _obstacleView.GetObstacleBody().MovePosition(_obstacleView.GetObstacleBody().position + moveDown);
        }
    }
}