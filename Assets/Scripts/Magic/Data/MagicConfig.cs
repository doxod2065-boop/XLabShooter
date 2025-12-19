using UnityEngine;

[CreateAssetMenu(fileName = "MagicConfig", menuName = "XLabGame/Magic/Data/MagicConfig")]
public class MagicConfig : ScriptableObject
{
    [SerializeField] private ElementsData m_elementsData;
    [SerializeField] private SpellDatabase m_spellsDataBase;

    [SerializeField][Min(1)] private int m_maxelements = 3;
    [SerializeField][Min(0)] private float m_cancelCooldown;

    public ElementsData ElementData => m_elementsData;

    public SpellDatabase SpellDataBase => m_spellsDataBase;

    public int MaxElements => m_maxelements;

    public float CancelCooldown => m_cancelCooldown;

}
