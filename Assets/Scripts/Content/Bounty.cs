using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounty : Boss
{
    int coins;
    public void SetBounty(bool isCoinReward, int amount, int hp)
    {
        health = hp;
        if (isCoinReward)
        {
            soul = 0;
            coins = amount;
        }
        else
        {
            soul = amount;
        }
    }
    
    void OnDestroy()
    {
        base.OnDestroy();
        if (coins > 0)
        {
            Managers.Player.AddCoinToPlayer(coins, _player);
        }
    }
}
