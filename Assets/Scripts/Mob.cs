using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mob : Monster
{
    private int coin = 3;
    
    void OnEnable()
    {
        base.OnEnable();
        coin = _mobSpwaner.mobRewardCoin;
    }

    protected void Attacked(int damage, Define.JusulType jusulType)
    {
        base.Attacked(damage,jusulType);
        _healthText.color = Managers.Jusul.JusulDamageColor(jusulType);
        _healthText.text = health.ToString();
    }

    private void OnDestroy()
    {
        base.OnDestroy();
        Managers.Player.AddCoinToPlayer(coin,_player);
    }
}
