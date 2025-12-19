using UnityEngine;
using System.Collections.Generic;

namespace Magic.Spells.AOE
{
    public interface ISpellAOE
    {
        public void Initialize(Vector3 worldPosition, float radius, IReadOnlyCollection<IEffect> effects);
    }
}
