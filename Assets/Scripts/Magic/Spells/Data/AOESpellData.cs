using UnityEngine;

[CreateAssetMenu(fileName = "AOESpellData", menuName = "XLabGame/Magic/Spells/AOESpellData")]
public class AOESpellData : BaseSpellData
{
    [SerializeField] private bool  m_isTarget;
    [SerializeField][Min(0f)] private float m_radius;

    public float radius => m_radius;

    public bool isTarget => m_isTarget;
}
