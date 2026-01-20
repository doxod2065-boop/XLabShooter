using System;
using UnityEngine;

[Serializable]
public class BuffEffect : IEffect
{
    [SerializeReferenceDropdown]
    [SerializeReference] private IBuff m_buff;

    public void Apply(Iffectable effectable)
    {
        if (effectable is BuffContainer container)
        {
            foreach (var buff in m_buffs)
            {
                container.Add(buff.Clone());
            }
        }
    }
}
