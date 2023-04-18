using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wealth : MonoBehaviour
{
    public WealthType wealthType;
    [SerializeField] protected int value;

    public virtual void Spawn(Vector2 _pos, int _v) //재화 생산 시 호출
    {
        transform.position = _pos;
        value = _v;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            AddWealth();
    }
    public virtual void AddWealth()
    {
        SoundMgr.Instance.PlaySound(SFXType.gold_get);
        Player.Instance.AddWealth(wealthType, value);
        Destroy(gameObject);
    }
}


//열거형 
public enum WealthType
{
    gold,
    crystal
}


