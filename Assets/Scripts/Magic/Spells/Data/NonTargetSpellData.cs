using UnityEngine;

[CreateAssetMenu(fileName = "NonTargetSpellData", menuName = "Xlab/Magic/Spells/NonTarget Spell")]
public class NonTargetSpellData : BaseSpellData
{

    [SerializeField][Min(0)] private float m_range;
    [SerializeField][Min(0)] private float m_duration;
    [SerializeField][Min(0f)] private float m_effectInterval;
        
    public float range => m_range;
    
    public float duration => m_duration;

    public float effectInterval => m_effectInterval;
}
