using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]

public abstract class BaseBuff : IBuff
{
    [field: SerializeField]

    public string Id { get; private set; }

    protected BuffContainer container { get; private set; }

    public BaseBuff() { }

    protected BaseBuff(string id)
    {

    }

    public void Initialized()
    {
        this.container = container;
        OnInitialized();
    }

    protected virtual void OnInitialized()
    {

    }

    public void Deinitialize()
    {
        OnDeinitializing();

        container.Remove(this);
        container = null;
    }

    protected virtual void OnDeinitializing()
    {

    }

    public virtual void Update(float deltaTime)
    {
    
    }

    public object Clone() =>
}
