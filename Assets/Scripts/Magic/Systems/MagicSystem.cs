using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MagicState;

public class MagicSystem : MonoBehaviour
{
    public event Action SpellCancelled;
    public event Action<MagicState> StateChanged;
    public event Action<IReadOnlyList<ElementType>> ElementChanged
    {
        add => spellPreparation.ElementsChanged += value;
        remove => spellPreparation.ElementsChanged -=value;

    }

    [SerializeField] private MagicConfig m_config;
    [SerializeField] private MouseResolver m_mouseRosolver;

    private MagicState m_state;
    private SpellCaster m_caster;
    private SpellPreparation m_spellPreparation;
    private Coroutine m_cooldownCoroutine;

    public MagicState state
    {
        get => m_state;
        private set
        {
            if(m_state != value)
            {
                m_state = value;
                StateChanged?.Invoke(m_state);
            }
        }
    }

    private SpellPreparation spellPreparation =>
        m_spellPreparation ??= new SpellPreparation(m_config);

    private void Awake()
    {
        m_caster = new SpellCaster(transform);
    }

    private void OnEnable() =>
        spellPreparation.OverflowOccurred += CancelSpell;

    private void OnDisable() =>
        spellPreparation.OverflowOccurred -= CancelSpell;

    public void AddElement(ElementType element)
    {
        if(state is MagicState.Coldown or MagicState.Casting)
        {
            return;
        }

        spellPreparation.AddElement(element);
        state = MagicState.Preparation;
    }


    public void TryCastSpell()
    {
        if(state is not MagicState.Preparation)
        {
            return;
        }
        
        if(spellPreparation.TryGetSpell(out var spell))
        {
            state = MagicState.Casting;

            m_caster.Cast(spell, m_mouseRosolver.GetCursorWorldPosition().Value);


            spellPreparation.Clear();
            state = MagicState.Idle;
        }
        else
        {
            CancelSpell();
        }
    }

    private void CancelSpell()
    {
        if(state is MagicState.Preparation)
        {
            spellPreparation.Clear();
            SpellCancelled?.Invoke();

            StartCooldown();
        }
    }



    private void StartCooldown()
    {
        if(m_cooldownCoroutine is not  null)
        {
            StopCoroutine(m_cooldownCoroutine);
        }

        m_cooldownCoroutine = StartCoroutine(ColdownRoutine());
    }


    private IEnumerator ColdownRoutine()
    {
        state = MagicState.Coldown;
        yield return new WaitForSeconds(m_config.cancelColdown);
        state = MagicState.Idle;

        m_cooldownCoroutine = null;
    }

   
}
