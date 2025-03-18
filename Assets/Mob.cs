using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mob : MonoBehaviour
{
    private float moveSpeed = 10f;
    private int health = 100;
    private int damage = 10;
    private int coin = 3;
    
    MobSpwaner _mobSpwaner;
    Player _player;
    Rigidbody2D _rigidbody2D;
    
    bool isPlayerCollide = false;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        _rigidbody2D.MovePosition(transform.parent.position);
        _mobSpwaner = transform.parent.GetComponent<MobSpwaner>();
        _player = transform.parent.parent.GetComponentInChildren<Player>();
        moveSpeed = _mobSpwaner.mobSpeed;
        health = _mobSpwaner.mobHealth;
        damage = _mobSpwaner.mobDamage;
        coin = _mobSpwaner.mobRewardCoin;
    }
    private void FixedUpdate()
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.CompareTag("Player"))
        {
            isPlayerCollide = true;
            StartCoroutine(AttackPlayer());
        }
    }

    IEnumerator AttackPlayer()
    {
        while (isPlayerCollide)
        {
            Managers.Player.DecreasePlayerHealth(damage,_player);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void OnDestroy()
    {
        Managers.Player.AddCoinToPlayer(coin,_player);
        isPlayerCollide = false;
        StopCoroutine(AttackPlayer());
    }
}
