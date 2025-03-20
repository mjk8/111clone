using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JusulOwned : MonoBehaviour
{
    public Player _player;
    
    //새로운 주술 구매 비용
    public int _newJusulCost = 20;

    //jusulList[랭크][타입] = 보유 주술 수
    public List<List<int>> _jusulList = new List<List<int>>();

    //주술 강화 레벨
    public int _summonLevel;
    public int jusulEarthDamageLevel;
    public int jusulWaterDamageLevel;
    public int shinSuUpgradeLevel;

    private void Awake()
    {
        _summonLevel = 0;
        jusulEarthDamageLevel = 1;
        jusulWaterDamageLevel = 1;
        shinSuUpgradeLevel = 1;
        //주술 보유 초기화
        for (int i = 0; i < Util.GetNumberOfItemsInEnum<Define.JusulRank>(); i++)
        {
            _jusulList.Add(new List<int>());
            for (int j = 0; j < Util.GetNumberOfItemsInEnum<Define.JusulType>(); j++)
            {
                _jusulList[i].Add(0);
            }
        }
    }

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    [SerializeField] private TMP_Text _jusulSummonCostText;
    
    /// <summary>
    /// 주술 생성
    /// </summary>
    /// <returns></returns>
    public bool playerJusulAdd()
    {
        if (Managers.Player.DecreasePlayerCoins(_newJusulCost, _player))
        {
            ++_newJusulCost;
            // 플레이어라면 UI 업데이트
            if (_player == Managers.Player._myPlayer)
            {
                _jusulSummonCostText.text = _newJusulCost.ToString();
                Managers.UI.statusUI.UpdateCoinNum(_player.GetCoin());
            }

            AddThisJusul(Managers.Jusul.GetRandomJusul(_summonLevel, _summonLevel));
            return true;
        }
        else
        {
            //TODO:: 돈이 부족합니다 alert.
            return false;
        }
    }

    /// <summary>
    /// 주술 합성
    /// </summary>
    /// <param name="jusulRank"></param>
    /// <param name="jusulType"></param>
    public void playerJusulMerge(int jusulRank, int jusulType)
    {
        if(_jusulList[jusulRank][jusulType] >= 3)
        {
            _jusulList[jusulRank][jusulType] -= 3;
            AddThisJusul(Managers.Jusul.GetNextRankJusul(jusulRank));
        }
    }

    public void AddThisJusul(Tuple<int, int> newVal)
    {
        ++_jusulList[newVal.Item1][newVal.Item2];
        Managers.UI.jusulUI.UpdateUI();
    }
    
    public int Shinsu1()
    {
        int condition = 0;
        if (_jusulList[1][1] > 0) condition++;
        if (_jusulList[2][1] > 0) condition++;
        if (_jusulList[3][0] > 0) condition++;
        if (condition>2)
        {
            transform.parent.Find("Shinsu1").gameObject.SetActive(true);
            StartCoroutine(Shinsu1Skill());
        }

        return condition;
    }
    
    public int Shinsu2()
    {
        int condition = 0;
        if (_jusulList[1][0] > 0) condition++;
        if (_jusulList[2][0] > 0) condition++;
        if (_jusulList[3][1] > 0) condition++;
        if (condition>2)
        {
            transform.parent.Find("Shinsu2").gameObject.SetActive(true);
            StartCoroutine(Shinsu2Skill());
        }

        return condition;
    }
    
    IEnumerator Shinsu1Skill()
    {
        while (_player!=null)
        {
            _player.AddCoin(70*shinSuUpgradeLevel);
            yield return new WaitForSeconds(50);
        }
    }

    IEnumerator Shinsu2Skill()
    {
        while (_player!=null)
        {
            _player.HealByPercentage(15*shinSuUpgradeLevel);
            yield return new WaitForSeconds(40);
        }
    }
}
