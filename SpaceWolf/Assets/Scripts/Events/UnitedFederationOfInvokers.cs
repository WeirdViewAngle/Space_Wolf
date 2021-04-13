using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;


public class UnitedFederationOfInvokers : MonoBehaviour
{
        protected Dictionary<EventName, UnityEvent<int>> dictOfInvokers
            = new Dictionary<EventName, UnityEvent<int>>();
        
        public void AddListener(EventName eventName, UnityAction<int> listener)
        {
            if (dictOfInvokers.ContainsKey(eventName))
            {
                dictOfInvokers[eventName].AddListener(listener);
            }
        }
}