using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpwaner : MonoBehaviour
{
    //몬스터 Spawn 관련
    public float spawnTime = 0.5f;
    public int mobCount = 10;
    
    //몬스터 관련
    public float mobSpeed = 1000.0f;
    public int mobHealth = 100;
    public int mobRewardCoin = 3;
    public int mobDamage = 10;
    
    public float bossSpeed = 1000.0f;
    public int bossHealth = 1000;
    public int bossRewardSoul = 2;
    public int bossDamage = 50;
    
    public void SpawnMob(int hpIncrease, int waveTime)
    {
        mobCount = (waveTime - 2) * 2;
        StartCoroutine(SpawnMobCoroutine());
    }

    public void SpawnBoss()
    {
        bossHealth += 1000;
        StartCoroutine(SpawnBossCoroutine());
    }
    
    IEnumerator SpawnMobCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < mobCount; ++i)
        {
            GameObject curMob = Managers.Resource.Instantiate("Mob",transform);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1.0f);
    }
    
    IEnumerator SpawnBossCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        Managers.Resource.Instantiate("Boss",transform);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        foreach (Transform child in transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
    }
}
