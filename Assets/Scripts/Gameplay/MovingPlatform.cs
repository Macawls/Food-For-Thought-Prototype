using System;
using DG.Tweening;
using UnityEngine;



public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private bool beginOnStart;
    [SerializeField] private Ease ease = Ease.InOutQuad;
    public Direction direction = Direction.Up;
    
    
    public float duration;
    public float distance;


    private void Start()
    {
        if (beginOnStart)
        {
            Perform();
        }
    }

    private void Perform()
    {
        var endPos = transform.position + direction.ToVector() * distance;
        
        transform.DOMove(endPos, duration)
            .SetEase(ease)
            .OnComplete(() =>
            {
                direction = direction.GetOpposite();
                Perform();
            });
    }
}
