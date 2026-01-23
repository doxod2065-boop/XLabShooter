using Unity.VisualScripting;
using UnityEngine;

public interface IBuff
{
    public string Id { get; }

    public Sprite Icon { get; }

    public BuffType Type { get; }

    public void Initialize(BuffContainer buffContainer);

    public void Deinitialized();

    public void Update(float deltaTime);

    public IBuff Clone();

    public interface ITimeBuff : IBuff
    {
        public float timer { get;  }

        public float duration { get;  }
    }
}
