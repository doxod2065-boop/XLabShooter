using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_agent;

    private Transform m_target;
    private bool m_isMoving;
    private bool m_isInitialized;

    private void OnValidate()
    {
        if (!m_agent)
        {
            m_agent = GetComponent<NavMeshAgent>();
        }
    }

    public void Initialized(float speed, Transform target)
    {
        m_target = target;
        m_agent.speed = speed;
        m_isInitialized = true;
    }

    private void Update()
    {
        if (!m_isInitialized || !m_isMoving || !m_target)
        {
            return;
        }

        m_agent.SetDestination(m_target.position);
    }

    public void StartMoving()
    {
        if (!m_isInitialized)
        {
            return;
        }

        m_isMoving = true;
        m_agent.isStopped = false;
    }


}
