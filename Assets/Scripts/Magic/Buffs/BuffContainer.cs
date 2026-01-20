using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public sealed class BuffContainer : MonoBehaviour, IEffectable
{
    private HashSet<string> m_ids = new();
    private Dictionary<string, IBuff> m_buffs = new();

    public void Add(IBuff buff)
    {
        if (m_buffs.TryGetValue(buff.Id, out IBuff existingBuff))
        {
            existingBuff.Refresh(this);
        }
        else
        {
            m_buffs.Add(buff.Id, buff);
            buff.Initialize(this);
        }
    }

    public void Remove(IBuff buff)
    {
    m_ids.Remove(buff.Id);
    }

    public void Update()
    {
        foreach (var buff in m_buffs.Values)
        {
            buff.Update(Time.deltaTime);
        }

        foreach (var id in m_ids)
                {
                m_buffs.Remove(id);
                }

        m_ids.Clear();
    }
}
