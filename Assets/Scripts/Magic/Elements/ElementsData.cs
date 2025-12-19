using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementsData", menuName = "XLabGame/Magic/ElementsData", order = 0)]

public sealed class ElementsData : ScriptableObject
{
    [SerializeField] private Item[] m_items;

    public IReadOnlyList<Item> Items => m_items;

    [Serializable]

    public sealed class Item
    {
        [SerializeField] private ElementType m_type;
        [SerializeField] private string m_elementName;
        [SerializeField] private Sprite m_icon;

        public Sprite icon => m_icon;

        public ElementType type => m_type;

        public string elementName => m_elementName;
    }
}
