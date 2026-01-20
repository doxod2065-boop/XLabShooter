using UnityEngine;

[SerializeField]
public sealed class HealEffect : IEffect
{
    [SerializeField][Min(0)] private float m_heal;
    public void Apply(IEffectable effectable)
    {
        if(effectable is IHealth health)
        {
            health.Hael(m_heal);
        }
    }
}
