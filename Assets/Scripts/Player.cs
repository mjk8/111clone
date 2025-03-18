using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp;
    private int maxHp = 1000;
    private int coin;
    private int soul;
    
    // Start is called before the first frame update
    void Start(){
        hp = maxHp;
    }
    
    public bool SpendCoin(int amount){
        if (coin - amount < 0)
        {
            //TODO:: NOT ENOUGH COIN ALERT
            return false;
        }
        coin -= amount;
        return true;
    }

    public bool SpendSoul(int amount)
    {
        if (soul - amount < 0)
        {
            //TODO:: NOT ENOUGH SOUL ALERT
            return false;
        }
        return true;
    }

    public void AddCoin(int amount){
        coin += amount;
    }
    
    public void AddSoul(int amount){
        soul += amount;
    }
}
