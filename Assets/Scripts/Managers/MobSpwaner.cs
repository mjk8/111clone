using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpwaner : MonoBehaviour
{
    public GameObject MobPrefab;
    public float SpawnTime = 0.5f;
    public int MobCount = 10;
    public float SpawnRange = 10.0f;
    public float MobSpeed = 10.0f;
    public int MobHealth = 100;
    public int MobDamage = 10;
    public int MobRewardCoin = 10;
    public int MobRewardSoul = 10;

    private float _spawnTime = 0.0f;
    private int _mobCount = 0;

    void Start()
    {
        _spawnTime = SpawnTime;
        _mobCount = MobCount;
    }

    public void SpawnMob()
    {
        
    }

    public void SpawnBoss()
    {
        
    }
}
