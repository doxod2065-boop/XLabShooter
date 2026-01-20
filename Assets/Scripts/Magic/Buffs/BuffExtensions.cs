using UnityEngine;

public static class BuffExtensions
{
    
    public static void Refresh(this IBuff buff, BuffContainer buffContainer)
    {
        buff.Deinitialized();
        buff.Initialize(buffContainer);
    }
}
