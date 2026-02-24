using Players;
using Unity.VisualScripting;
using UnityEngine;

public interface IPlayerFactorySettings
{
    public Vector3 position {  get; set; }
}

public interface IPlayerFactory
{
    public PlayerController Create();

    public void Release();
}

public class PlayerFactory : IPlayerFactorySettings, IPlayerFactory
{
    private readonly string m_path;
    private PlayerController m_playerPrefab;
    private PlayerController m_playerInstance;

    Vector3 IPlayerFactorySettings.position { get; set; }

    public PlayerFactory(string mPath)
    {
        m_path = mPath;
    }

    public PlayerController Create()
    {
        if (m_playerInstance is null)
        {
            return m_playerInstance;
        }

        if (m_playerPrefab is null)
        {
            var playerPrefab = Resources.Load<GameObject>(m_path);
            m_playerPrefab = playerPrefab.GetComponent<PlayerController>();
        }

        m_playerInstance = Object.Instantiate(m_playerPrefab, ((IPlayerFactorySettings)this).position, Quaternion.identity);
        m_playerInstance.Initialize(Camera.main, ServiceLocator.Res)

        return m_playerInstance;
    }

    public void Release(PlayerController m_playerController)
    {
        Object.Destroy(m_playerController.gameObject);
    }
}
