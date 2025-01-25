using UnityEngine;

[CreateAssetMenu(menuName = "GameState")]
public class WorldState : ScriptableObject
{
	public int EnemiesKilled;
	public int EnemiesSpawned;
	public int EnemiesLeft;
	public int EnemiesAlive;
}
