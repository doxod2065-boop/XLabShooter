using UnityEngine;

public class GameplayExitState : IState
{
    private readonly Loading m_loading;

    public void Enter()
    {
        var loading = ServiceLocator.Resolve<Loading>();
        var spawner = ServiceLocator.Resolve<SpawnerEnemy>();
        spawner.DespawnAll();

        m_loading.LoadScene(GlobalConstants.Scenes.Main);
    }

    public void Exit() 
    { 
            
    }
}
