using NaughtyAttributes;
using UnityEngine;


[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 0)]
public class Level : ScriptableObject
{
    public TextAsset jsonFile;
    public Questions questions;

#if UNITY_EDITOR
    [Button("Load Question Data")]
    public void LoadData()
    {
        var data = JsonUtility.FromJson<Questions>(jsonFile.text);
        questions = data;
    }
    
    [Button("Clear Question Data")]
    public void ClearData()
    {
        questions = null;
    }
#endif
}
