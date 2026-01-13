using Entities;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    [SerializeField] private AttackEnemySystem m_attack;
    [SerializeField] private HealthComponent m_health;
    [SerializeField] private EnemyMovement m_movement;

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
        if(m_stateMachine.currentState is Enemy.State = Dead || !m_data)
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

        if (data.enemyType == AttackEnemyType.Melee)
        {
            m_stateMachine.ChangeStage(EnemyStage.Move);
        }
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

    private void HandleMoveState (bool isInAttackRange)
    {

    }

    private void HandleAttackState (bool isInAttackRange)
    {
        m_attack.TryAttack();
    }

    private void HandleIdleState(bool isInAttackRange)
    {

    }

    private void OnStateChanged(EnemyStateMachine previousState, EnemyState nextState)
    {
        if (previousState is EnemyState.Move)
        {
            m_movement.StopMoving();
        }

        if (nextState is EnemyState.Move)
        {
            m_movement.StartMoving();
        }
    }
}
