using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class PlatformButtonTriggers : MonoBehaviour
{
   [SerializeField] private UnityEvent playerEnter;
   [SerializeField] private UnityEvent playerExit;

   [SerializeField] private FloatVariable timeSpent;

   private bool active;

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out IPlayer player))
      {
         timeSpent.Value = 0f;
         active = true;
         playerEnter?.Invoke();
      }
   }

   private void Update()
   {
      if (active)
      {
         timeSpent.Value += Time.deltaTime;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.TryGetComponent(out IPlayer player))
      {
         timeSpent.Value = 0f;
         active = false;
         playerExit?.Invoke();
      }
   }
}
