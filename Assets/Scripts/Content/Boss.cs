using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boss : Monster
{
    protected int soul = 2;
    
    public void OnEnable()
    {
        base.OnEnable();
        soul = _mobSpwaner.bossRewardSoul;
    }

    private void Start()
    {
        if (_healthText == null)
        {
            _healthText = GetComponentInChildren<TMP_Text>();
        }
        _healthText.color = Color.white;
        _healthText.text = health.ToString();
        Managers.Game.bossSpawned++;
    }

    private void OnDestroy()
    {
        base.OnDestroy();
        Managers.Game.bossSpawned--;
        if(Managers.Game.bossSpawned == 0)
        {
            Managers.Game.WaveEnd();
        }
        Managers.Player.AddSoulToPlayer(soul,_player);
    }
}