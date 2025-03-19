using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boss : Monster
{
    private int soul = 2;
    
    
    void OnEnable()
    {
        base.OnEnable();
        soul = _mobSpwaner.bossRewardSoul;
    }
    
    protected void Attacked(int damage, Define.JusulType jusulType)
    {
        base.Attacked(damage,jusulType);
        _healthText.color = Color.white;
        _healthText.text = health.ToString();
    }

    private void OnDestroy()
    {
        base.OnDestroy();
        Managers.Player.AddSoulToPlayer(soul,_player);
    }
}