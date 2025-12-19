using System;
using UnityEngine;
using static IEffect;

[Serializable]
public sealed class HealEffect
{
    [SerializeField][Min(0)] private float m_heal;
    public void Apply(IEffectable effectable)
    {
        if (effectable is IHealth health)
        {
            health.Heal(m_heal);
        }
    }
}
