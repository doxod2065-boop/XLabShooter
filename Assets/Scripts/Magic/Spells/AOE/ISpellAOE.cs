using UnityEngine;
using System.Collections.Generic;

public interface ISpellAoe
{
    public void Initialize(Vector3 worldposition, float radius, IReadOnlyCollection<IEffect> effects);
    
}
