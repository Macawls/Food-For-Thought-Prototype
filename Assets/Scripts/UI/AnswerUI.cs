using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private Image colorImage;
    public Image fillIMage;
    
    [Header("Events")] 
    [SerializeField] private UnityEvent<Answer> onLoaded;
    [SerializeField] private UnityEvent<Answer> onSelected;
    [SerializeField] private UnityEvent<Answer> onDeselected;

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
        onSelected?.Invoke(_mValue);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mOnClickCallback?.Invoke(_mValue);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onDeselected?.Invoke(_mValue);
    }

    public void Select()
    {
        onSelected?.Invoke(_mValue);
    }

    public void Click()
    {
        _mOnClickCallback?.Invoke(_mValue);
    }

    public void Deselect()
    {
        onDeselected?.Invoke(_mValue);
    }

    public void SetFillAmount(float val)
    {
        fillIMage.fillAmount = val;
    }

    public void SetColor(Color val)
    {
        colorImage.color = val;
    }
}
