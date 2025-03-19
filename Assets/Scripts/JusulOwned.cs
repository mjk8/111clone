using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JusulOwned : MonoBehaviour
{
    public Player _player;
    
    //새로운 주술 구매 비용
    private int _newJusulCost = 20;
    //소환확률 강화 레벨
    private int _summonLevel = 0;
    
    //jusulList[랭크][타입] = 보유 주술 수
    List<List<int>> _jusulList = new List<List<int>>();
    

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

    public void playerJusulAdd()
    {
        if (Managers.Player.DecreasePlayerCoins(_newJusulCost, _player))
        {
            Managers.UI.statusUI.UpdateCoinNum(_player.GetCoin());
            AddThisJusul(Managers.Jusul.GetRandomJusul(_summonLevel));
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

    #region Helper

    private void AddThisJusul(Tuple<int, int> newVal)
    {
        ++_jusulList[newVal.Item1][newVal.Item2];
    }

    #endregion
}
