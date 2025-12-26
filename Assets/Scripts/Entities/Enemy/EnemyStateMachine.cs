using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentState {  get; private set; }
    
    public EnemyStateMachine()
    {
        currentState = EnemyState.Idle;
    }

    public void ChangeState(EnemyState nextState)
    {
        if (currentState is EnemyState.Dead || currentState == NesterState)
        {
            return;
        }

        var previousState = currentState;

    }
}
