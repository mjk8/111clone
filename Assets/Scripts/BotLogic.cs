using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotLogic : MonoBehaviour
{
    public JusulOwned _jusulOwned;
    
    private void Start()
    {
        _jusulOwned = GetComponent<JusulOwned>();
    }
}
