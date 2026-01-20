
using UnityEngine;

[CreateAssetMenu(fileName = "SelfSpellData", menuName = "Xlab/Magic/Spells/Self Spell")]
public class SelfSpellData : BaseSpellData
{
    [SerializeField] private bool m_isTarget;


    public bool isTarget => m_isTarget;
}
