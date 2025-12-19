using System;
using UnityEngine;
using static IEffect;

[Serializable]
public class AttackEffect : IEffect
{
    [SerializeField][Min(0)] private float m_damage;

    public void Apply(IEffectable effectable)
    {
        if (effectable is IHealth health)
        {
            health.TakeDamage(m_damage);
        }
    }
}
