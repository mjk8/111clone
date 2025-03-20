using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JusulSpawner : MonoBehaviour
{
    [SerializeField] private JusulOwned _jusulOwned;
    [SerializeField] private Transform _mobs;
    [SerializeField] private List<float> _coolTime = new List<float>();
    [SerializeField] private Player _player;
    void Start()
    {
        _jusulOwned = transform.parent.GetComponentInChildren<JusulOwned>();
        _player = transform.parent.GetComponentInChildren<Player>();
        _mobs = transform.parent.GetChild(0);
        for (int i = 0; i < 12; ++i)
        {
            _coolTime.Add(0);
        }
    }
    
    void Update()
    {
        if (_player == null)
        {
            Destroy(this);
        }
        for (int i = 0; i < _jusulOwned._jusulList.Count; ++i)
        {
            for (int j = 0;j < _jusulOwned._jusulList[i].Count; ++j)
            {
                if (_jusulOwned._jusulList[i][j] == 0)
                {
                    _coolTime[j * 6 + i] = 0;
                }
                else
                {
                    if(_coolTime[j * 6 + i] > 0)
                    {
                        _coolTime[j * 6 + i] -= Time.deltaTime;
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

    private int closeRange = 30;
    //스킬들
    public void Earth0()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,1); ++i)
        {
            try
            {
                if (_mobs.GetChild(i) != null)
                {
                    float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) -
                                                       (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                                                           .y));
                    if (verticalDistance < closeRange)
                    {
                        _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                            320 * (_jusulOwned.jusulEarthDamageLevel),
                            Define.JusulType.땅);
                    }
                }
            }
            catch (Exception e){}
        }
    }
    
    public void Earth1()
    {
        for (int i = 0; i < _mobs.childCount; ++i)
        {
            try
            {
                if (_mobs.GetChild(i) != null)
                {
                    float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) -
                                                       (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                                                           .y));
                    if (verticalDistance < closeRange)
                    {
                        _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                            1700 * (_jusulOwned.jusulEarthDamageLevel),
                            Define.JusulType.땅);
                    }
                }
            }
            catch (Exception e){}
        }
    }
    
    
    public void Earth2()
    {
        try
        {
            //체력 보호막
            _player.IncrementHealthShield();
            for (int i = 0; i < Math.Min(_mobs.childCount, 1); ++i)
            {
                _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                    8500 * (_jusulOwned.jusulEarthDamageLevel),
                    Define.JusulType.땅);
            }
        }
        catch (Exception e){}
    }

    public void Earth3()
    {
        
        bool flag = false;
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            try
            {
                float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) -
                                                   (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                                                       .y));
                if (verticalDistance < closeRange && _mobs.GetChild(i) != null)
                {
                    flag = true;
                    _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                        7150 * (_jusulOwned.jusulEarthDamageLevel),
                        Define.JusulType.땅);
                }
            }
            catch (Exception e){}
        }

        if (flag)
        {
            _player.HealByPercentage(1);
        }
    }
    
    public void Earth4()
    {
        int extra = _player.GetHealthShield()/10;
        try
        {
            if (_mobs.childCount <= 5 + extra)
            {
                for (int i = 0; i < _mobs.childCount; ++i)
                {
                    _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                        340000 * (_jusulOwned.jusulEarthDamageLevel),
                        Define.JusulType.땅);
                }
            }
            else
            {
                System.Random random = new System.Random(); //다양한 랜덤 값을 얻기 위해 같은 변수를 사용
                for (int i = 0; i < 5 + extra; ++i)
                {
                    _mobs.GetChild(random.Next(0, _mobs.childCount)).GetComponent<Monster>().Attacked(
                        8500 * (_jusulOwned.jusulEarthDamageLevel),
                        Define.JusulType.땅);
                }
            }
        }
        catch (Exception e){}
    }
    
    public void Earth5()
    {
        for (int i = 0; i < _mobs.childCount; ++i)
        {
            try
            {
                if (i == 0)
                {
                    _mobs.GetChild(0).GetComponent<Monster>().Attacked(
                        320000 * (_jusulOwned.jusulEarthDamageLevel),
                        Define.JusulType.땅);
                    continue;
                }

                _mobs.GetChild(i).GetComponent<Monster>().Attacked(
                    32000 * (_jusulOwned.jusulEarthDamageLevel),
                    Define.JusulType.땅);
            }
            catch (Exception e){}
        }
    }
    
    public void Water0()
    {
        try
        {
            for (int i = 0; i < Math.Min(_mobs.childCount, 1); ++i)
            {
                RectTransform r = _mobs.GetChild(i).GetComponent<RectTransform>();
                if (_mobs.GetChild(i) != null)
                {
                    float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) -
                                                       (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                                                           .y));
                    StartCoroutine(WaterAttack(verticalDistance / closeRange, 143 * (_jusulOwned.jusulWaterDamageLevel),
                        _mobs.GetChild(i)));
                }
            }
        }
        catch (Exception e) { }
    }
    
    public void Water1()
    {
        for (int i = 0; i < Math.Min(_mobs.childCount, 5); ++i)
        {
            try
            {
                if (_mobs.GetChild(i) != null)
                {
                    float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) -
                                                       (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                                                           .y));
                    StartCoroutine(WaterAttack(verticalDistance / closeRange, 520 * (_jusulOwned.jusulWaterDamageLevel),
                        _mobs.GetChild(i)));
                }
            }
            catch (Exception e) { }
        }
    }
    
    public void Water2()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,1); ++i)
        {
            if(_mobs.GetChild(i)!=null)
            {
                _mobs.GetChild(i).GetComponent<Monster>().SlowDown(2);
                float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) - (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y));
                StartCoroutine(WaterAttack(verticalDistance/closeRange, 2500*(_jusulOwned.jusulWaterDamageLevel), _mobs.GetChild(i)));
            }
        }
    }
    
    //TODO:: 수정해야함
    public void Water3()
    {
        for(int i = 0;i<Math.Min(_mobs.childCount,5); ++i)
        {
            try
            {
                if(_mobs.GetChild(i)!=null)
                {
                    _mobs.GetChild(i).GetComponent<Monster>().SlowDown(2);
                    float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) - (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y));
                    StartCoroutine(WaterAttack(verticalDistance/closeRange, 2500*(_jusulOwned.jusulWaterDamageLevel), _mobs.GetChild(i)));
                }
            }
            catch (Exception e) { }
        }
    }
    
    public void Water4()
    {
        try
        {
            for (int i = 0; i < Math.Min(_mobs.childCount, 1); ++i)
            {
                if (_mobs.GetChild(i) != null)
                {
                    float verticalDistance = Mathf.Abs((_player.GetComponent<RectTransform>().anchoredPosition.y) -
                                                       (_mobs.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                                                           .y));
                    StartCoroutine(WaterAttack(verticalDistance / closeRange,
                        2500 * (_jusulOwned.jusulWaterDamageLevel), _mobs.GetChild(i)));
                }
            }
        }
        catch (Exception e) { }
    }
    
    public void Water5()
    {
        int attack = 96000*(_jusulOwned.jusulWaterDamageLevel);
        for(int i = 0;i<_mobs.childCount; ++i)
        {
            try
            {
                if (_mobs.GetChild(i) == null)
                {
                    continue;
                }

                _mobs.GetChild(i).GetComponent<Monster>().Attacked(attack, Define.JusulType.물);
                attack = (int)(attack * 0.95f);
            }
            catch (Exception e) { }
        }
    }

    IEnumerator WaterAttack(float time, int damage, Transform t)
    {
        Debug.Log(time);
        yield return new WaitForSeconds(time/5);
        if (t != null)
        {
            t.GetComponent<Monster>().Attacked(damage, Define.JusulType.물);
        }
    }
    
    #endregion
}
