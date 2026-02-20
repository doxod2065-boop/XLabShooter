using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    public ServiceLocator m_serviceLocator;

    private Dictionary<Types, object> m_services = new();

    public static void Register<T>(T instance)
    {
        m_serviceLocator ??= new ServiceLocator();
        m_serviceLocator.m_services.Add(Typeof(T), instance);
    }   
    
    public T Resolve<T>()
    {
        if (m_serviceLocator is null)
            throw new NullReferenceException("Service locator is null");

        return m_serviceLocator.m_services[typeof]
    }
}
