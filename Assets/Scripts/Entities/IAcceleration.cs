using UnityEngine;

namespace Entities
{
    public interface IAcceleration
    {
        public void IncreaseAccseleration(float delta);

        public void DecreaseAccseleration(float delta);
    }
}
