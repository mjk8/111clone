using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public Player _myPlayer; //내 데디서버 플레이어
    public List<Player> _players = new List<Player>(); //모든 플레이어
    
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
            player.AddCoin(coins);
        }
    }
    
    public void AddCoinToPlayer(int coins, Player player)
    {
        player.AddCoin(coins);
    }
    
    public void AddSoulsToAllPlayers(int souls)
    {
        foreach (var player in _players)
        {
            player.AddSoul(souls);
        }
    }
    
    public void AddSoulToPlayer(int souls, Player player)
    {
        player.AddSoul(souls);
    }

    public void DecreasePlayerHealth(int health, Player player)
    {
        player.DecreaseHealth(health);
    }
}
