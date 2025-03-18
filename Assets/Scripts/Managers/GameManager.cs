using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    
    public static GameObject root;
    
    //웨이브 관련 데이터
    private float _waveTotalTime = 10f;
    private float _waveBossTotalTime = 30f;
    private float _waveTime = 0f;
    private int _waveRewardCoin = 40;
    private int _waveRewardSoul = 2;
    public static int _currentWave = 0;
    
    //몬스터 스폰 데이터
    MobSpwaner[] _mobSpwaners;
    private int _bossWaveFrequency = 10;
    private int _bossHealth = 100000;
    private int _mobHealthIncrease = 100;
    

    public void Start()
    {
        _mobSpwaners= FindObjectsOfType<MobSpwaner>();;
        //게임 준비 시간
        _waveTime = 2.0f;
    }

    void Update()
    {
        if (_waveTime <= 0)
        {
            EndWave();
            StartWave();
        }
        else
        {
            _waveTime -= Time.deltaTime;
        }
    }

    void EndWave()
    {
        if (_currentWave%_bossWaveFrequency == 0)
        {
            Managers.Player.AddSoulsToAllPlayers(_waveRewardSoul);
        }
        else{
            Managers.Player.AddCoinsToAllPlayers((_waveRewardCoin));
        }
    }
    void StartWave()
    {
        ++_currentWave;
        //TODO:: 신규 웨이브 Alert
        Debug.Log($"Wave {_currentWave} Start");
        
        //3 웨이브 마다 시간이 2초 늘어남
        if (_currentWave % 3 == 0)
        {
            _waveTotalTime += 2.0f;
        }
        foreach (var VARIABLE in _mobSpwaners)
        {
            if (_currentWave % _bossWaveFrequency == 0){
                
                _waveTime = _waveBossTotalTime;
                VARIABLE.SpawnBoss();
            }

            else{
                _waveTime = _waveBossTotalTime;
                VARIABLE.SpawnMob();
            }
        }
    }
}
