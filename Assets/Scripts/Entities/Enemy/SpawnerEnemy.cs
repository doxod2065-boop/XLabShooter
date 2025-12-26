using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private EnemyData[] m_data;
    [SerializeField] private Enemy[] m_enemies;
    [SerializeField] private Transform[] m_smawnPoints;
    [SerializeField] private Transform m_playerTransform;

    // TODO XLab - Remove

    private void Start()
    {
        Spawn();    
    }

    public void Spawn()
    {
        foreach (var spawnPoint in m_smawnPoints)
        {
            var enemy = GetEnemy();
            var enemyData = GetEnemyData();

            var enemyInstance = Instantiate(enemy, spawnPoint);
            enemyInstance.Initialize(enemyData, m_playerTransform);

            enemyInstance.Died += OnDied;
        }
    }

    private void OnDied()
    {
        enemy.Died -= OnDied;
        Destroy(Enemy.gameObject);
    }

    private Enemy GetEnemy() =>
        m_enemies[Random.Range(0, m_enemies.Length)];

    private EnemyData GetEnemyData() =>
        m_data[Random.Range(0, m_data.Length)];
}
