using Main;
using Player;
using Event;
using UnityEngine;

namespace Coin
{
    public class CoinController
    {
        private CoinView _coinView;
        private Vector3 _spawnPosition;

        private float _coinSpeed;
        private int _coinValue;

        public CoinController(CoinView coinView, Vector3 spawnPosition)
        {
            _coinView = coinView;
            _spawnPosition = spawnPosition;

            _coinView.Initialize(this);
        }

        public void Configure(float coinSpeed, int coinValue)
        {
            _coinSpeed = coinSpeed;
            _coinValue = coinValue;
        }

        public void FixedUpdateCoin()
        {
            Vector2 moveDown = Vector2.down * _coinSpeed * Time.fixedDeltaTime;
            _coinView.GetCoinBody().MovePosition(_coinView.GetCoinBody().position + moveDown);
        }

        public void HandleCoinCollision(GameObject otherObject)
        {
            if (otherObject.GetComponent<ObstacleDeactivator>())
                GameService.Instance.GetCoinService().ReturnCoinToPool(this);

            else if (otherObject.GetComponent<PlayerView>())
            {
                EventService.Instance.OnCoinCollectedEvent.InvokeEvent(_coinValue);
                GameService.Instance.GetCoinService().ReturnCoinToPool(this);
            }
        }

        public void ActivateObject()
        {
            _coinView.gameObject.SetActive(true);
            _coinView.transform.position = _spawnPosition;
        }

        public void DeactivateObject() => _coinView.gameObject.SetActive(false);
    }
}