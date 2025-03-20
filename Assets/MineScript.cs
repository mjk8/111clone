using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    int[] cost = {1,3,7};
    public void Button1()
    {
        if (Managers.Player.DecreaseMyPlayerSoul(cost[0]))
        {
            Managers.Player._myPlayer.jusulOwned.AddThisJusul(Managers.Jusul.MineRankJusul((int)Define.JusulRank.영웅));
        }
    }
    
    public void Button2()
    {
        if (Managers.Player.DecreaseMyPlayerSoul(cost[1]))
        {
            Managers.Player._myPlayer.jusulOwned.AddThisJusul(Managers.Jusul.MineRankJusul((int)Define.JusulRank.전설));
        }
    }
    
    public void Button3()
    {
        if (Managers.Player.DecreaseMyPlayerSoul(cost[2]))
        {
            Managers.Player._myPlayer.jusulOwned.AddThisJusul(Managers.Jusul.MineRankJusul((int)Define.JusulRank.선조));
        }
    }
}
