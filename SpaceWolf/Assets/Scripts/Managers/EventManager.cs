using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;


public static class EventManager
{
    static Dictionary<EventName, List<UnitedFederationOfInvokers>> invokers
        = new Dictionary<EventName, List<UnitedFederationOfInvokers>>();

    static Dictionary<EventName, List<UnityAction<int>>> listeners
        = new Dictionary<EventName, List<UnityAction<int>>>();


    public static void Initialize()
    {
        // create empty lists for all the dictionary entries
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<UnitedFederationOfInvokers>());
                listeners.Add(name, new List<UnityAction<int>>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    public static void AddInvoker(EventName eventName, UnitedFederationOfInvokers invoker)
    {
        foreach(UnityAction<int> listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }

        invokers[eventName].Add(invoker);
    }

    public static void AddListener(EventName eventName, UnityAction<int> listener)
    {
        foreach (UnitedFederationOfInvokers invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);
    }

    public static void RemoveInvoker(EventName eventName, UnitedFederationOfInvokers invoker)
    {
        foreach(UnityAction<int> listener in listeners[eventName])
        {
            listeners[eventName].Remove(listener);
        }
        invokers[eventName].Remove(invoker);
    }
}
