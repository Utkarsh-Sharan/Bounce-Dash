using UnityEngine;

namespace Obstacle
{
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _obstacleBody;

        protected void FixedUpdate()
        {
            MoveSpike();
        }

        private void MoveSpike()
        {
            Vector2 moveDown = Vector2.down * 4 * Time.fixedDeltaTime;
            _obstacleBody.MovePosition(_obstacleBody.position + moveDown);
        }
    }
}