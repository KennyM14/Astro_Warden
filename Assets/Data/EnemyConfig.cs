using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Enemies/Enemy Config", order = 0)]
public class EnemyConfig : ScriptableObject
{
    public float moveSpeed;
    public Sprite sprite; 
}
