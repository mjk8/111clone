using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NavigationUI : MonoBehaviour
{
    [SerializeField] Transform _gameplayInteractionPanel;
    [SerializeField] Transform _extraInteractionPanel;

    [SerializeField] List<GameObject> _panels;
    [SerializeField] TMP_Text jusulSummonCost; 
        
    int _currentPanel = -1;

    void Start()
    {
        foreach (var p in _panels)
        {
            p.SetActive(false);
        }
    }

    //만약 extra panel이 활성화 되면 _gameplayInteractionPanel을 _extraInteractionPanel의 RectTransform Height만큼 위로 옮겨야함.
    public void ChangePanel(int panelNum)
    {
        if (_currentPanel<0)
        {
            _gameplayInteractionPanel.position += new Vector3(0, _extraInteractionPanel.GetComponent<RectTransform>().rect.height, 0);
            _currentPanel = panelNum;
            _panels[_currentPanel].SetActive(true);
        }
        
        else if (_currentPanel>=0 && panelNum<0)
        {
            _gameplayInteractionPanel.position -= new Vector3(0, _extraInteractionPanel.GetComponent<RectTransform>().rect.height, 0);
            _panels[_currentPanel].SetActive(false);
            _currentPanel = panelNum;
        }
            
        else
        {
            _panels[_currentPanel].SetActive(false);
            _currentPanel = panelNum;
            _panels[_currentPanel].SetActive(true);
        }
    }
    
    #region Navigation Buttons
    public void BountyButton()
    {
        if (_currentPanel != 0)
        {
            ChangePanel(0);
        }
        else
        {
            ChangePanel(-1);
        }
    }

    public void ShinsuButton()
    {
        if (_currentPanel != 1)
        {
            ChangePanel(1);
        }
        else
        {
            ChangePanel(-1);
        }
    }
    
    public void GetJusulButton()
    {
        Managers.Player._myPlayer.jusulOwned.playerJusulAdd();
        jusulSummonCost.text = Managers.Player._myPlayer.jusulOwned._newJusulCost.ToString();
    }

    public void EnhanceButton()
    {
        if (_currentPanel != 2)
        {
            ChangePanel(2);
        }
        else
        {
            ChangePanel(-1);
        }
    }
    
    public void MineButton()
    {
        if (_currentPanel != 3)
        {
            ChangePanel(3);
        }
        else
        {
            ChangePanel(-1);
        }
    }
    #endregion
}
