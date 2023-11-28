using UnityEngine;
using UnityEngine.Events;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "Objective", menuName = "ScriptableObjects/Objective", order = 0)]
    public class Objective : ScriptableObject
    {
        public string objectiveName;
        public string description;
        public bool isCompleted;

        public UnityEvent onComplete;

        public void ResetObjective()
        {
            isCompleted = false;
        }

        public void Complete()
        {
            isCompleted = true;
            onComplete?.Invoke();
        }
    }
}