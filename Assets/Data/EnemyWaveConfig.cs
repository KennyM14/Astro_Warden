using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Enemies/Wave Config", order = 0)]
public class EnemyWaveConfig : ScriptableObject
{
    [Serializable]
    public class EachEnemyConfig
    {
        public EnemyController enemyPrefab;
        public Vector3 spawnPosition;
        public bool useSpecificXPosition; 
    }
    public List<EachEnemyConfig> enemies;
    public float cadence; 
}
