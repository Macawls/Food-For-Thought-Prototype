using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class AnswerSelectionHandlerUI : MonoBehaviour
{
    [Expandable][SerializeField] private ControlKeys controlKeys;

    private LinkedList<AnswerUI> _mSelectionOptions = new();
    private LinkedListNode<AnswerUI> _mCurrentNode;

    public void UpdateSelectionOptions(IEnumerable<AnswerUI> value)
    {
        _mSelectionOptions = new LinkedList<AnswerUI>(value);

        if (_mSelectionOptions.Count >= 1)
        {
            _mCurrentNode = _mSelectionOptions.First;
            _mCurrentNode.Value.Select();
        }
    }

    private void Update()
    {
        if (_mSelectionOptions.Count == 0)
        {
            return;
        }
        
        if (controlKeys.up.Any(Input.GetKeyDown))
        {
           SelectNext();
        }
        else if (controlKeys.down.Any(Input.GetKeyDown))
        {
           SelectPrevious();
        }
        else if (controlKeys.select.Any(Input.GetKeyDown))
        {
            ClickCurrent();
        }
    }

    private void ClickCurrent()
    {
        _mCurrentNode.Value.Click();
    }

    private void SelectNext()
    {
        _mCurrentNode.Value.Deselect();
        _mCurrentNode = _mCurrentNode.Previous ?? _mSelectionOptions.Last;
        _mCurrentNode.Value.Select();
    }

    private void SelectPrevious()
    {
        _mCurrentNode.Value.Deselect();
        _mCurrentNode = _mCurrentNode.Next ?? _mSelectionOptions.First;
        _mCurrentNode.Value.Select();
    }
}


