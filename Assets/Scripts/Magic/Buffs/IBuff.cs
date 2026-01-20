using Unity.VisualScripting;
using UnityEngine;

public interface IBuff
{
    public string Id { get; }

    public void Initialize(BuffContainer buffContainer);

    public void Deinitialized();

    public void Update(float deltaTime);
}
