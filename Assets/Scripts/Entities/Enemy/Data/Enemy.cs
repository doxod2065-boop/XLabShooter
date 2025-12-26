using Entities;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    [SerializeField] private AttackEnemySystem m_attack;
    [SerializeField] private HealthComponent m_health;

    private EnemyData m_data;

    //TODO Add HealthComponent
    //TODO Add Movement
    //TODO Add AttackComponent

    private void Awake()
    {
        m_stateMachine ??= new EnemyStateMachine();
    }

    private void OnEnable()
    {
        m_health.Died += OnDied;
    }

    private void OnDisable()
    {
        m_health.Died -= OnDied;
    }

    private void Update()
    {
        if(m_stateMachine.currentState.Dead || !m_data)
        {
            return;
        }

        UpdateState();
    }

    public void Initialize(EnemyData data, Transform playerTransform)
    {
        m_data = data;
        m_health.Initialize(data.health);
        m_attack.Initialized(data.spell, data.attackTime, playerTransform);

        m_playerTransform = playerTransform;
        m_stateMachine ??= new EnemyStateMachine();
    }

    private void UpdateState()
    {
        var isInitialized = IsInRange();

        switch (m_stateMachine.currentState)
        {
            case EnemyState.Idle: HandleIdleState(isInAttackRange); break;
            case EnemyState.Attack: HandleAttackState(isInAttackRange); break;
        }
    }

    private bool IsInRange()
    {
        if (m_data.enemyType == AttackEnemyType.Range && IsInAttackRange)
        {
            return false;
        }
    }

    private void OnDied() =>
        Died?.Invoke(this);

    private void OnStateChanged(EnemyState priviousDtate, EnemyState nextStage)
    {

    }

}
