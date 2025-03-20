using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JusulSkill : MonoBehaviour
{
    protected int Damage;
    protected int max;
    protected Define.JusulRank jusulRank;
    protected Define.JusulType jusulType;
    protected Player _player;
    protected int _upgraded;
    
    abstract public void UseSkill();
}
