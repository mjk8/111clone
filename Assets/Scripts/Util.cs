using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 여러 곳에서 필요하는 함수들을 모아놓은 클래스입니다.
/// </summary>
public class Util
{
    //Fetches a component. Adds the requested component if it doesnt exist.
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    
    
    private static System.Random random = new System.Random(); //다양한 랜덤 값을 얻기 위해 같은 변수를 사용
    public static int GetRandomNumberOutOf100()
    {
        return random.Next(0, 100);
    }
    
    public static int GetNumberOfItemsInEnum<T>()
    {
        return Enum.GetNames(typeof(T)).Length;
    }
}