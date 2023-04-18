using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : Effect
{
    [SerializeField] ParticleSystem particleSystem;
    public override void Init()
    {
        base.Init();
        particleSystem = GetComponent<ParticleSystem>();
    }

    public override void PlayEffect(Vector2 _pos)
    {
        base.PlayEffect(_pos);
        particleSystem.Play();
    }
}
