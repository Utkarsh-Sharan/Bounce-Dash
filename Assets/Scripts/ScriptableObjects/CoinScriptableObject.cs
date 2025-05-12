using UnityEngine;
using Coin;

[CreateAssetMenu(fileName = "CoinScriptableObject", menuName = "Scriptable Objects/CoinScriptableObject")]
public class CoinScriptableObject : ScriptableObject
{
    public CoinView CoinView;
    public Vector3 CoinSpawnPosition;
    public int CoinValue;
    public float CoinSpeed;
    public float CoinSpawnRate;
    public int InitialCoinCount;
}
