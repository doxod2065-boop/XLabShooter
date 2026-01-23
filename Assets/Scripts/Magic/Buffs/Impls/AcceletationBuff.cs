using System;
using UnityEngine;

[Serializable]

public class AcceletationBuff : TimedBuff
{
    [SerializeField] private float m_value;

    private 

    public AcceletationBuff(
        string id,
        Sprite icon,
        BuffType type,
        float duration,
        float value)
        : base(id, icon, type, duration)
    {
        m_value = value;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        m_acceleration = container.GetComponent<IAcceleration>();

        if (m_acceleration is null)

        {
            Deinitialize();
        }
        else
        {
            m_acceleration.IncreaseAcceleration(m_value);
        }
    }

    protected override void OnDeinitializing()
    {
        m_acceleration = 
    }
}
