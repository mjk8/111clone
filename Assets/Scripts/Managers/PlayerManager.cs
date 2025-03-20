using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public Player _myPlayer; //내 플레이어
    public List<Player> _players = new List<Player>(); //다른 플레이어들
    
    
    public void Init()
    {
        _myPlayer = GameObject.Find("Player").GetComponent<Player>();
        _players.Add(GameObject.Find("BotPlayer1").GetComponent<Player>());
        _players.Add(GameObject.Find("BotPlayer2").GetComponent<Player>());
        _players.Add(GameObject.Find("BotPlayer3").GetComponent<Player>());
    }
    
    public void AddCoinsToAllPlayers(int coins)
    {
        foreach (var player in _players)
        {
            if(player!=null){
                player.AddCoin(coins);
            }
        }
        Managers.UI.statusUI.UpdateCoinNum(_myPlayer.GetCoin());
    }
    
    public void AddCoinToPlayer(int coins, Player player)
    {
        player.AddCoin(coins);
        if (player == _myPlayer)
        {
            Managers.UI.statusUI.UpdateCoinNum(_myPlayer.GetCoin());
        }
    }
    
    public void AddSoulsToAllPlayers(int souls)
    {
        foreach (var player in _players)
        {
            if (player != null)
            {
                player.AddSoul(souls);
            }
        }
        Managers.UI.statusUI.UpdateSoulNum(_myPlayer.GetSoul());
    }
    
    public void AddSoulToPlayer(int souls, Player player)
    {
        player.AddSoul(souls);
        if (player == _myPlayer)
        {
            Managers.UI.statusUI.UpdateSoulNum(_myPlayer.GetSoul());
        }
    }
    
    public bool DecreasePlayerCoins(int coins, Player player)
    {
        return player.SpendCoin(coins);
    }
    
    public bool DecreaseMyPlayerSoul(int souls)
    {
        if( _myPlayer.SpendSoul(souls) )
        {
            Managers.UI.statusUI.UpdateSoulNum(_myPlayer.GetSoul());
            return true;
        }

        return false;
    }

    public void DecreasePlayerHealth(int health, Player player)
    {
        player.DecreaseHealth(health);
    }
}
