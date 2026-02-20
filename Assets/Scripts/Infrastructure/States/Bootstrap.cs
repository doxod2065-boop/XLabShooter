using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private DeadMenuViev m_deadMenuViev;
    [SerializeField] private SpawnerEnemy m_enemySpawner;
    [SerializeField] private MainMenuViev m_mainMenuViev;

    private void Awake()
    {
        var StateMachine = new StateMachine();

        StateMachine.Initialized(
            new MainMenuState(stateMachine, m_mainMenuState),
            new PauseMenuState(stateMachine),
            new DeadState(stateMachine),
            new GameplayState(stateMachine));
    }
}
