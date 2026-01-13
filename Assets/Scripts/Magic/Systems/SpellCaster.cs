using Magic.Spells.AOE;
using Magic.Spells.Projectiles;
using UnityEngine;
using UnityEngine.Pool;

namespace Magic.Systems
{
    public sealed class SpellCaster
    {
        private readonly Transform m_casterTransform;
        private readonly bool m_isSingleSpell;
        private readonly ObjectPool<GameObject> m_visualEffectsPool;

        public SpellCaster(Transform casterTransform, bool isSingleSpell = false)
        {
            m_casterTransform = casterTransform;
            m_isSingleSpell = isSingleSpell;
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
                var visualEffect = Object.Instantiate(selfSpell.visualEffect);
                SetLayer(visualEffect);
            }

            var effectables = m_casterTransform.GetComponent<IEffectable>;
            selfSpell.effects.ApplyEffects(effectables);

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
            if(!m_isSingleSpell)
            {
                m_visualEffectsPool ??= new ObjectPool<GameObject>(
                   createFunc: Create, 
                   actionOnGet: gm => gm.SetActive(true)
                   actionOnRealize: gm => gm.SetActive(false)
                   )
            }

            var aoe = AOESpell.visualEffect
                ? Object.Instantiate(AOESpell.visualEffect, m_casterTransform.position, Quaternion.identity)
                : new GameObject();

            SetLayer(AOE)
            aoe.transform.position = worldPosition;

            var spellAOE =
                aoe.GetComponent<ISpellAOE>() ??
                aoe.AddComponent<SpellAOE>();

            spellAOE.Initialize(worldPosition, AOESpell.radius, AOEspell.effects);

            GameObject Create()
            {
                return aoeSpell.visualEffects
                    ? Object
            }
        }

        private void SetLayer(GameObject visualEffect) =>
            visualEffect.layer = m_casterTransform.gameObject.layer;
    }
}
