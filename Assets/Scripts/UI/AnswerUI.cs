using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnswerUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI content;
    
    [Header("Events")] 
    [SerializeField] private UnityEvent<Answer> onLoaded;
    [SerializeField] private UnityEvent<Answer> onPointerEnter;
    [SerializeField] private UnityEvent<Answer> onPointerExit;

    private Answer _mValue;
    private Action<Answer> _mOnClickCallback;

    public void Load(Answer value, Action<Answer> onClickCallBack)
    {
        onLoaded?.Invoke(value);
        content.text = value.content;
        
        _mOnClickCallback = onClickCallBack;
        _mValue = value;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onPointerEnter?.Invoke(_mValue);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mOnClickCallback?.Invoke(_mValue);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExit?.Invoke(_mValue);
    }
}
