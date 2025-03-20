using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shinsu : MonoBehaviour
{
    Player _player;
    [SerializeField] private TMP_Text textReq;
    private Button button;

    void Start()
    {
        _player = Managers.Player._myPlayer;
        button = GetComponent<Button>();
    }
    
    public void Shinsu1Button()
    {
        int req = _player.jusulOwned.Shinsu1();
        if(req>2)
        {
            button.interactable = false;
            textReq.text = "소환 완료";
        }
        else
        {
            textReq.text = req.ToString()+"/3";
        }
    }
    
    public void Shinsu2Button()
    {
        int req = _player.jusulOwned.Shinsu2();
        if(req>2)
        {
            button.interactable = false;
            textReq.text = "소환 완료";
        }
        else
        {
            textReq.text = req.ToString()+"/3";
        }
    }
}
