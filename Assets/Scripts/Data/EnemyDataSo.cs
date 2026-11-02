using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]
public class EnemyDataSo : ScriptableObject
{
    public float maxHealth = 100f;
    public float moveSpeed = 1.5f;
    public float patrolDistance = 3f;
}
