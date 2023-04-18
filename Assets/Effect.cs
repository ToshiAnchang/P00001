using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public string key;

    public virtual void Init()
    {

    }

    public virtual void PlayEffect(Vector2 _pos)
    {
        transform.position = _pos;
    }
}