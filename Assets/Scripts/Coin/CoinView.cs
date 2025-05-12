using Obstacle;
using UnityEngine;

namespace Coin
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D _coinBody;
        private CoinController _coinController;

        public void Initialize(CoinController coinController)
        {
            _coinController = coinController;
        }

        private void FixedUpdate()
        {
            _coinController.FixedUpdateCoin();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _coinController.HandleCoinCollision(other.gameObject);
        }

        public Rigidbody2D GetCoinBody() => _coinBody;
    }
}