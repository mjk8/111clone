using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enhance : MonoBehaviour
{
    public void ButtonProbEnhance()
    {
        if (Managers.Player.DecreasePlayerCoins(500, Managers.Player._myPlayer))
        {
            transform.GetChild(0).GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "구매완료";
            transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            Managers.Jusul.JusulProbabilityUpgrade();
        }
    }
    
    public void ButtonWaterJusulEnhance()
    {
        if (Managers.Player.DecreaseMyPlayerSoul(1))
        {
            transform.GetChild(1).GetComponent<Button>().interactable = false;
            transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "구매완료";
            transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            Managers.Player._myPlayer.jusulOwned.jusulWaterDamageLevel=2;
        }
    }
    
    public void ButtonEarthJusulEnhance()
    {
        if (Managers.Player.DecreaseMyPlayerSoul(1))
        {
            transform.GetChild(2).GetComponent<Button>().interactable = false;
            transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "구매완료";
            transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            Managers.Player._myPlayer.jusulOwned.jusulEarthDamageLevel = 2;
        }
    }
    
    public void ButtonShinSuEnhance()
    {
        if (Managers.Player.DecreaseMyPlayerSoul(1))
        {
            transform.GetChild(3).GetComponent<Button>().interactable = false;
            transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "구매완료";
            transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            Managers.Player._myPlayer.jusulOwned.shinSuUpgradeLevel =2;
        }
    }
}
