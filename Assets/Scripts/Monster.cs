using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected float moveSpeed = 10f;
    protected int health = 100;
    protected int damage = 10;
    
    public MobSpwaner _mobSpwaner;
    public Player _player;
    public Rigidbody2D _rigidbody2D;
    
    protected bool isPlayerCollide = false;
    
    protected HealthBar _healthBar;
    protected TMP_Text _healthText;
    
    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _healthBar = transform.GetComponentInChildren<HealthBar>();
        _healthText = _healthBar.GetComponentInChildren<TMP_Text>();
    }
    
    public void OnEnable()
    {
        _mobSpwaner = transform.parent.GetComponent<MobSpwaner>();
        _player = transform.parent.parent.GetComponentInChildren<Player>();
        _rigidbody2D.MovePosition(_mobSpwaner.transform.position);
        _healthBar.Init(health);
        moveSpeed = _mobSpwaner.mobSpeed;
        health = _mobSpwaner.mobHealth;
        damage = _mobSpwaner.mobDamage;
    }
    protected void FixedUpdate()
    {
        if (!isPlayerCollide)
        {
            _rigidbody2D.MovePosition(transform.position+ moveSpeed * Time.deltaTime * Vector3.up);
        }
        else
        {
            _rigidbody2D.MovePosition(transform.position);
        }
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.CompareTag("Player"))
        {
            isPlayerCollide = true;
            StartCoroutine(AttackPlayer());
        }
    }

    protected IEnumerator AttackPlayer()
    {
        while (isPlayerCollide)
        {
            Managers.Player.DecreasePlayerHealth(damage,_player);
            yield return new WaitForSeconds(1.0f);
        }
    }
    
    public void Attacked(int damage, Define.JusulType jusulType)
    {
        health -= damage;
        _healthBar.DecreaseHealth(damage);
        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }
        Debug.Log("Attacked: Mob "+transform.GetSiblingIndex());
    }
    
    public void SlowDown(float slowDownRate)
    {
        if (slowDownRate == 0)
        {
            return;
        }
        moveSpeed *= (1/slowDownRate);
        Debug.Log("SlowedDown: Mob "+transform.GetSiblingIndex());
    }
    
    protected void OnDestroy()
    {
        isPlayerCollide = false;
        StopCoroutine(AttackPlayer());
    }
}
