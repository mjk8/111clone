using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotLogic : MonoBehaviour
{
    public JusulOwned _jusulOwned;
    public Player _player;

    private bool shinsu1 = false;
    private bool shinsu2 = false;
    private void Start()
    {
        _jusulOwned = GetComponent<JusulOwned>();
        _player = GetComponent<Player>();
        while (_jusulOwned.playerJusulAdd());
    }
    
    /// <summary>
    /// 봇 로직. 코인이 추가될때마다 주술을 생성하고, 주술을 합친다.
    /// Player.cs의 AddCoin 함수에서 호출된다.
    /// </summary>
    public void JusulUpgradeBot()
    {
        while(_player.GetCoin()>_jusulOwned._newJusulCost)
        {
            _jusulOwned.playerJusulAdd();
        }

        if (!shinsu1)
        {
            shinsu1 = _player.jusulOwned.Shinsu1()>2?true:false;
        }
        if (!shinsu2)
        {
            shinsu2 = _player.jusulOwned.Shinsu2()>2?true:false;
        }
        for(int i = 0;i<_jusulOwned._jusulList.Count;i++)
        {
            for(int j = 0;j<_jusulOwned._jusulList[i].Count;j++)
            {
                while (_jusulOwned._jusulList[i][j] > 2)
                {
                    _jusulOwned.playerJusulMerge(i,j);
                    if (!shinsu1)
                    {
                        shinsu1 = _player.jusulOwned.Shinsu1()>2?true:false;
                    }
                    if (!shinsu2)
                    {
                        shinsu2 = _player.jusulOwned.Shinsu2()>2?true:false;
                    }
                }
            }
        }
    }
}
