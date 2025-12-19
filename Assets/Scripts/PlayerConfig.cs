using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
public sealed class PlayerConfig : ScriptableObject
{
    [SerializeField] private Texture2D m_cursoreTexture;

    [Header("Speed")]
    [SerializeField][Range(0f, 100f)] private float m_speed = 5f;
    [SerializeField][Min(0)] private float m_angularSpeed = 500f;

    public float speed => m_speed;

    public float angularSpeed => m_angularSpeed;

    public Texture2D cursoreTexture => m_cursoreTexture; 
}
