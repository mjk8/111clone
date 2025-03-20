using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinsu : MonoBehaviour
{
    public Player Player;
    List<Tuple<int,int>> _requirements = new List<Tuple<int, int>>();
    
    private void Start()
    {
        _requirements.Add(new Tuple<int, int>(0, 1));
        _requirements.Add(new Tuple<int, int>(1, 0));
        _requirements.Add(new Tuple<int, int>(2, 0));
    }
}
