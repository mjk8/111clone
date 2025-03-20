using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp;
    private int maxHp = 1000;
    [SerializeField] private int coin;
    [SerializeField] private int soul;

    public int decreaseHealth;
    public HealthBar healthBar;
    public JusulOwned jusulOwned;
    
    // Start is called before the first frame update
    void Awake()
    {
        jusulOwned = GetComponent<JusulOwned>();
        hp = maxHp;
    }

    private void Start()
    {
        healthBar = transform.parent.GetComponentInChildren<HealthBar>();
        healthBar.Init(maxHp);
    }

    public bool SpendCoin(int amount)
    {
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

    public void AddCoin(int amount)
    {
        coin += amount;
    }

    public void AddSoul(int amount)
    {
        soul += amount;
    }

    public void DecreaseHealth(int amount)
    {
        hp -= amount;
        healthBar.DecreaseHealth(amount);
        if (hp <= 0)
        {
            Debug.Log("Player dead");
            Managers.Game.GameOver(this);
        }
    }
    
    public void Heal(int amount)
    {
        hp += amount;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
    
    #region Getter Methods
    public int GetHp()
    {
        return hp;
    }
    
    public int GetCoin()
    {
        return coin;
    }
    
    public int GetSoul()
    {
        return soul;
    }
    #endregion
}