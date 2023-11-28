using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MissionWindowUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionText;
    [SerializeField] private TextMeshProUGUI missionDescription;
    [SerializeField] private Transform objectiveContainer;
    [SerializeField] private ObjectiveUI prefab;

    [SerializeField] private UnityEvent onShow;
    [SerializeField] private UnityEvent onHide;
    
    
    [SerializeField] private KeyCode toggleKey;
    public bool keysEnabled = false;

    public bool isActive;

    private Mission _mCurrent;
    
    
    public void Show(Mission mission)
    {
        if (_mCurrent != null)
        {
            if (mission.missionName != _mCurrent.missionName)
            {
                // new one so clear old stuff
                DOVirtual.DelayedCall(0.7f, () =>
                {
                    missionText.fontStyle = FontStyles.Normal;
                });
                
                for (int i = 0; i < objectiveContainer.transform.childCount; i++)
                {
                    Destroy(objectiveContainer.GetChild(i).gameObject);
                }

            }
        }
        
        _mCurrent = mission;
        isActive = true;
        onShow?.Invoke();

        SetMission(_mCurrent);
    }
    
    public void Hide()
    {
        isActive = false;
        onHide?.Invoke();
    }

    public void EnableKeys(bool val)
    {
        keysEnabled = val;
    }

    public void SetMission(Mission mission)
    {
        if (_mCurrent == null) return;
        
        missionText.text = mission.missionName;
        missionDescription.text = mission.description;
        
        mission.complete.AddListener(() =>
        {
            missionText.fontStyle |= FontStyles.Strikethrough; // add
        });

        foreach (var objective in mission.objectives)
        {
            var ui = Instantiate(prefab, objectiveContainer);
            ui.Init(objective);
        }
    }

    private void Update()
    {
        if (_mCurrent == null) return;

        if (keysEnabled)
        {
            if (!isActive && Input.GetKeyDown(toggleKey))
            {
                isActive = true;
                onShow?.Invoke();
            }
        
            else if (isActive && Input.GetKeyDown(toggleKey))
            {
                isActive = false;
                onHide?.Invoke();
            }
        }
    }



}
