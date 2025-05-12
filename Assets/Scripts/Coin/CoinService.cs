using ObjectPool.Coin;

namespace Coin
{
    public class CoinService
    {
        private CoinPool _coinPool;
        private CoinScriptableObject _coinSO;

        public CoinService(CoinScriptableObject coinSO)
        {
            _coinSO = coinSO;
            _coinPool = new CoinPool(_coinSO);
        }

        public void SpawnCoins()
        {
            CoinController spawnedCoin = _coinPool.GetCoin();
            spawnedCoin.Configure(_coinSO.CoinSpeed, _coinSO.CoinValue);
        }

        public void ReturnCoinToPool(CoinController coin) => _coinPool.ReturnCoin(coin);
    }
}