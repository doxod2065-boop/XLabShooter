using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace Inputs
{
    public sealed class MouseResolver : MonoBehaviour
    {
        [SerializeField] private LayerMask m_layerMask = ~0;
        [SerializeField][Min(0)] private float m_raycastDistance = 1000f;
        [SerializeField][Min(0)] private float m_navMeshSampleMaxDistance = 100f;

        private Mouse m_mouse;
        private Camera m_camera;

        public Vector3 mousePosition => m_mouse.position.ReadValue();

        private void Awake()
        {
            m_camera = Camera.main;
            m_mouse = Mouse.current;
        }

        public Vector3? GetNavMeshPoint()
        {
            var ray = m_camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out var hit, m_raycastDistance, m_layerMask))
            {
                if (NavMesh.SamplePosition(hit.point, out var navHit, m_navMeshSampleMaxDistance, areaMask: NavMesh.AllAreas))
                {
                    return navHit.position;
                }
            }

            return null;
        }
    }
}
