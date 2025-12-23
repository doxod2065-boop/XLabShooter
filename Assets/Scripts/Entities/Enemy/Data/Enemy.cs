using Entities;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    [SerializeField] private EnemyData m_enemyData;
    [SerializeField] private HealthComponent m_health;

    private EnemyData m_data;

    public IHealth health => m_health;

    //TODO Add HealthComponent
    //TODO Add Movement
    //TODO Add AttackComponent

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        m_health.ValueChanged += () =>
        {
            Debug.Log($"Health Changed: {m_health.Value}");
        };

        m_health.Died += OnDied;
    }

    private void OnDisable()
    {
        m_health.Died -= OnDied;
    }

    public void Initialize(EnemyData data)
    {
        m_data = data;
        m_health.Initialize(data.health);
    }

    private void OnDied =>
        Died?.Invoke(this);

}
