using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    Slider _slider;

    public void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0f;
    }

    public void Init(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }
    
    public void DecreaseHealth(int amount)
    {
        _slider.value = Math.Max(_slider.value-amount,0f);
    }
}
