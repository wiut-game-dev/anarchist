using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy State")]
public class EnemyState : ScriptableObject
{
    public bool LineOfSight;
    
    public float Health;
    public float MaxHealth;
    public float Cooldown;
    public float Damage;
    public float AttackSpeed;
    public float AttackRange;
    public float Multiplier;
    public float Speed;
    public float SightDistance;
    
    public Vector2 moveDirection;

    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
