using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMgr : MonoBehaviour
{
    private static EffectMgr instance;
    public static EffectMgr Instance
    {
        get { return instance; }
    }

    [SerializeField] Effect[] effects;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayEffect(string _key, Vector2 _pos)
    {
        
        for(int i = 0; i < effects.Length; i++)
        {            
            if (_key == effects[i].key)
            {
                Effect effect = Instantiate(effects[i]);
                effect.PlayEffect(_pos);
            }
        }
    }

}
