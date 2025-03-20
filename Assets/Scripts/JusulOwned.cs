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
    public int _summonLevel = 0;
    public int jusulEarthDamageLevel = 0;
    public int jusulWaterDamageLevel = 0;
    public int shinSuUpgradeLevel = 0;

    private void Awake()
    {
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
    public void playerJusulAdd()
    {
        if (Managers.Player.DecreasePlayerCoins(_newJusulCost, _player))
        {
            ++_newJusulCost;
            _jusulSummonCostText.text = _newJusulCost.ToString();
            Managers.UI.statusUI.UpdateCoinNum(_player.GetCoin());
            AddThisJusul(Managers.Jusul.GetRandomJusul(_summonLevel, _summonLevel));
        }
        else
        {
            //TODO:: 돈이 부족합니다 alert.
        }
    }

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
}
