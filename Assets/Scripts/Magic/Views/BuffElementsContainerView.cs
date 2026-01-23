using UnityEngine;

public class BuffElementsContainerView : MonoBehaviour
{
    [SerializeField] private BuffElementView m_buffViev;
    [SerializeField] private BuffElementView m_debuffView;
    [SerializeField] private 
    private void OnEnable()
    {
        foreach (var buff in m_buffContainer.Buffs)
        {
            AddElement(buff);
        }

        m_buffContainer.BuffAdded += AddElements;
        m_buffContainer.BuffRemoved += RemoveElements;
    }

    private void OnDisable()
    {
        foreach (var buff in m_buffContainer.Buffs)
        {
            RemoveElements(buff);
        }

        m_buffContainer.BuffAdded -= AddElement;
        m_buffContainer.BuffRemoves -= RemoveElements;
    }

    private void AddElement(IBuff buff)
    {

    }
}
