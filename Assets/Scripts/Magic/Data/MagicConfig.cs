using UnityEngine;

[CreateAssetMenu(fileName = "MagicConfig", menuName = "Xlab/Data/MagicConfig")]
public sealed class MagicConfig : ScriptableObject
{

    [SerializeField] private ElementData m_elementsData;
    [SerializeField] private SpellDatabase m_spellsDateBase;

    [SerializeField][Min(1)] private int m_maxElements = 3;
    [SerializeField][Min(0)] private float m_cancelCooldown = 0.3f;

    public ElementData ElementData => m_elementsData;
    public SpellDatabase SpellDatabase => m_spellsDateBase;
    public int maxElements => m_maxElements;

    public float cancelColdown => m_cancelCooldown;
    
}
