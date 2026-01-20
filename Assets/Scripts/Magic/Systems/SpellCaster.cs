using System;
using UnityEngine;
using Object = UnityEngine.Object;



public sealed class SpellCaster
{
    private readonly Transform m_casterTransform;

    public SpellCaster(Transform casterTransform)
    {
        m_casterTransform = casterTransform;
    }
    public void Cast(BaseSpellData spell, Vector3 worldPosition)
    {
        if(!spell)
            {
                return;
            }
        switch(spell)
        {
            case SelfSpellData selfSpell:CastSelf(selfSpell); break;
            case TargetSpellData targetSpell: CastTarget(targetSpell, worldPosition); break;
            case NonTargetSpellData nonTargetSpell: CastNonTarget(nonTargetSpell); break;
            case AoeSpellData aoeSpell:
                {
                    CastAOE(aoeSpell, aoeSpell.isTarget
                        ? worldPosition
                        : m_casterTransform.position);
                    break;
                }
        }
    }

    private void CastSelf(SelfSpellData selfSpell)
    {
        if(selfSpell.visualEffect)
        {
            Object.Instantiate(selfSpell.visualEffect, m_casterTransform.position, Quaternion.identity);
        }

        if(m_casterTransform.TryGetComponent<IEffectable>(out var effectable))
        {
            foreach(var effect in selfSpell.effects)
            {
                effect.Apply(effectable);
            }
    
        }
    }
    private void CastTarget(TargetSpellData targetSpell, Vector3 worldPosition)
    {
        if(!targetSpell.visualEffect)
        {
            throw new NullReferenceException("Target spell must have visualEffect");
        }

        var projectile = Object.Instantiate(targetSpell.visualEffect, m_casterTransform.position, Quaternion.identity);
        
        var SpellProjectile =
        projectile.GetComponent<ISpellProjectile>() ??
        projectile.AddComponent<SpellProjectile>();

        SpellProjectile.Initialize(worldPosition, targetSpell.speed, targetSpell.effects);
    }
    private void CastNonTarget(NonTargetSpellData spell) { }
    private void CastAOE(AoeSpellData aoeSpell, Vector3 worldPosition)
    {
        var aoe = aoeSpell.visualEffect
        ? Object.Instantiate(aoeSpell.visualEffect, m_casterTransform.position, Quaternion.identity)
        : new GameObject();

        aoe.transform.position = worldPosition;

        var SpellAoe =
            aoe.GetComponent<ISpellAoe>() ??
            aoe.AddComponent<SpellAoe>();

            SpellAoe.Initialize(worldPosition, aoeSpell.radius, aoeSpell.effects);
    }

}
