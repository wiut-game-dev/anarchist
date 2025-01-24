using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Objects/GameState")]
public class GameState : ScriptableObject
{
    public int EnemiesKilled;
    public int EnemiesSpawned;
    public int EnemiesLeft;
    public int EnemiesAlive;
}
