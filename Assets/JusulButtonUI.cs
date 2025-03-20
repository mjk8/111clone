using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JusulButtonUI : MonoBehaviour
{
    JusulOwned _jusulOwned;

    void Start()
    {
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        _jusulOwned = Managers.Player._myPlayer.jusulOwned;
        for (int i = 0; i < _jusulOwned._jusulList.Count; i++)
        {
            for (int j = 0; j < _jusulOwned._jusulList[i].Count; j++)
            {
                Transform curButton = transform.GetChild(j).GetChild(i);
                //주술 수량 업데이트
                curButton.GetChild(0).GetComponent<TMP_Text>().text = _jusulOwned._jusulList[i][j].ToString();
                //만약 해당 주술이 없다면 투명하게 + 3개 이상이면 합성텍스트 표시
                Color color = curButton.GetComponent<Image>().color;
                
                if (_jusulOwned._jusulList[i][j] > 2)
                {
                    curButton.GetChild(1).GetComponent<TMP_Text>().enabled = true;
                }
                else if(_jusulOwned._jusulList[i][j] > 0)
                {
                    curButton.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);
                    curButton.GetChild(1).GetComponent<TMP_Text>().enabled = false;
                }
                else
                {
                    curButton.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
                    curButton.GetChild(1).GetComponent<TMP_Text>().enabled = false;
                }
            }
        }
    }

    public void ButtonPressed(int i, int j)
    {
        if (_jusulOwned._jusulList[j][i] > 2)
        {
            _jusulOwned.playerJusulMerge(j, i);
            UpdateUI();
        }
    }
    
    public void Button00()
    {
        ButtonPressed(0, 0);
    }
    
    public void Button01()
    {
        ButtonPressed(0, 1);
    }
    
    public void Button02()
    {
        ButtonPressed(0, 2);
    }
    
    public void Button03()
    {
        ButtonPressed(0, 3);
    }
    
    public void Button04()
    {
        ButtonPressed(0, 4);
    }
    
    public void Button05()
    {
        ButtonPressed(0, 5);
    }
    
    public void Button10()
    {
        ButtonPressed(1, 0);
    }
    
    public void Button11()
    {
        ButtonPressed(1, 1);
    }
    
    public void Button12()
    {
        ButtonPressed(1, 2);
    }
    
    public void Button13()
    {
        ButtonPressed(1, 3);
    }
    
    public void Button14()
    {
        ButtonPressed(1, 4);
    }
    
    public void Button15()
    {
        ButtonPressed(1, 5);
    }
}
