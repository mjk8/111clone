using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text WaveNum;
    [SerializeField] private TMP_Text CoinNum;
    [SerializeField] private TMP_Text SoulNum;
    [SerializeField] private TMP_Text SecondsNum;
    
    private void Awake()
    {
        WaveNum.text = "0";
        CoinNum.text = "0";
        SoulNum.text = "0";
        SecondsNum.text = "0";
    }

    private void Start()
    {
        UpdateCoinNum(Managers.Player._myPlayer.GetCoin());
        UpdateCoinNum(Managers.Player._myPlayer.GetSoul());
    }

    public void UpdateWaveNum(int wave)
    {
        WaveNum.text = wave.ToString("D2");
    }
    
    public void UpdateCoinNum(int coin)
    {
        CoinNum.text = coin.ToString();
    }
    
    public void UpdateSoulNum(int soul)
    {
        SoulNum.text = soul.ToString();
    }
    
    public void UpdateSecondsNum(int seconds)
    {
        SecondsNum.text = seconds.ToString("D2");
    }
}
