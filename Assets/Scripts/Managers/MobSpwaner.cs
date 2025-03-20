using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpwaner : MonoBehaviour
{
    //몬스터 Spawn 관련
    public float spawnTime = 0.5f;
    public int mobCount = 10;
    
    //현상금 관련
    public int rewardCoin = 200;
    public int rewardSoul = 1;
    public float coolTime = 60f;
    public float BountyTimer = 0.0f;
    
    //몬스터 관련
    public float mobSpeed = 1000.0f;
    public int mobHealth = 100;
    public int mobRewardCoin = 3;
    public int mobDamage = 10;
    
    public float bossSpeed = 1000.0f;
    public int bossHealth = 1000;
    public int bossRewardSoul = 2;
    public int bossDamage = 50;
    
    
    //현상금 스폰 시간
    private float _bountySpawnTime = 60.0f;
    private float _bountyTimer = 0.0f;
    
    private void Update()
    {
        if(_bountyTimer >= 0)
        {
            _bountyTimer -= Time.deltaTime;
            Managers.UI.UpdateBountyTimerText(_bountyTimer);
        }
    }

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
            curMob.GetComponent<Mob>().enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1.0f);
    }
    
    IEnumerator SpawnBossCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject curMob = Managers.Resource.Instantiate("Boss",transform);
        curMob.GetComponent<Boss>().enabled = true;
    }

    
    /// <summary>
    /// 현상금 몬스터를 소환하는 기본 함수
    /// </summary>
    public void SpawnBounty(bool isCoin = true, int rewardCoin = 200, int hp = 250000)
    {
        if(_bountyTimer > 0)
        {
            return;
        }
        _bountyTimer = _bountySpawnTime;
        GameObject curMob = Managers.Resource.Instantiate("Bounty", transform);
        Bounty bounty = curMob.GetComponent<Bounty>();
        bounty.SetBounty(true,rewardCoin,rewardSoul);
    }
    
    // 200코인 현상금
    public void SpawnBounty1()
    {
        SpawnBounty(true,200,25000);
    }
    
    // 1영혼 현상금
    public void SpawnBounty2()
    {
        SpawnBounty(false,1,50000);
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
