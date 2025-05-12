using System.Collections.Generic;
using UnityEngine;
using Coin;

namespace ObjectPool.Coin
{
    public class CoinPool
    {
        private Queue<CoinController> _coinPool;
        private CoinScriptableObject _coinSO;

        public CoinPool(CoinScriptableObject coinSO)
        {
            _coinSO = coinSO;
            _coinPool = new Queue<CoinController>();

            for (int i = 0; i < _coinSO.InitialCoinCount; ++i)
            {
                CoinController controller = CreateCoin();
                controller.DeactivateObject();
                _coinPool.Enqueue(controller);
            }
        }

        public CoinController GetCoin()
        {
            //Reusing coin from pool
            if (_coinPool.Count > 0)
            {
                CoinController reusedCoin = _coinPool.Dequeue();
                reusedCoin.ActivateObject();

                return reusedCoin;
            }

            //Creating coin if pool is empty
            return CreateCoin();
        }

        public void ReturnCoin(CoinController coinController)
        {
            coinController.DeactivateObject();
            _coinPool.Enqueue(coinController);
        }

        private CoinController CreateCoin()
        {
            CoinView coinView = Object.Instantiate(_coinSO.CoinView, _coinSO.CoinSpawnPosition, Quaternion.identity);

            return new CoinController(coinView, coinView.transform.position);
        }
    }
}