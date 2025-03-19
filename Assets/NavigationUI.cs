using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NavigationUI : MonoBehaviour
{
    [SerializeField] Transform _gameplayInteractionPanel;
    [SerializeField] Transform _extraInteractionPanel;

    [SerializeField] TMP_Text jusulSummonCost; 
        
    int _isExtraPanelActive = -1;
    
    
    //만약 extra panel이 활성화 되면 _gameplayInteractionPanel을 _extraInteractionPanel의 RectTransform Height만큼 위로 옮겨야함.
    public void OnExtraPanelActive()
    {
        if (_isExtraPanelActive<0)
        {
            _gameplayInteractionPanel.position += new Vector3(0, _extraInteractionPanel.GetComponent<RectTransform>().rect.height, 0);
        }
        else
        {
            _gameplayInteractionPanel.position -= new Vector3(0, _extraInteractionPanel.GetComponent<RectTransform>().rect.height, 0);
        }
    }

    public void BountyButton()
    {
        
    }

    public void ShinsuButton()
    {
        
    }
    
    public void GetJusulButton()
    {
        Managers.Player._myPlayer.jusulOwned.playerJusulAdd();
        jusulSummonCost.text = Managers.Player._myPlayer.jusulOwned._newJusulCost.ToString();
    }

    public void EnhanceButton()
    {
        
    }
    
    public void MineButton()
    {
        
    }
}
