using UnityEngine;
using UnityEngine.Events;

public class PlatformButtonTriggers : MonoBehaviour
{
   [SerializeField] private UnityEvent playerEnter;
   [SerializeField] private UnityEvent playerExit;

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out IPlayer player))
      {
         playerEnter?.Invoke();
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.TryGetComponent(out IPlayer player))
      {
         playerExit?.Invoke();
      }
   }
}
