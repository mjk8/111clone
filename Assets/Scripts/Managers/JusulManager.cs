using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 주술 시스템 관련 매니저.
/// 인게임 스킬 구현 및 각 플레이어 보유 주술은 JusulOwned로 구현.
/// 
/// </summary>
public class JusulManager
{
    //주술 색깔
    List<Color> _jusulColor = new List<Color>();
    //주술 업그레이드 전 확률
    List<float> _jusulInitialUpgradeChance = new List<float>{ 0.8498f,0.1132f,0.03f,0.005f,0.002f,0f};
    //주술 업그레이드 후 확률
    List<float> _jusulUpgradedChance = new List<float>{0.366f,0.2f,0.2f,0.14f,0.062f,0.032f};
    
    public List<float> _coolTime;
    
    //플레이어들에게 주술 정보가 할당 되기 전, 주술 관련 정보가 init되어야함.
    public void Init()
    {
        
        
        _jusulColor.Add(Color.white);
        _jusulColor.Add(Color.green);
        _jusulColor.Add(Color.cyan);
        _jusulColor.Add(Color.magenta);
        _jusulColor.Add(Color.yellow);
        _jusulColor.Add(Color.red);
        
        _coolTime = new List<float>();
        _coolTime.Add(1.3f);
        _coolTime.Add(4f);
        _coolTime.Add(10f);
        _coolTime.Add(2.5f);
        _coolTime.Add(4f);
        _coolTime.Add(10f);
        _coolTime.Add(0.8f);
        _coolTime.Add(3f);
        _coolTime.Add(1f);
        _coolTime.Add(3f);
        _coolTime.Add(1.5f);
        _coolTime.Add(3f);
    }

    public void ActivateJusul()
    {
        
    }

    public Color JusulDamageColor(Define.JusulType jusulType)
    {
        if (jusulType == Define.JusulType.땅)
        {
            return Color.green;
        }
        else
        {
            return Color.cyan;
        }
    }

    /// <summary>
    /// 주술 생성: 확률에 따라 랜덤 랭크의 랜덤 속성 주술 반환
    /// </summary>
    /// <param name="jusulRank">업그레이드 하는 주술 랭크</param>
    /// <returns></returns>
    public Tuple<int,int> GetRandomJusul(int jusulUpgradeChance, int jusulProbability = 0)
    {
        if (jusulProbability > 0)
        {
            return new Tuple<int, int>(GetRandomJusulRank(_jusulUpgradedChance),GetRandomJusulType());
        }
        //소환확률 강화에 따른 확률 변동 추가
        return new Tuple<int, int>(GetRandomJusulRank(_jusulInitialUpgradeChance),GetRandomJusulType());
    }
    
    /// <summary>
    /// 채굴: 해당 랭크의 랜덤 속성 주술 반환
    /// </summary>
    /// <param name="jusulRank">업그레이드 하는 주술 랭크</param>
    /// <returns></returns>
    public Tuple<int,int> MineRankJusul(int jusulRank)
    {
        return new Tuple<int, int>(jusulRank,GetRandomJusulType());
    }
    
    /// <summary>
    /// 주술 합성: 다음 랭크의 랜덤 속성 주술 반환
    /// </summary>
    /// <param name="jusulRank">업그레이드 하는 주술 랭크</param>
    /// <returns></returns>
    public Tuple<int,int> GetNextRankJusul(int jusulRank)
    {
        if (jusulRank>= Util.GetNumberOfItemsInEnum<Define.JusulRank>())
        {
            Debug.Log("BUG: 최종 단계 주술을 업그레이드 시도");
            return null;
        }
        return new Tuple<int, int>(jusulRank+1,GetRandomJusulType());
    }

    public void JusulProbabilityUpgrade()
    {
        Managers.Player._myPlayer.jusulOwned._summonLevel = 2;
    }

    //확률 등의, 헬퍼 함수
    #region JusulHelperFunctions
    
    private int GetRandomJusulType()
    {
        return UnityEngine.Random.Range(0, 2);
    }
    
    private int GetRandomJusulRank(List<float> jusulUpgradeChance)
    {
        float random = Util.GetRandomNumberOutOf100();
        float sum = 0;
        for (int i = 0; i < jusulUpgradeChance.Count; i++)
        {
            sum += jusulUpgradeChance[i]*100;
            if (random <= sum)
            {
                return i;
            }
        }
        return jusulUpgradeChance.Count - 1;
    }

    #endregion
}
