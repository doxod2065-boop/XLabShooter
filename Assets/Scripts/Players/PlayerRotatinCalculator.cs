using UnityEngine;

public sealed class PlayerRotatinCalculator
{
    private readonly Camera m_camera;
    private readonly Transform m_playerTransaorm;

    public PlayerRotatinCalculator(Camera camera, Transform playerTransaorm)
    {
        m_camera = camera;
        m_playerTransaorm = playerTransaorm;
    }

    public Vector3 Calculate(Vector3 mousePosition)
    {
        var playersScreenposition = m_camera.WorldToScreenPoint(m_playerTransaorm.position);
        var delta = (Vector2)mousePosition - (Vector2)playersScreenposition;

        var cameraRight = m_camera.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        var cameraForward = m_camera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        var worldDirection = cameraRight * delta.x + cameraForward * delta.y;
        worldDirection.y = 0f;

        if (worldDirection.sqrMagnitude > 0.0001f)
        {
            return m_playerTransaorm.position + worldDirection;
        }

        return Vector3.zero;
    }
}
