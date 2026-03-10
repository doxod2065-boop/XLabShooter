using Markers;
using Players;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayEnteryState : IState
{
    private PlayerController playerController;
    private readonly SpawnerEnemy m_spawnerEnemy;
    private readonly StateMachine m_stateMachine;
    private readonly AimLineMarker m_aimLineMarker;
    private readonly TargetMarkerObserver m_targetMarkerObserver;

    public GameplayEntryState(
        StateMachine stateMachine,
        SpawnerEnemy spawnerEnemy,
        AimLineMarker aimLineMarker,
        TargetMarkerObserver targetMarkerObserver)

    {
        m_spawnerEnemy = spawnerEnemy;
        m_stateMachine = stateMachine;
        m_aimLineMarker = aimLineMarker;
        m_targetMarkerObserver = targetMarkerObserver;
    }

        public void Enter
        {

        }
}
