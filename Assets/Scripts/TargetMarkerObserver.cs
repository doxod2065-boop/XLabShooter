using UnityEngine;

public sealed class TargetMarkerObserver : MonoBehaviour
{
    [SerializeField] private TargetMarker m_targetMarker;
    [SerializeField] private PlayerMovement m_playerMovement;

    private void OnEnable()
    {
        // Подписываемся на остановку и изменение цели.
        m_playerMovement.Stopped += OnPlayerStopped;
        m_playerMovement.DestinationChanged += OnDestinationChanged;
    }

    private void OnDisable()
    {
        // Отписываемся.
        m_playerMovement.Stopped -= OnPlayerStopped;
        m_playerMovement.DestinationChanged -= OnDestinationChanged;
    }

    // Причим? маркер при остановки игрока.
    private void OnPlayerStopped() =>
        m_targetMarker.Hide();

    private void OnDestinationChanged(Vector3 worldPosition) =>
        m_targetMarker.Show(worldPosition);
}
