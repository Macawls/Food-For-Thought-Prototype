using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Scriptable;
using UnityEngine;
using UnityEngine.Events;

class ObjectiveState
{
    public Objective objective;
    public bool complete;
    
    public ObjectiveState(Objective objective)
    {
        this.objective = objective;
    }
}

namespace Scriptable
{
    [CreateAssetMenu(fileName = "Mission", menuName = "ScriptableObjects/Mission", order = 0)]
    public class Mission : ScriptableObject
    {
        public string missionName;
        public string description;
        public List<Objective> objectives;

        public UnityEvent complete;

        [Button(nameof(ResetAll), EButtonEnableMode.Editor)]
        public void ResetAll()
        {
            for (var i = 0; i < objectives.Count; i++)
            {
                objectives[i].isCompleted = false;
            }
        }

        public void Init()
        {
            for (int i = 0; i < objectives.Count; i++)
            {
                var obj = objectives[i];
                obj.onComplete.AddListener(() =>
                {
                    if (objectives.All(e => e.isCompleted))
                    {
                        complete?.Invoke();
                    }
                });
            }
        }
    }
}