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
    [SerializeField] static int _currentWave = 0;
    
    //몬스터 스폰 데이터
    List<MobSpwaner> _mobSpwaners;
    private int _bossWaveFrequency = 10; //보스 웨이브 주기
    private int _MaxWave = 20; //최대 웨이브
    private int _bossHealth = 100000;
    private int _mobHealthIncrease = 100;
    

    public void Awake()
    {
        _mobSpwaners= new List<MobSpwaner>(FindObjectsOfType<MobSpwaner>());;
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
            Managers.UI.statusUI.UpdateSecondsNum((int)Math.Floor(_waveTime));
        }
    }
    
    public List<bool> _isPlayerDead = new List<bool>(){ false, false, false, false };
    public void GameOver(Player player)
    {
        Debug.Log("Player " + player.name + " is dead");
        foreach (var p in Managers.Player._players)
        {
            _isPlayerDead[Managers.Player._players.IndexOf(p)] = true;
        }
        if (player.name == "MyPlayer")
        {
            //TODO:: GameOver UI
            Managers.Resource.Destroy(player.transform.parent.GetChild(0).gameObject);
            Managers.Resource.Destroy(player.gameObject);
            Application.Quit();
        }
        else
        {
            //delete mob spawner and player
            Managers.Resource.Destroy(player.transform.parent.GetChild(0).gameObject);
            Managers.Resource.Destroy(player.gameObject);
        }
    }

    #region Wave
    void EndWave()
    {
        if(_currentWave == 0){}
        else if (_currentWave%_bossWaveFrequency == 0)
        {
            Managers.Player.AddSoulsToAllPlayers(_waveRewardSoul);
        }
        else{
            Managers.Player.AddCoinsToAllPlayers((_waveRewardCoin));
        }
        ++_currentWave;
        Managers.UI.statusUI.UpdateWaveNum(_currentWave);
    }
    void StartWave()
    {
        Debug.Log("Wave " + _currentWave + " Start");
        //TODO:: 신규 웨이브 Alert
        
        //게임 클리어
        if (_currentWave > _MaxWave)
        {
            //TODO:: GameClear UI
        }

        //3 웨이브 마다 시간이 2초 늘어남
        if (_currentWave % 3 == 0)
        {
            _waveTotalTime += 2.0f;
        }
        
        //보스 웨이브
        if (_currentWave % _bossWaveFrequency == 0){
            _waveTime = _waveBossTotalTime;
        }
        else
        {
            _waveTime = _waveTotalTime;
        }
        
        //몬스터 스폰
        foreach (var VARIABLE in _mobSpwaners)
        {
            if(VARIABLE == null) continue;
            if (_currentWave % _bossWaveFrequency == 0){
                VARIABLE.SpawnBoss();
            }

            else{
                VARIABLE.SpawnMob(_mobHealthIncrease,(int)_waveTotalTime);
            }
        }
    }
    #endregion
}
