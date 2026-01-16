using Entities;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Image m_bar;
    [SerializeField] private HealthComponent m_healthComponent;

    private void OnEnable()
    {
        m_healthComponent.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        m_healthComponent.ValueChanged -= OnValueChanged;
    }

    private void SetValue() =>
        m_bar.fillAmount = ((float)m_healthComponent.Value)/((float)m_healthComponent.);)
}


