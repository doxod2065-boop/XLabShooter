using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellPreparation
{
    public event Action OverflowOccurred;
    public event Action<IReadOnlyList<ElementType>> ElementsChanged;


    private MagicConfig m_magicConfig;
    private List<ElementType> m_elements = new();

    public SpellPreparation(MagicConfig magicConfig)
    {
        m_magicConfig = magicConfig;
    }

    public void AddElement(ElementType elementType)
    {
        if (m_elements.Count >= m_magicConfig.MaxElements)
        {

            Clear();
            OverflowOccurred?.Invoke();

        }
        else
        {
            m_elements.Add(elementType);
            ElementsChanged?.Invoke(m_elements);

        }

    }

    public bool TrygetSpell(out BaseSpellData spell)
    {
        spell = null;

        if (m_elements.Count is 0)
        {
            return false;
        }

        foreach (var spellData in m_magicConfig.SpellDataBase.Spells)
        {

            if (IsMatchingCombination(spellData.combination))
            {
                spell = spellData;
                return true;
            }
        }
        return false;
    }

    private bool IsMatchingCombination(IReadOnlyList<ElementType> combinatoins)
    {
        if (combinatoins.Count != m_elements.Count)
        {
            return false;
        }

        for (var i = 0; i < combinatoins.Count; i++)
        {
            if (combinatoins[i] != m_elements[i])
            {
                return false;
            }
        }
        return true;
    }
    public void Clear()
    {
        m_elements.Clear();
        ElementsChanged?.Invoke(m_elements);
    }

}