using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    private Transform m_parent;
    private Vector3 m_worldoffset;
    private Quaternion m_rotation;

    void Start()
    {
        m_parent = transform.parent;

        m_rotation = transform.rotation;
        m_worldoffset =transform.position - m_parent.position;
    }


    void LateUpdate()
    {
        if(!m_parent)
        {

            return;
        }

        transform.position = m_parent.position + m_worldoffset;
        transform.rotation = m_rotation;
    }
}
