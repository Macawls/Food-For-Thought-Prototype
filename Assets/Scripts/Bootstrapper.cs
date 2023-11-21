using DG.Tweening;
using UnityEngine;


public static class Bootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void SetMaxTweenCapacity()
    {
        DOTween.SetTweensCapacity(tweenersCapacity: 150, sequencesCapacity: 200);
    }
}

