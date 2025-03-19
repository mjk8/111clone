using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _instance; 
    static Managers Instance {get { Init(); return _instance; } } 
    
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    SoundManager _sound = new SoundManager();
    PoolManager _pool = new PoolManager();
    PlayerManager _player = new PlayerManager();
    GameManager _game;
    JusulManager _jusul = new JusulManager();
    
    
    public static  ResourceManager Resource { get { return Instance._resource;} }
    public static UIManager UI { get { return Instance._ui; } }
   
    public static SoundManager Sound { get { return Instance._sound; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static GameManager Game { get { return Instance._game; } }
    public static PlayerManager Player { get { return Instance._player; } }
    public static JusulManager Jusul { get { return Instance._jusul; } }
    

    void Start()
    {
        _game = GameObject.FindObjectOfType<GameManager>();
        Init();
    }

    private void FixedUpdate()
    {
       //_game.FixedUpdate(); //게임 로직 업데이트(게임로직 주기마다 실행되어야하는)
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Managers>();
            _instance._sound.Init();
            _instance._pool.Init();
            _instance._player.Init();
            _instance._ui.Init();
            //_instance._jusul.Init();
            
        }
    }
    
    
    public static void Clear()
    {
    }
}
