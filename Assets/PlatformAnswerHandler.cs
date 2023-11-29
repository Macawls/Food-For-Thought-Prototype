using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class PlatformAnswerHandler : MonoBehaviour
{
    private List<AnswerUI> _mSelectionOptions = new();


    [SerializeField] private float timeBeforeAnswer = 6.0f;
    

    [SerializeField] private Color one;
    [SerializeField] private Color two;
    [SerializeField] private Color three;


    [SerializeField] private FloatVariable selectionOneTime;
    [SerializeField] private FloatVariable selectionTwoTime;
    [SerializeField] private FloatVariable selectionThreeTime;
    
    
    
    
    
    public void UpdateSelectionOptions(IEnumerable<AnswerUI> value)
    {
        _mSelectionOptions = new List<AnswerUI>(value);

        if (_mSelectionOptions.Count >= 1)
        {
            //_mCurrentNode = _mSelectionOptions[0];
            //_mCurrentNode.Value.Select();
        }

        var list = value.ToList();
        list[0].SetColor(one);
        list[1].SetColor(two);
        list[2].SetColor(three);
    }

    public void Select(int index)
    {
        _mSelectionOptions[index].Select();

        if (index == 0)
        {
            _mSelectionOptions[1].SetFillAmount(0);
            _mSelectionOptions[2].SetFillAmount(0);
        }

        if (index == 1)
        {
            _mSelectionOptions[0].SetFillAmount(0);
            _mSelectionOptions[2].SetFillAmount(0);
        }

        if (index == 2)
        {
            _mSelectionOptions[1].SetFillAmount(0);
            _mSelectionOptions[0].SetFillAmount(0);
        }
    }

    public void Deselect(int index)
    {
        _mSelectionOptions[index].Deselect();
        _mSelectionOptions[index].SetFillAmount(0);
    }

    private void Awake()
    {
        selectionOneTime.Changed.Register(f =>
        {
            _mSelectionOptions[0].SetFillAmount(f / timeBeforeAnswer);
            
            if (f > timeBeforeAnswer)
            {
                _mSelectionOptions[0].Click();
                selectionOneTime.Value = 0f;
            }
        });
        
        selectionTwoTime.Changed.Register(f =>
        {
            _mSelectionOptions[1].SetFillAmount(f / timeBeforeAnswer);
            
            if (f > timeBeforeAnswer)
            {
                _mSelectionOptions[1].Click();
                selectionOneTime.Value = 0f;
            }
        });
        
        selectionThreeTime.Changed.Register(f =>
        {
            _mSelectionOptions[2].SetFillAmount(f / timeBeforeAnswer);
            
            if (f > timeBeforeAnswer)
            {
                _mSelectionOptions[2].Click();
                selectionOneTime.Value = 0f;
            }
        });
    }
}
