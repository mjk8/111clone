using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mob : Monster
{
    private int coin = 3;

    public void OnEnable()
    {
        base.OnEnable();
        coin = _mobSpwaner.mobRewardCoin;
    }

    private void Start()
    {
        if (_healthText == null)
        {
            _healthText = GetComponentInChildren<TMP_Text>();
        }

        _healthText.enabled = false;
    }

    protected void Attacked(int damage, Define.JusulType jusulType)
    {
        base.Attacked(damage,jusulType);
        StopCoroutine(FadeOut());
        _healthText.color = Managers.Jusul.JusulDamageColor(jusulType);
        _healthText.text = health.ToString();
        _healthText.enabled = true;
        StartCoroutine(FadeOut());
    }

    private void OnDestroy()
    {
        base.OnDestroy();
        Managers.Player.AddCoinToPlayer(coin,_player);
        this.enabled = false;
    }
    
    public float fadeDuration = 1.5f;
    /// <summary>
    /// 데미지 텍스트가 자연스레 사라지도록 페이드 아웃 효과를 적용
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut()
    {
        // Get the initial color of the text
        Color originalColor = _healthText.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate new alpha value based on elapsed time
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            _healthText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Ensure the text is completely transparent at the end
        _healthText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
