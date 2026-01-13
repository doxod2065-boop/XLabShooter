using UnityEngine;
using System.Collections.Generic;

namespace Magic.Spells.AOE
{
    public class SpellAOE : MonoBehaviour
    {
        public void Initialized(Vector3 targetPosition, float radius, IReadOnlyCollection<IEffect> effects)
        {
            var colliders = Physics.OverlapSphere(targetPosition, radius);

            foreach (var collider in colliders)
            {
                var effectables = collider.GetComponents<>(IEffectable);
                effects.ApplyEffects((effectable));
            }
        }
    }
}
