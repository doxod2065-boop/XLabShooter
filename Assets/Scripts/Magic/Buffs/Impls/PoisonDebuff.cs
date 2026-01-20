using System;
using UnityEngine;

[Serializable]

public class PoisonDebuff : TimedBuff
{
    [SerializeField][Min(0)] private float m_damagePerSecods = 2f;
    [SerializeField][Min(0)] private float m_internal = 1;

    [NonSerialized] private float m_timer;
    private IHealth m_health;

    public PoisonDebuff

    protected override void OnInitialized()
    {
        m_health = container.GetComponent<IHealth>();
        base.OnInitialized();
    }

    protected override void OnUpdated(float deltaTime)
    {
        if (m_health is null)
        {
            Deinitialize();
            return;
        }

        if (m_timer < m_internal)
        {
            m_timer += deltaTime;
        }
        else
        {
            m_timer = 0;
            m_health.TakeDamage(m_damagePerSeconds);
        }
    }
}
