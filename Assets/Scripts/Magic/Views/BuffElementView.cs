using UnityEngine;
using Microsoft.Unity.VisualStudio.Editor;

public class BuffElementView : MonoBehaviour
{
    [SerializeField] private Image m_timerImage;
    [SerializeField] private Image m_iconImage;

    public void Initialeze()
    {
        gameObject.SetActive(true);
        m_iconImage.sprite = buff.Icon;
    }

    private void Update()
    {
        if (m_buff is ITimeBuff timeBuff)
        {
            m_timerImage.fillAmount = timerBuff.timer / timeBuff;
        }
    }

    public void Deinitialize(Buff buff)
    {
       m_buff = null;
        m_timerImage.fillAmount = 0;
        gameObject.SetActive(false);
    }
}
