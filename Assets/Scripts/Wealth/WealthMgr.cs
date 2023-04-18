using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WealthMgr : MonoBehaviour
{

    private static WealthMgr instance;
    public static WealthMgr Instance {  get { return instance; } }

    [SerializeField] Wealth[] wealths;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;            
        }
    }

    public void SpawnWealth(WealthType _wT, Vector2 _pos, int _value)
    {
        Wealth _w = GetWealth(_wT);
        _w.Spawn(_pos, _value);
    }

    public Wealth GetWealth(WealthType _wT)
    {        
        for(int i = 0; i < wealths.Length; i++)
        {
            if (wealths[i].wealthType.Equals(_wT))
            {
                return Instantiate(wealths[i]);
            }
        }

        return null;
    }

}
