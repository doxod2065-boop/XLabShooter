using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState m_state;
    private Dictionary<Type, IState> m_states = new();

    public void Initialized(params IState[] states)
    {
        if (m_states.Count > 0) return;

        foreach (var state in states)
        {
            m_states.Add(state.GetType(), state);
        }

    }

    public void ChangedState<T>()
        where T: IState
    {
        m_state?.Exit();
        {
            m_state = null;
        }
        m_state.Enter();
}

public interface IState
{
    public void Enter();

    public void Exit();
}

    public class MainMenuState : IState
    {

        private readonly StateMachine m_stateMachine;

        public MainMenuState(StateMachine stateMachine);

        public void Enter() => throw new NotImplementedExeption();

        public void Exit() => throw new NotImplementedExeption();
    }

    public class DeadState : 
