using Magic.Spells.AOE;
using Magic.Spells.Projectiles;
using UnityEngine;

namespace Magic.Systems
{
    public class SpellCaster
    {
        private readonly Transform m_casterTransform;

        public SpellCaster(Transform casterTransform)
        {
            m_casterTransform = casterTransform;
        }
        public void Cast(BaseSpellData spell, Vector3 worldPosition)
        {
            if (!spell)
            {
                return;
            }
            switch (spell)
            {
                case SelfSpellData selfSpell: CastSelf(selfSpell); break;
                case TargetSpellData targetSpell: CastTarget(targetSpell, worldPosition); break;
                case NonTargetSpellData nonTargetSpell: CastNonTarget(nonTargetSpell); break;
                case AOESpellData aoeSpell:
                    {
                        if (aoeSpell.isTarget)
                        {
                            CastAOE(aoeSpell, aoeSpell.worldPosition);
                        }
                        else
                        {    
                            CastAOE(aoeSpell, m_casterTransform.position);
                        }

                        break;
                    }
            }
        }

        private void CastSelf(SelfSpellData spell) 
        { 
        if (SelfSpell.visualEffect)
            {
                Object.Instantiate(SelfSpell.visualEffect, m_casterTransform.position, Quaternion.identity);
            }

            if (m_casterTransform.TryGetComponent<IEffectable>(out var effectable))
            {
                foreach (var effect in selfSpell.effects)
                {
                    effect.Apply(effectable);
                }
            }
        }
        private void CastTarget(TargetSpellData spell, Vector3 worldPosition) 
        {
            if (!TargetSpell.visualEffect)
            {
                throw new NullReferenceExeption("Target spell must have visualEffect");
            }

            var projectile = Object.Instantiate(TargetSpell.visualEffect, m_casterTransform.position, Quaternion.identity);

            var spellProjectile =
                projectile.GetComponent<ISpellProjectile>() ??
                projectile.AddComponent<SpellProjectile>();

            spellProjectile.Initialize(worldPosition, targetSpell.speed, TargetSpell.effects);
        }
        private void CastNonTarget(NonTargetSpellData spell) { }
        private void CastAOE(AOESpellData spell, Vector3 worldPosition)
        {
            var aoe = AOESpell.visualEffect
                ? Object.Instantiate(AOESpell.visualEffect, m_casterTransform.position, Quaternion.identity)
                : new GameObject();

            aoe.transform.position = worldPosition;

            var spellAOE =
                aoe.GetComponent<ISpellAOE>() ??
                aoe.AddComponent<SpellAOE>();

            spellAOE.Initialize(worldPosition, AOESpell.radius, AOEspell.effects);
        }

    }
}
