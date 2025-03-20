using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JusulSpawner : MonoBehaviour
{
    private JusulOwned _jusulOwned;
    private Transform _mobs;
    private List<float> _coolTime = new List<float>();
    private Player _player;
    void Start()
    {
        _jusulOwned = transform.parent.GetComponentInChildren<JusulOwned>();
        _player = transform.parent.GetComponentInChildren<Player>();
        _mobs = transform.parent.Find("SpawnPoint");
        for (int i = 0; i < 12; ++i)
        {
            _coolTime.Add(0);
        }
    }
    
    void Update()
    {
        for (int i = 0; i < _jusulOwned._jusulList.Count; ++i)
        {
            for (int j = 0;j < _jusulOwned._jusulList[i].Count; ++j)
            {
                if (_jusulOwned._jusulList[i][j] == 0)
                {
                    _coolTime[j * 2 + i] = 0;
                }
                else
                {
                    if(_coolTime[j * 2 + i] > 0)
                    {
                        _coolTime[j * 2 + i] -= Time.deltaTime;
                    }
                    else
                    {
                        if (i == 0 && j == 0)
                        {
                            Earth0();
                            Debug.Log(_player.name + " used 주술: 땅 일반");
                        }

                        if (i == 1 && j == 0)
                        {
                            Earth1();
                            Debug.Log(_player.name + " used 주술: 땅 희귀");
                        }
                        
                        if (i == 2 && j == 0)
                        {
                            Earth2();
                            Debug.Log(_player.name + " used 주술: 땅 영웅");
                        }
                        
                        if (i == 3 && j == 0)
                        {
                            Earth3();
                            Debug.Log(_player.name + " used 주술: 땅 전설");
                        }
                        
                        if (i == 4 && j == 0)
                        {
                            Earth4();
                            Debug.Log(_player.name + " used 주술: 땅 선조");
                        }
                        
                        if (i == 5 && j == 0)
                        {
                            Earth5();
                            Debug.Log(_player.name + " used 주술: 땅 천벌");
                        }
                        
                        if (i == 0 && j == 1)
                        {
                            Water0();
                            Debug.Log(_player.name + " used 주술: 물 일반");
                        }
                        
                        if (i == 1 && j == 1)
                        {
                            Water1();
                            Debug.Log(_player.name + " used 주술: 물 희귀");
                        }
                        
                        if (i == 2 && j == 1)
                        {
                            Water2();
                            Debug.Log(_player.name + " used 주술: 물 영웅");
                        }
                        
                        if (i == 3 && j == 1)
                        {
                            Water3();
                            Debug.Log(_player.name + " used 주술: 물 전설");
                        }
                        
                        if (i == 4 && j == 1)
                        {
                            Water4();
                            Debug.Log(_player.name + " used 주술: 물 선조");
                        }
                        
                        if (i == 5 && j == 1)
                        {
                            Water5();
                            Debug.Log(_player.name + " used 주술: 물 천벌");
                        }


                        _coolTime[(j * 6) + i] = (Managers.Jusul._coolTime[(j * 6) + i]/_jusulOwned._jusulList[i][j]);
                    }
                }
            }
        }
    }

    #region JusulSkill

    private int closeRange = 50;
    //스킬들
    public void Earth0()
    {
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) - (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y));
            if (verticalDistance < closeRange)
            {
                _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                    320 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2: 1),
                    Define.JusulType.땅);
            }
        }
    }
    
    public void Earth1()
    {
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) - (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y));
            if (verticalDistance < closeRange)
            {
                _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                    1700 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2 : 1),
                    Define.JusulType.땅);
            }
        }
    }
    
    
    public void Earth2()
    {
        //체력 보호막
        _player.IncrementHealthShield();
        for(int i = 0;i<Math.Min(_mobs.childCount,1); ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                8500 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2: 1),
                Define.JusulType.땅);
        }
    }

    public void Earth3()
    {
        bool flag = false;
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) - (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y));
            if (verticalDistance < closeRange)
            {
                flag = true;
                _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                    7150 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2 : 1),
                    Define.JusulType.땅);
            }
        }

        if (flag)
        {
            _player.HealByPercentage(1);
        }
    }
    
    public void Earth4()
    {
        int extra = _player.GetHealthShield();
        if (_mobs.childCount <= 5 + extra)
        {
            for(int i = 0;i<_mobs.childCount; ++i)
            {
                _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                    340000 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2: 1),
                    Define.JusulType.땅);
            }
        }
        else
        {
            System.Random random = new System.Random(); //다양한 랜덤 값을 얻기 위해 같은 변수를 사용
            for(int i = 0;i<5+extra; ++i)
            {
                _mobs.GetChild(random.Next(0, _mobs.childCount)).GetComponent<Monster>().Attacked(
                    8500 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2 : 1),
                    Define.JusulType.땅);
            }
        }
    }
    
    public void Earth5()
    {
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            if (i == 0)
            {
                _mobs.GetChild(0).GetComponent<Monster>().Attacked(
                    320000 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2 : 1),
                    Define.JusulType.땅);
                continue;
            }
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                32000 * (_jusulOwned.jusulEarthDamageLevel > 0 ? 2 : 1),
                Define.JusulType.땅);
        }
    }
    
    public void Water0()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,1); ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(143*(_jusulOwned.jusulWaterDamageLevel>0?2:1), Define.JusulType.물);
        }
    }
    
    public void Water1()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,5); ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(520*(_jusulOwned.jusulWaterDamageLevel>0?2:1), Define.JusulType.물);
        }
    }
    
    public void Water2()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,1); ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().SlowDown(2);
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(2500*(_jusulOwned.jusulWaterDamageLevel>0?2:1), Define.JusulType.물);
        }
    }
    
    //TODO:: 수정해야함
    public void Water3()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,5); ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().SlowDown(2);
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(2500*(_jusulOwned.jusulWaterDamageLevel>0?2:1), Define.JusulType.물);
        }
    }
    
    public void Water4()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,1); ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(75000*(_jusulOwned.jusulWaterDamageLevel>0?2:1), Define.JusulType.물);
        }
    }
    
    public void Water5()
    {
        int attack = 96000*(_jusulOwned.jusulWaterDamageLevel>0?2:1);
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            _mobs.GetChild(i).GetComponent<Monster>().Attacked(attack, Define.JusulType.물);
            attack= (int)(attack*0.95f);
        }
    }
    
    #endregion
}
