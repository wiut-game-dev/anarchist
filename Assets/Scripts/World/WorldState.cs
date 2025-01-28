using UnityEngine;

[CreateAssetMenu(menuName = "GameState")]
public class WorldState : ScriptableObject
{
	public int EnemiesKilled;
	public int EnemiesSpawned;
	public int EnemiesLeft;
	public int EnemiesAlive;
	public float MaxDistance;
	public float LeftX;
	public float RightX;
	public float TopY;
	public float BottomY;
	public float StepX;
	public float StepY;
	public float CameraThreshold;
}
