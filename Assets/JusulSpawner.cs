using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JusulSpawner : MonoBehaviour
{
    JusulOwned _jusulOwned;
    void Start()
    {
        _jusulOwned = transform.parent.GetComponentInChildren<JusulOwned>();
    }
}
