using UnityEngine;
using Player;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Scriptable Objects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public PlayerView PlayerView;
    public Vector3 SpawnPosition;
    public float PlayerMoveSpeed;
}
